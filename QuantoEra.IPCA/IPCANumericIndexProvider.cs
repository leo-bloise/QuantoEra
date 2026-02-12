namespace QuantoEra.IPCA;

/// <summary>
/// Provides services to retrieve and manage IPCA numeric index data from sources like BCB.
/// </summary>
/// <param name="ipcaPercentageProvider"></param>
public class IPCANumericIndexProvider(IPCAMonthlyPercentageProvider ipcaPercentageProvider) : IDisposable
{
    private bool _disposed = false;

    public async Task<Dictionary<DateOnly, IPCANumericIndex>> CalculateAsync(DateOnly startDate, DateOnly endDate, decimal baseIndex = 100m) 
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        IEnumerable<IPCAMonthlyRate> rates = await ipcaPercentageProvider.GetAsync(startDate, endDate);

        Dictionary<DateOnly, IPCANumericIndex> numericIndexes = new();

        decimal current = baseIndex;

        foreach(IPCAMonthlyRate rate in rates.OrderBy(rate => rate.Date))
        {
            current *= (1 + rate.Rate);

            numericIndexes[rate.Date] = new IPCANumericIndex(rate.Date, current);
        }

        return numericIndexes;
    }

    public void Dispose()
    {
        if(this._disposed) return;

        ipcaPercentageProvider.Dispose();

        this._disposed = true;

        GC.SuppressFinalize(this);
    }
}