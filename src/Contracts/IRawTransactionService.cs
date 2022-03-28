using Cash.NetCore.Models.Response.RawTransaction;

namespace Cash.NetCore.Contracts;

/// <summary>
///     IRawTransactionService
/// </summary>
public interface IRawTransactionService
{
    /// <summary>
    ///     Raw Transaction - Bulk Decode Script.
    /// </summary>
    /// <param name="hexes">hexes</param>
    /// <returns>Decode multiple hex-encoded scripts.</returns>
    Task<IEnumerable<DecodeScript>?> GetDecodeScriptsAsync(string[] hexes);

    /// <summary>
    ///     Raw Transaction - Decode Bulk Raw Transactions.
    /// </summary>
    /// <param name="hexes">hexes</param>
    /// <returns>Return bulk hex encoded transaction.</returns>
    Task<IEnumerable<RawTransaction>?> GetDecodeBulkRawTransactionsAsync(string[] hexes);

    /// <summary>
    /// </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    Task<RawTransaction?> GetDecodeRawTransactionAsync(string hex);

    /// <summary>
    ///     Raw Transaction - Decode Single Script.
    /// </summary>
    /// <param name="hex">hex</param>
    /// <returns>Decode a hex-encoded script.</returns>
    Task<DecodeScript?> GetDecodeScriptAsync(string hex);

    /// <summary>
    ///     Raw Transaction - Get Bulk Raw Transactions.
    /// </summary>
    /// <param name="txids">txids</param>
    /// <returns>
    ///     Return the raw transaction data for multiple transactions. If verbose is 'true', returns an Object with
    ///     information about 'txid'. If verbose is 'false' or omitted, returns a string that is serialized, hex-encoded data
    ///     for 'txid'.
    /// </returns>
    Task<IEnumerable<RawTransaction>?> GetRawTransactionsVerboseAsync(string[] txids);

    /// <summary>
    ///     Raw Transaction - Get Bulk Raw Transactions.
    /// </summary>
    /// <param name="txids">txids</param>
    /// <returns>
    ///     Return the raw transaction data for multiple transactions. If verbose is 'true', returns an Object with
    ///     information about 'txid'. If verbose is 'false' or omitted, returns a string that is serialized, hex-encoded data
    ///     for 'txid'.
    /// </returns>
    Task<IEnumerable<string>?> GetRawTransactionsAsync(string[] txids);

    /// <summary>
    ///     Raw Transaction - Return the raw transaction data.
    /// </summary>
    /// <param name="txid"></param>
    /// <returns>
    ///     return the raw transaction data. If verbose is 'true', returns an Object with information about 'txid'. If
    ///     verbose is 'false' or omitted, returns a string that is serialized, hex-encoded data for 'txid'.
    /// </returns>
    Task<RawTransaction?> GetRawTransactionVerboseAsync(string txid);

    /// <summary>
    ///     Raw Transaction - Return the raw transaction data.
    /// </summary>
    /// <param name="txid"></param>
    /// <returns>
    ///     return the raw transaction data. If verbose is 'true', returns an Object with information about 'txid'. If
    ///     verbose is 'false' or omitted, returns a string that is serialized, hex-encoded data for 'txid'.
    /// </returns>
    Task<string?> GetRawTransactionAsync(string txid);
}