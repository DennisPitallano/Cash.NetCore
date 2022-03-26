using Cash.NetCore.Models.Response.Mining;

namespace Cash.NetCore.Contracts;

/// <summary>
///     IMiningService
/// </summary>
public interface IMiningService
{
    /// <summary>
    ///     Mining - Get Estimated network hashes per second.
    /// </summary>
    /// <param name="nblocks">nblocks</param>
    /// <param name="nheight">nheight</param>
    /// <returns>
    ///     Returns the estimated network hashes per second based on the last n blocks. Pass in [blocks] to override # of
    ///     blocks, -1 specifies since last difficulty change. Pass in [height] to estimate the network speed at the time when
    ///     a certain block was found.
    /// </returns>
    Task<decimal> GetNetworkHashpsAsync(int nblocks, int nheight);

    /// <summary>
    ///     Mining - Get Mining Info.
    /// </summary>
    /// <returns>Returns a json object containing mining-related information.</returns>
    Task<MiningInfo?> GetMiningInfoAsync();
}