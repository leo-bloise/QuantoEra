using System.Globalization;

namespace QuantoEra.IPCA.DTOs;

public record IPCAMonthlyRateDTO(string Data, string Valor)
{
    /// <summary>
    /// Convert DTO to Domain Object. It divides Valor by 100 in order to extract its decimal form from percentage form. 
    /// </summary>
    /// <returns>IPCA rate for an specific date</returns>
    /// <exception cref="ParsingException"></exception>
    public IPCAMonthlyRate Convert()
    {
        if(!decimal.TryParse(Valor, out decimal percentageRate)) throw new ParsingException($"Invalid decimal value {Valor}");

        decimal decimalRate = percentageRate / 100m;

        DateOnly date = DateOnly.Parse(Data, CultureInfo.GetCultureInfo("pt-BR").DateTimeFormat);

        return new IPCAMonthlyRate(date, decimalRate);
    }
}