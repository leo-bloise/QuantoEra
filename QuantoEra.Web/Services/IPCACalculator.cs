using QuantoEra.IPCA;

namespace QuantoEra.Web.Services
{
    public class IPCACalculator
    {
        private readonly IPCANumericIndexProvider _ipcaNumericIndexProvider;

        public IPCACalculator(IPCANumericIndexProvider ipcaNumericIndexProvider)
        {
            _ipcaNumericIndexProvider = ipcaNumericIndexProvider;
        }

        public async Task<decimal> CalculateCorrectedValue(decimal valueToBeCorrected, DateOnly userDatePicked)
        {
            Calendar.Calendar calendar = new Calendar.Calendar();

            userDatePicked = calendar.FirstDayOfMonth(userDatePicked);

            DateOnly today = calendar.FirstDayOfCurrentMonth();

            var numericIndexes = await _ipcaNumericIndexProvider.CalculateAsync(userDatePicked, today);

            if (!numericIndexes.TryGetValue(userDatePicked, out var userDateIndex))
            {
                throw new ArgumentException($"Numeric index not found for date: {userDatePicked}");
            }

            var lastNumericIndex = numericIndexes.LastOrDefault();

            if (userDateIndex.NumericIndex == 0)
            {
                throw new DivideByZeroException("The numeric index for the user's selected date is zero, which would lead to a division by zero.");
            }

            if(lastNumericIndex.Value == null)
            {
                throw new ArgumentException($"The last available index was not valid. Please check with the administrator.");
            }

            decimal factor = (lastNumericIndex.Value.NumericIndex / userDateIndex.NumericIndex);

            return valueToBeCorrected * factor;
        }
    }
}
