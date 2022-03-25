namespace Cash.NetCore.Models.Response.BlockChain;

/// <summary>
///     MempoolEntry
/// </summary>
public class MempoolEntry
{
    /// <summary>
    ///     fees
    /// </summary>
    [JsonPropertyName("fees")]
    public Fees? Fees { get; set; }

    /// <summary>
    ///     size
    /// </summary>
    [JsonPropertyName("size")]
    public long Size { get; set; }

    /// <summary>
    ///     time
    /// </summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }

    /// <summary>
    ///     height
    /// </summary>
    [JsonPropertyName("height")]
    public long Height { get; set; }

    /// <summary>
    ///     depends
    /// </summary>
    [JsonPropertyName("depends")]
    public List<string>? Depends { get; set; }

    /// <summary>
    ///     spentby
    /// </summary>
    [JsonPropertyName("spentby")]
    public List<string>? SpentBy { get; set; }
}

/// <summary>
///     Fees
/// </summary>
public class Fees
{
    /// <summary>
    ///     base
    /// </summary>
    [JsonPropertyName("base")]
    public decimal Base { get; set; }

    /// <summary>
    ///     modified
    /// </summary>
    [JsonPropertyName("modified")]
    public decimal Modified { get; set; }
}