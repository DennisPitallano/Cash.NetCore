namespace Cash.NetCore.Models.Response.BlockChain;

/// <summary>
///     MempoolInfo
/// </summary>
public class MempoolInfo
{
    /// <summary>
    ///    Loaded
    /// </summary>
    [JsonPropertyName("loaded")]
    public bool Loaded { get; set; }

    /// <summary>
    ///     Number of transactions in the mempool
    /// </summary>
    [JsonPropertyName("size")]
    public int Size { get; set; }
    
    /// <summary>
    ///     Size of the mempool in bytes
    /// </summary>
    [JsonPropertyName("bytes")]
    public long MempoolBytes { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("usage")]
    public long Usage { get; set; }
    
    /// <summary>
    ///     Number of transactions in the mempool that are not confirmed and not in the mempool
    /// </summary>
    [JsonPropertyName("maxmempool")]
    public int MaxMempoolBytes { get; set; }

    /// <summary>
    /// minrelaytxfee
    /// </summary>
    [JsonPropertyName("mempoolminfee")]
    public decimal Mempoolminfee { get; set; }

    /// <summary>
    /// minrelaytxfee
    /// </summary>
    [JsonPropertyName("minrelaytxfee")]
    public decimal Minrelaytxfee { get; set; }
    
}