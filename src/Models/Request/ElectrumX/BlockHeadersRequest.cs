namespace Cash.NetCore.Models.Request.ElectrumX;

/// <summary>
/// BlockHeadersRequest
/// </summary>
public class BlockHeadersRequest
{
    /// <summary>
    /// height
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }
    /// <summary>
    /// count
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }
}