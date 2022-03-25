using Cash.NetCore.Models.Request.BlockChain;
using Cash.NetCore.Models.Response.BlockChain;
using Cash.NetCore.Models.Response.Control;

namespace Cash.NetCore.Contracts;

/// <summary>
///     IBlockChainService
/// </summary>
public interface IBlockChainService
{
    /// <summary>
    ///     Get Block Count
    /// </summary>
    /// <returns>Returns the number of blocks in the longest blockchain.</returns>
    Task<long> GetBlockCountAsc();

    /// <summary>
    ///     Get Chain Tips
    /// </summary>
    /// <returns>
    ///     Return information about all known tips in the block tree, including the main chain as well as orphaned
    ///     branches.
    /// </returns>
    Task<IEnumerable<ChainTip>?> GetChainTipsAsc();

    //TODO Get Mempool Ancestors
    //Task<IEnumerable<MempoolTransaction>?> GetMempoolAncestoresAsc();

    //TODO Blockchain - Get Tx Out Proof

    /// <summary>
    ///     Block chain - Get Tx Out
    /// </summary>
    /// <param name="txId"> Transaction id (required) </param>
    /// <param name="n">Output number (required)</param>
    /// <param name="includeMempool"> Check mempool or not (optional) </param>
    /// <returns>Returns details about an unspent transaction output.</returns>
    Task<TransactionOutput?> GetTxOutAsync(string txId, int n, bool includeMempool);


    /// <summary>
    ///     Block chain - Get Tx Out
    /// </summary>
    /// <param name="param">TransactionOutputRequest</param>
    /// <returns>Returns details about an unspent transaction output.</returns>
    Task<TransactionOutput?> GetTxOutAsync(TransactionOutputRequest param);


    /// <summary>
    ///     Blockchain - Get best block hash
    /// </summary>
    /// <returns>Returns the hash of the best (tip) block in the longest block chain.</returns>
    Task<string?> GetBestBlockHashAsync();

    /// <summary>
    ///     Blockchain - Get block details
    ///     verbosity 0 (hex-encoded)
    /// </summary>
    /// <param name="blockhash"></param>
    /// <returns>Returns data from the block hash.</returns>
    Task<string?> GetBlockAsync(string blockhash);

    /// <summary>
    ///     Blockchain - Get block details
    ///     verbosity 1 (object)
    /// </summary>
    /// <param name="blockhash"></param>
    /// <returns>Returns block details</returns>
    Task<BlockInfo?> GetBlockVerbosity1Async(string blockhash);

    /// <summary>
    ///     Blockchain - Get block details
    ///     verbosity 2 (object with transaction info)
    /// </summary>
    /// <param name="blockhash"></param>
    /// <returns></returns>
    Task<BlockAndTransactionInfo?> GetBlockVerbosity2Async(string blockhash);

    /// <summary>
    ///     Blockchain - Get block hash
    /// </summary>
    /// <param name="height">Block height (required)</param>
    /// <returns>Returns the hash of a block, given its block height.</returns>
    Task<string?> GetBlockHashAsync(string height);

    /// <summary>
    ///     Blockchain - Get blockchain info
    /// </summary>
    /// <returns>Returns an object containing various state info regarding blockchain processing.</returns>
    Task<BlockChainInfo?> GetBlockChainInfoAsync();

    /// <summary>
    ///     Blockchain - Get difficulty
    /// </summary>
    /// <returns>Get the current difficulty value, used to regulate mining power on the network.</returns>
    Task<decimal?> GetDifficultyAsync();

    /// <summary>
    ///     Blockchain - Get mempool info
    /// </summary>
    /// <returns>Returns details on the active state of the TX memory pool.</returns>
    Task<MempoolInfo?> GetMempoolInfoAsync();

    /// <summary>
    ///     Blockchain - Get block header
    /// </summary>
    /// <param name="blockhash"></param>
    /// <returns>
    ///     If verbose is false (default), returns a string that is serialized, hex-encoded data for blockheader 'hash'. If
    ///     verbose is true, returns an Object with information about blockheader hash
    /// </returns>
    Task<string?> GetBlockHeaderAsync(string blockhash);

    /// <summary>
    ///     Blockchain - Get single block header
    /// </summary>
    /// <param name="blockhash"></param>
    /// <returns>
    ///     If verbose is false (default), returns a string that is serialized, hex-encoded data for blockheader 'hash'. If
    ///     verbose is true, returns an Object with information about blockheader hash
    /// </returns>
    Task<BlockHeader?> GetBlockHeaderVerboseAsync(string blockhash);

    /// <summary>
    ///     Blockchain - Get single block header
    /// </summary>
    /// <returns>
    ///     If verbose is false (default), returns a string that is serialized, hex-encoded data for blockheader 'hash'. If
    ///     verbose is true, returns an Object with information about blockheader hash
    /// </returns>
    Task<IEnumerable<string>?> GetBlockHeadersAsync(string[] blockhashes);

    /// <summary>
    ///     Blockchain - Get multiple block headers
    /// </summary>
    /// <returns>
    ///     If verbose is false (default), returns a string that is serialized, hex-encoded data for blockheader 'hash'. If
    ///     verbose is true, returns an Object with information about blockheader hash
    /// </returns>
    Task<IEnumerable<BlockHeader>?> GetBlockHeadersVerboseAsync(string[] blockhashes);
}