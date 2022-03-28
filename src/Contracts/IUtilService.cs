using Cash.NetCore.Models.Response.Util;

namespace Cash.NetCore.Contracts;

/// <summary>
/// IUtilService
/// </summary>
public interface IUtilService
{
    /// <summary>
    /// Util - Get information about bulk bitcoin cash addresses..
    /// </summary>
    /// <param name="addresses">addresses</param>
    /// <returns>Returns information about bulk bitcoin cash addresses..</returns>
    Task<IEnumerable<AddressInfo>?> ValidateAddressesAsync(string[] addresses);
    
    /// <summary>
    /// Util - Get information about single bitcoin cash address.
    /// </summary>
    /// <param name="address">address</param>
    /// <returns>Returns information about single bitcoin cash address.</returns>
    Task<AddressInfo?> ValidateAddressAsync(string address);
}