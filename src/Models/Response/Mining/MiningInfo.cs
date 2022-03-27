namespace Cash.NetCore.Models.Response.Mining;

/// <summary>
///     MiningInfo
/// </summary>
public class MiningInfo
{
    /// <summary>
    ///     Blocks
    /// </summary>
    [JsonPropertyName("blocks")]
    public long Blocks { get; set; }

    /// <summary>
    ///     CurrentBlockSize
    /// </summary>
    [JsonPropertyName("currentblocksize")]
    public long CurrentBlockSize { get; set; }

    /// <summary>
    ///     CurrentBlockTx
    /// </summary>
    [JsonPropertyName("currentblocktx")]
    public long CurrentBlockTx { get; set; }

    /// <summary>
    ///     Difficulty
    /// </summary>
    [JsonPropertyName("difficulty")]
    public decimal Difficulty { get; set; }

    /// <summary>
    ///     networkhashps
    /// </summary>
    [JsonPropertyName("networkhashps")]
    public long Networkhashps { get; set; }


    /// <summary>
    ///     pooledtx
    /// </summary>
    [JsonPropertyName("pooledtx")]
    public long Pooledtx { get; set; }

    /// <summary>
    ///     chain
    /// </summary>
    [JsonPropertyName("chain")]
    public string? Chain { get; set; }

    /// <summary>
    ///     warnings
    /// </summary>
    [JsonPropertyName("warnings")]
    public string? Warnings { get; set; }
}