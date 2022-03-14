namespace Cash.NetCore.Models.Response.BlockChain;

/// <summary>
/// BlockChainInfo
/// </summary>
public class BlockChainInfo
{
    /// <summary>
    ///     chain
    /// </summary>
    [JsonPropertyName("chain")]
    public string? Chain { get; set; }

    /// <summary>
    ///     blocks
    /// </summary>
    [JsonPropertyName("blocks")]
    public long Blocks { get; set; }

    /// <summary>
    ///     headers
    /// </summary>
    [JsonPropertyName("headers")]
    public long Headers { get; set; }

    /// <summary>
    ///     bestblockhash
    /// </summary>
    [JsonPropertyName("bestblockhash")]
    public string? BestBlockHash { get; set; }

    /// <summary>
    ///     difficulty
    /// </summary>
    [JsonPropertyName("difficulty")]
    public decimal Difficulty { get; set; }

    /// <summary>
    ///     mediantime
    /// </summary>
    [JsonPropertyName("mediantime")]
    public long MedianTime { get; set; }

    /// <summary>
    ///     verificationprogress
    /// </summary>
    [JsonPropertyName("verificationprogress")]
    public decimal VerificationProgress { get; set; }

    /// <summary>
    ///     Initialblockdownload
    /// </summary>
    [JsonPropertyName("initialblockdownload")]
    public bool Initialblockdownload { get; set; }

    /// <summary>
    ///     chainwork
    /// </summary>
    [JsonPropertyName("chainwork")]
    public string? ChainWork { get; set; }

    /// <summary>
    ///     size_on_disk
    /// </summary>
    [JsonPropertyName("size_on_disk")]
    public long SizeOnDisk { get; set; }

    [JsonPropertyName("pruned")] public bool Pruned { get; set; }

    /// <summary>
    ///     softforks
    /// </summary>
    [JsonPropertyName("softforks")]
    public IEnumerable<SoftForks>? SoftForks { get; set; }

    /// <summary>
    ///     bip9softforks
    /// </summary>
    public IEnumerable<Bip9SoftForks>? Bip9SoftForks { get; set; }
}

/// <summary>
///     Bip9SoftForks
/// </summary>
public class Bip9SoftForks
{
    /// <summary>
    ///     id
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    ///     version
    /// </summary>
    [JsonPropertyName("version")]
    public long Version { get; set; }

    /// <summary>
    ///     reject
    /// </summary>
    [JsonPropertyName("reject")]
    public bool Reject { get; set; }
}

/// <summary>
///     SoftForks
/// </summary>
public class SoftForks
{
    /// <summary>
    ///     id
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    ///     version
    /// </summary>
    [JsonPropertyName("version")]
    public long Version { get; set; }

    /// <summary>
    ///     reject
    /// </summary>
    [JsonPropertyName("reject")]
    public bool Reject { get; set; }
}

/// <summary>
///     Reject
/// </summary>
public class Reject
{
    /// <summary>
    ///     status
    /// </summary>
    [JsonPropertyName("status")]
    public bool Status { get; set; }

    /// <summary>
    ///     reason
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    ///     hash
    /// </summary>
    [JsonPropertyName("hash")]
    public string? Hash { get; set; }

    /// <summary>
    ///     height
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }
}