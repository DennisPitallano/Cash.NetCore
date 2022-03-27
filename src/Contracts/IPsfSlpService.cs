using Cash.NetCore.Models.Response.PsfSlp;

namespace Cash.NetCore.Contracts;

/// <summary>
///     PSF SLP
/// </summary>
public interface IPsfSlpService
{
    /// <summary>
    ///     PSF SLP - Indexer Status.
    /// </summary>
    /// <returns>Return SLP indexer status</returns>
    Task<IndexerStatus?> GetIndexerStatusAsync();

    /// <summary>
    ///     PSF SLP - SLP balance for address.
    /// </summary>
    /// <param name="token">token</param>
    /// <returns>Return SLP balance for address</returns>
    Task<PsfSlpTokenStatus?> GetTokenStatusAsync(string token);

    /// <summary>
    ///     PSF SLP - SLP transaction data.
    /// </summary>
    /// <param name="address">address</param>
    /// <returns>Return slp transaction data.</returns>
    Task<PsfSlpBalance?> GetPsfSlpBalanceAsync(string address);

    /// <summary>
    /// PSF SLP - SLP transaction data.
    /// </summary>
    /// <param name="txid">txid</param>
    /// <returns>Return slp transaction data.</returns>
    Task<PsfSlpTransaction?> GetPsfSlpTransactionDataAsync(string txid);
}