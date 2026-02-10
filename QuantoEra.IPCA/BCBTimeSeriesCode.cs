namespace QuantoEra.IPCA;

/// <summary>
/// Time series codes used by the application to retrieve rates
/// from the BCB SGS system.
/// </summary>
/// <seealso cref="IPCA_MONTHLY" />
public enum BCBTimeSeriesCode
{
    /// <summary>
    /// Monthly IPCA index (series 433).
    /// </summary>
    /// <seealso href="https://www3.bcb.gov.br/sgspub/consultarvalores/consultarValoresSeries.do?method=consultarSeries&series=433" />
    IPCA_MONTHLY = 433
}
