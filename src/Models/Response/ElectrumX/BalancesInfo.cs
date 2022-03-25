namespace Cash.NetCore.Models.Response.ElectrumX;

/// <summary>
/// </summary>
public class BalancesInfo
{
    /// <summary>
    ///     success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    ///     balances
    /// </summary>
    [JsonPropertyName("balances")]
    public IEnumerable<BalancesInfoData>? BalancesInfoData { get; set; }

    /// <summary>
    /// error
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }
}

/// <summary>
///     BalancesInfoData
/// </summary>
public class BalancesInfoData
{
    /// <summary>
    ///     success
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    ///     balance
    /// </summary>
    [JsonPropertyName("balance")]
    public Balance? Balance { get; set; }
}