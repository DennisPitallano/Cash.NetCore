namespace Cash.NetCore.Models.Response.ElectrumX;

/// <summary>
///     BalanceInfo
/// </summary>
public class BalanceInfo
{
    /// <summary>
    /// success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    
    /// <summary>
    /// balance
    /// </summary>
    [JsonPropertyName("balance")]
    public Balance? Balance { get; set; }

    /// <summary>
    /// error
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

}

/// <summary>
/// Balance
/// </summary>
public class Balance
{
    /// <summary>
    ///     Confirmed
    /// </summary>
    [JsonPropertyName("confirmed")]
    public decimal Confirmed { get; set; }

    /// <summary>
    ///     Unconfirmed
    /// </summary>
    [JsonPropertyName("unconfirmed")]
    public decimal Unconfirmed { get; set; }
}