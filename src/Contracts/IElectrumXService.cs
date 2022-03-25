using Cash.NetCore.Models.Request.ElectrumX;
using Cash.NetCore.Models.Response.ElectrumX;

namespace Cash.NetCore.Contracts;

/// <summary>
/// </summary>
public interface IElectrumXService
{
    /// <summary>
    ///     ElectrumX / Fulcrum - Get `count` block headers starting at a height
    /// </summary>
    /// <param name="height">height</param>
    /// <param name="count">count</param>
    /// <returns></returns>
    Task<BlockHeaderCount?> GetElectrumXBlockHeadersCountAsync(long height, int count);

    /// <summary>
    ///     ElectrumX / Fulcrum - Get balance for a single address.
    /// </summary>
    /// <param name="address">address</param>
    /// <returns>Returns an object with confirmed and unconfirmed balance associated with an address.</returns>
    Task<BalanceInfo?> GetElectrumXBalanceAsync(string address);

    /// <summary>
    ///     ElectrumX / Fulcrum - Get balances for an array of addresses.
    /// </summary>
    /// <param name="addresses">addresses</param>
    /// <returns>Returns an array of balanes associated with an array of address. Limited to 20 items per request.</returns>
    Task<BalancesInfo?> GetElectrumXBalancesAsync(string[] addresses);


    /// <summary>
    ///     ElectrumX / Fulcrum - Get block headers for an array of height + count pairs
    /// </summary>
    /// <param name="heightsAndCounts">heightsAndCounts</param>
    /// <returns>Returns an array of objects with blockheaders of an array of TXIDs. Limited to 20 items per request.</returns>
    Task<BlockHeaderHeightsCounts?>
        GetElectrumXBlockHeadersHeightCountAsync(List<BlockHeadersRequest> heightsAndCounts);

    /// <summary>
    ///     ElectrumX / Fulcrum - Get the transaction history for an array of addresses.
    /// </summary>
    /// <param name="addresses">addresses</param>
    /// <returns>Returns an array of transactions associated with an array of address. Limited to 20 items per request.</returns>
    Task<TransactionHistories?> GetElectrumXTransactionHistoryAsync(string[] addresses);

    /// <summary>
    ///     ElectrumX / Fulcrum - Get transaction details for a TXID
    /// </summary>
    /// <param name="txid">txid</param>
    /// <returns>Returns an object with transaction details of the TXID</returns>
    Task<TransactionDetails?> GetElectrumXTransactionDetailsAsync(string txid);

    /// <summary>
    ///     ElectrumX / Fulcrum - Get transaction details for an array of TXIDs
    /// </summary>
    /// <param name="txIds">txIds</param>
    /// <returns>Returns an array of objects with transaction details of an array of TXIDs. Limited to 20 items per request.</returns>
    Task<TransactionsDetail?> GetElectrumXTransactionDetailsAsync(string[] txIds);


    /// <summary>
    ///     ElectrumX / Fulcrum - Get transaction history for a single address.
    /// </summary>
    /// <param name="address">address</param>
    /// <returns>Returns an array of historical transactions associated with an address.</returns>
    Task<TransactionHistorySingle?> GetElectrumXTransactionHistoryAsync(string address);

    /// <summary>
    ///     ElectrumX / Fulcrum - Get unconfirmed utxos for a single address.
    /// </summary>
    /// <param name="address">address</param>
    /// <returns>Returns an object with unconfirmed UTXOs associated with an address.</returns>
    Task<UnconfirmedSingleUtxos?> GetUnConfirmedAsync(string address);

    /// <summary>
    ///     ElectrumX / Fulcrum - Get unconfirmed utxos for an array of addresses.
    /// </summary>
    /// <param name="addresses">addresses</param>
    /// <returns>
    ///     Returns an array of objects with unconfirmed UTXOs associated with an address. Limited to 20 items per
    ///     request.
    /// </returns>
    Task<UnconfirmedUtxos?> GetUnConfirmedAsync(string[] addresses);

    /// <summary>
    ///     ElectrumX / Fulcrum - Get utxos for an array of addresses.
    /// </summary>
    /// <param name="addresses">addresses</param>
    /// <returns>Returns an array of objects with UTXOs associated with an address. Limited to 20 items per request.</returns>
    Task<UtxosInfo?> GetUTxosAsync(string[] addresses);

    /// <summary>
    ///     ElectrumX / Fulcrum - Get utxos for a single address.
    /// </summary>
    /// <param name="address">address</param>
    /// <returns>Returns an object with UTXOs associated with an address.</returns>
    Task<SingleUtxos?> GetUTxosAsync(string address);
}