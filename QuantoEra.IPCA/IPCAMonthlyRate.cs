namespace QuantoEra.IPCA;

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