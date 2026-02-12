namespace QuantoEra.IPCA;

/// <summary>
/// Represents the monthly IPCA rate data, including percentage values and associated dates.
/// </summary>
public class IPCAMonthlyRate
{
    public DateOnly Date { get; private set; }

    public decimal Rate { get; private set; }

    public IPCAMonthlyRate(DateOnly date, decimal rate)
    {
        Date = date;
        Rate = rate;
    }
}