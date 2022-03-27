namespace Cash.NetCore.Contracts;

/// <summary>
///     IPriceService
/// </summary>
public interface IPriceService
{
    /// <summary>
    ///     Price - Get rates for several different currencies
    /// </summary>
    /// <returns>Get rates for several different currencies from Coinbase.</returns>
    Task<IDictionary<string, string>?> GetRatesAsync();
    
    /// <summary>
    /// Price - Get the USD price of BCH
    /// </summary>
    /// <returns>Get the USD price of BCH from Coinbase.</returns>
    Task<decimal> GetBchUsdPriceAsync();
    /// <summary>
    /// Price - Get the USD price of BCHA
    /// </summary>
    /// <returns>Get the USD price of BCHA from Coinex.</returns>
    Task<decimal> GeteCashUsdPriceAsync();
}