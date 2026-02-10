namespace QuantoEra.Calendar;

public class Calendar
{
    public DateOnly FirstDayOfMonth(DateOnly date)
    {
        return new DateOnly(date.Year, date.Month, 1);
    }

    public DateOnly FirstDayOfCurrentMonth()
    {
        return FirstDayOfMonth(DateOnly.FromDateTime(DateTime.Now));
    }
}
