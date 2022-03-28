using Cash.NetCore.Models.Response.Slp;

namespace Cash.NetCore.Contracts;

/// <summary>
///     ISlpService
/// </summary>
public interface ISlpService
{
    /// <summary>
    ///     SLP - Convert address to slpAddr, cashAddr and legacy.
    /// </summary>
    /// <param name="address">address</param>
    /// <returns>Convert address to slpAddr, cashAddr and legacy.</returns>
    Task<SlpConvertAddress?> GetConvertAddressAsync(string address);

    /// <summary>
    ///     SLP - Convert multiple addresses to cash, legacy and simpleledger format.
    /// </summary>
    /// <param name="addresses">addresses</param>
    /// <returns>Convert multiple addresses to cash, legacy and simpleledger format.</returns>
    Task<IEnumerable<SlpConvertAddress>?> GetConvertAddressesAsync(string[] addresses);

    Task<IEnumerable<SlpTokenWhitelist>> GetTokenWhitelistAsync(string tokenId);
}