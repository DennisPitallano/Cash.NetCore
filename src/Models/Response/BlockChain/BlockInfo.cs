namespace Cash.NetCore.Models.Response.BlockChain;

/// <summary>
///     BlockInfo
/// </summary>
public class BlockInfo
{
    /// <summary>
    ///     hash
    /// </summary>
    [JsonPropertyName("hash")]
    public string? Hash { get; set; }

    /// <summary>
    ///     confirmations
    /// </summary>
    [JsonPropertyName("confirmations")]
    public long Confirmations { get; set; }

    /// <summary>
    ///     size
    /// </summary>
    [JsonPropertyName("size")]
    public int Size { get; set; }

    /// <summary>
    ///     height
    /// </summary>
    [JsonPropertyName("height")]
    public long Height { get; set; }

    /// <summary>
    ///     version
    /// </summary>
    [JsonPropertyName("version")]
    public long Version { get; set; }

    /// <summary>
    /// versionHex
    /// </summary>
    [JsonPropertyName("versionHex")]
    public string? VersionHex { get; set; }

    /// <summary>
    ///     merkleroot
    /// </summary>
    [JsonPropertyName("merkleroot")]
    public string? Merkleroot { get; set; }

    /// <summary>
    ///     tx
    /// </summary>
    [JsonPropertyName("tx")]
    public List<string>? Tx { get; set; }

    /// <summary>
    ///     time
    /// </summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }

    /// <summary>
    ///     mediantime
    /// </summary>
    [JsonPropertyName("mediantime")]
    public int Mediantime { get; set; }

    /// <summary>
    ///     mediantime
    /// </summary>
    [JsonPropertyName("nonce")]
    public long Nonce { get; set; }

    /// <summary>
    ///     bits
    /// </summary>
    [JsonPropertyName("bits")]
    public string? Bits { get; set; }

    /// <summary>
    ///     difficulty
    /// </summary>
    [JsonPropertyName("difficulty")]
    public decimal Difficulty { get; set; }

    /// <summary>
    ///     chainwork
    /// </summary>
    [JsonPropertyName("chainwork")]
    public string? Chainwork { get; set; }

    /// <summary>
    ///     nTx
    /// </summary>
    [JsonPropertyName("nTx")]
    public long NTx { get; set; }

    /// <summary>
    ///     previousblockhash
    /// </summary>
    [JsonPropertyName("previousblockhash")]
    public string? Previousblockhash { get; set; }

    /// <summary>
    ///     nextblockhash
    /// </summary>
    [JsonPropertyName("nextblockhash")]
    public string? Nextblockhash { get; set; }
}