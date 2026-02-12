namespace QuantoEra.IPCA;

/// <summary>
/// Represents the numeric index value of the IPCA (Índice de Preços ao Consumidor Amplo) used for economic analysis.
/// </summary>
/// <param name="Date"></param>
/// <param name="NumericIndex"></param>
public record IPCANumericIndex(DateOnly Date, decimal NumericIndex);