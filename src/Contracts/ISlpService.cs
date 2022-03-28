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

    /// <summary>
    ///     SLP - SLP token whitelist.
    /// </summary>
    /// <returns>
    ///     Get tokens that are on the whitelist. SLPDB is typically used to validate SLP transactions. It can become
    ///     unstable during periods of high network usage. A second SLPDB has been implemented that is much more stable,
    ///     because it only tracks a whitelist of SLP tokens. This endpoint will return information on the SLP tokens that are
    ///     included in that whitelist.
    /// </returns>
    Task<IEnumerable<SlpTokenWhitelist>?> GetTokenWhitelistAsync();
}