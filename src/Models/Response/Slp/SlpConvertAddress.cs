namespace Cash.NetCore.Models.Response.Slp;

/// <summary>
///     SLPConvertAddress
/// </summary>
public class SlpConvertAddress
{
    /// <summary>
    ///     cashAddress
    /// </summary>
    [JsonPropertyName("cashAddress")]
    public string? CashAddress { get; set; }

    /// <summary>
    ///     slpAddress
    /// </summary>
    [JsonPropertyName("slpAddress")]
    public string? SlpAddress { get; set; }

    /// <summary>
    ///     legacyAddress
    /// </summary>
    [JsonPropertyName("legacyAddress")]
    public string? LegacyAddress { get; set; }
}