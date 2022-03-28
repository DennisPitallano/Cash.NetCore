namespace Cash.NetCore.Models.Response.Slp;

/// <summary>
///     SlpTokenWhitelist
/// </summary>
public class SlpTokenWhitelist
{
    /// <summary>
    ///     name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    ///     tokenId
    /// </summary>
    [JsonPropertyName("tokenId")]
    public string? TokenId { get; set; }
}