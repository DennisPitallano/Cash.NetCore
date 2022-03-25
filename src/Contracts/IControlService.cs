using Cash.NetCore.Models.Response.Control;

namespace Cash.NetCore.Contracts;

/// <summary>
///     IControlService
/// </summary>
public interface IControlService
{
    /// <summary>
    ///     Control - Get Network Info
    /// </summary>
    /// <returns>RPC call which gets basic full node information.</returns>
    Task<NetworkInfo?> GetNetworkInfoAsync();
}