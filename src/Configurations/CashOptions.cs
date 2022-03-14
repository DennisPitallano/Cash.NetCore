namespace Cash.NetCore.Configurations;

/// <summary>
/// CashOptions Options 
/// </summary>
public class CashOptions
{
    /// <summary>
    /// Api-Key Token from CashOptions Account
    /// </summary>
    public string Token { get; set; } = "ZXD3CX98EJ2C5MIDYFPQJB6SKQ1BVJY1D934"; //default token

    /// <summary>
    /// CashOptions API domain
    ///  Ex: https://api.fullstack.cash/ for main network
    ///      https://tapi.fullstack.cash/  for test network
    /// </summary>
    public string Uri { get; set; } = "https://api.fullstack.cash/"; // default main net Uri
}