using System.Net.Http.Json;
using QuantoEra.IPCA.DTOs;
using QuantoEra.IPCA.Exceptions;

namespace QuantoEra.IPCA;

/// <summary>
/// Provides IPCA monthly rate from the SGS BCB system.
/// </summary>
public class IPCAMonthlyPercentageProvider : IDisposable
{
    private readonly string _base = "https://api.bcb.gov.br";
    private readonly HttpClient _client;

    private bool _disposed = false;

    public IPCAMonthlyPercentageProvider()
    {
        _client = new HttpClient();
    }

    public void Dispose()
    {        
        if(_disposed) return;

        _client.Dispose();

        GC.SuppressFinalize(this);
    }

    private HttpRequestMessage BuildRequestForIPCAMonthlyPercentual(DateOnly startDate, DateOnly endDate)
    {
        return new HttpRequestMessage(HttpMethod.Get, $"{_base}/dados/serie/bcdata.sgs.{(int)BCBTimeSeriesCode.IPCA_MONTHLY}/dados?formato=json&dataInicial={startDate.ToString("dd/MM/yyyy")}&dataFinal={endDate.ToString("dd/MM/yyyy")}");
    }

    private Task<HttpResponseMessage> SendRequest(HttpRequestMessage request, CancellationToken? cancellationToken)
    {
        if(cancellationToken == null) return _client.SendAsync(request);
        
        return _client.SendAsync(request, (CancellationToken) cancellationToken);
    }

    private Task<List<IPCAMonthlyRateDTO>?> ReadResponse(HttpResponseMessage response, CancellationToken? cancellationToken)
    {
        response.EnsureSuccessStatusCode();   

        if(cancellationToken == null) return response.Content.ReadFromJsonAsync<List<IPCAMonthlyRateDTO>>();

        return response.Content.ReadFromJsonAsync<List<IPCAMonthlyRateDTO>>((CancellationToken) cancellationToken);
    }

    /// <summary>
    /// Retreives a list of IPCA rates organized by month within the date range provided. Every rate corresponds to the rate of that month.
    /// </summary>
    /// <param name="startDate">Start date of the range. Inclusive</param>
    /// <param name="endDate">End date of the range. Inclusive</param>
    /// <param name="cancellationToken">Cancellation token to properly handle cancellation. It may be null, but always consider passing it</param>
    /// <returns>List of IPCAMonthlyRate of every month rate inside the range</returns>
    /// <exception cref="IpcaProviderException"></exception>
    /// <exception cref="ObjectDisposedException"></exception>
    /// <exception cref="TaskCanceledException"></exception>
    public async Task<IEnumerable<IPCAMonthlyRate>> GetAsync(DateOnly startDate, DateOnly endDate, CancellationToken? cancellationToken = null)
    {
        ObjectDisposedException.ThrowIf(this._disposed, this);

        if(startDate > endDate) throw new IpcaProviderException("Invalid date range provided. Start date must be smaller than end date.");

        try
        {
            HttpRequestMessage request = BuildRequestForIPCAMonthlyPercentual(startDate, endDate);

            HttpResponseMessage response = await SendRequest(request, cancellationToken);

            List<IPCAMonthlyRateDTO>? rates = await ReadResponse(response, cancellationToken);

            ArgumentNullException.ThrowIfNull(rates);

            return rates
                .Select(rate => rate.Convert())
                .OrderBy(rate => rate.Date);
        }
        catch(TaskCanceledException)
        {
            throw;
        }
        catch(Exception exception)
        {
            throw new IpcaProviderException($"It was not possible to get the IPCA rate for this range of date {startDate} to {endDate}", exception);
        }
    }
}
