namespace Cash.NetCore.Models.Response.ElectrumX;

/// <summary>
///     BlockHeaderCount
/// </summary>
public class BlockHeaderCount
{
    /// <summary>
    /// success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    /// <summary>
    /// headers
    /// </summary>
    [JsonPropertyName("headers")]
    public IEnumerable<string>? Headers { get; set; }
    
    /// <summary>
    /// error
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }
}

/// <summary>
/// BlockHeaderHeightCount
/// </summary>
public class BlockHeaderHeightsCounts
{
    /// <summary>
    /// success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    /// <summary>
    /// headers
    /// </summary>
    [JsonPropertyName("headers")]
    public IEnumerable<BlockHeaderHeightCount>? Headers { get; set; }

    /// <summary>
    /// error
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }
}

/// <summary>
/// BlockHeaderHeightCount
/// </summary>
public class BlockHeaderHeightCount
{
    /// <summary>
    /// headers
    /// </summary>
    [JsonPropertyName("headers")]
    public IEnumerable<string>? Headers { get; set; }
}