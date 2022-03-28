namespace Cash.NetCore.Models.Response.Util;

/// <summary>
///     AddressInfo
/// </summary>
public class AddressInfo
{
    /// <summary>
    ///     isvalid
    /// </summary>
    [JsonPropertyName("isvalid")]
    public bool IsValid { get; set; }

    /// <summary>
    ///     address
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    ///     scriptPubKey
    /// </summary>
    [JsonPropertyName("scriptPubKey")]
    public string? ScriptPubKey { get; set; }

    /// <summary>
    ///     isscript
    /// </summary>
    [JsonPropertyName("isscript")]
    public bool IsScript { get; set; }
}