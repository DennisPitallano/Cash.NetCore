namespace Cash.NetCore.Configurations;

/// <summary>
/// CashConfiguration Configuration Interface
/// </summary>
public interface ICashConfiguration
{
    /// <summary>
    /// Cash Options
    /// </summary>
    CashOptions CashOptions { get; }
}