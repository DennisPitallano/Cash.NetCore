namespace Cash.NetCore.Models.Response.PsfSlp;

/// <summary>
///     PsfSlpTokenStatus
/// </summary>
public class PsfSlpTokenStatus
{
    /// <summary>
    ///     tokenData
    /// </summary>
    [JsonPropertyName("tokenData")]
    public TokenData? TokenData { get; set; }
}

/// <summary>
/// </summary>
public class TokenData
{
    /// <summary>
    ///     Type
    /// </summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>
    ///     ticker
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; set; }

    /// <summary>
    ///     name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    ///     name
    /// </summary>
    [JsonPropertyName("tokenId")]
    public string? TokenId { get; set; }

    /// <summary>
    ///     documentUri
    /// </summary>
    [JsonPropertyName("documentUri")]
    public string? DocumentUri { get; set; }

    /// <summary>
    ///     documentHash
    /// </summary>
    [JsonPropertyName("documentHash")]
    public string? DocumentHash { get; set; }

    /// <summary>
    ///     decimals
    /// </summary>
    [JsonPropertyName("decimals")]
    public int Decimals { get; set; }

    /// <summary>
    ///     mintBatonIsActive
    /// </summary>
    [JsonPropertyName("mintBatonIsActive")]
    public bool MintBatonIsActive { get; set; }

    /// <summary>
    ///     tokensInCirculationBN
    /// </summary>
    [JsonPropertyName("tokensInCirculationBN")]
    public string? TokensInCirculationBn { get; set; }

    /// <summary>
    ///     tokensInCirculationStr
    /// </summary>
    [JsonPropertyName("tokensInCirculationStr")]
    public string? TokensInCirculationStr { get; set; }

    /// <summary>
    ///     blockCreated
    /// </summary>
    [JsonPropertyName("blockCreated")]
    public long BlockCreated { get; set; }

    /// <summary>
    ///     totalBurned
    /// </summary>
    [JsonPropertyName("totalBurned")]
    public string? TotalBurned { get; set; }

    /// <summary>
    ///     totalBurned
    /// </summary>
    [JsonPropertyName("totalMinted")]
    public string? TotalMinted { get; set; }
}