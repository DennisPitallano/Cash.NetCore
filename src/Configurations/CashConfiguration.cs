namespace Cash.NetCore.Configurations;

/// <inheritdoc />
public class CashConfiguration : ICashConfiguration
{
    /// <inheritdoc />
    public CashOptions CashOptions { get; set; } = new();
}