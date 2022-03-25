namespace Cash.NetCore.Models.Response.ElectrumX;

/// <summary>
/// </summary>
public class TransactionHistories
{
    /// <summary>
    ///     success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    ///     transactions
    /// </summary>
    [JsonPropertyName("transactions")]
    public IEnumerable<TransactionHistory>? Transactions { get; set; }

    /// <summary>
    /// error
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }
}

/// <summary>
///     TransactionHistory
/// </summary>
public class TransactionHistory
{
    /// <summary>
    ///     transactions
    /// </summary>
    [JsonPropertyName("transactions")]
    public IEnumerable<TransactionHistoryData>? Transactions { get; set; }

    /// <summary>
    ///     address 
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }
}

/// <summary>
///     TransactionHistoryData
/// </summary>
public class TransactionHistoryData
{
    /// <summary>
    ///     height
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }

    /// <summary>
    ///     tx_hash
    /// </summary>
    [JsonPropertyName("tx_hash")]
    public string? TxHash { get; set; }
}

/// <summary>
///     TransactionHistory
/// </summary>
public class TransactionHistorySingle
{
    /// <summary>
    ///     transactions
    /// </summary>
    [JsonPropertyName("transactions")]
    public IEnumerable<TransactionHistoryData>? Transactions { get; set; }

    /// <summary>
    ///     success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    
    /// <summary>
    /// error
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }
}
