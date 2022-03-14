namespace Cash.NetCore.Models.Request.BlockChain;

/// <summary>
///     TransactionOutputRequest
/// </summary>
public class TransactionOutputRequest
{
    /// <summary>
    ///     Transaction id (required)
    /// </summary>
    [JsonPropertyName("txid")]
    public string? TxId { get; set; }

    /// <summary>
    ///     Output number (required)
    /// </summary>
    [JsonPropertyName("vout")]
    public int Vout { get; set; }

    /// <summary>
    ///     Check mempool or not (optional)
    /// </summary>
    [JsonPropertyName("mempool")]
    public bool Mempool { get; set; }
}