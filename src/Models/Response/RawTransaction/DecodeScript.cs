namespace Cash.NetCore.Models.Response.RawTransaction;

/// <summary>
///     DecodeScript
/// </summary>
public class DecodeScript
{
    /// <summary>
    ///     asm
    /// </summary>
    [JsonPropertyName("asm")]
    public string? Asm { get; set; }

    /// <summary>
    ///     p2sh
    /// </summary>
    [JsonPropertyName("p2sh")]
    public string? P2Sh { get; set; }

    /// <summary>
    ///     type
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}