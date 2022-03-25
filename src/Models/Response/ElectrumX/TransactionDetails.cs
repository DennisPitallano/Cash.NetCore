using Cash.NetCore.Models.Response.BlockChain;

namespace Cash.NetCore.Models.Response.ElectrumX;

/// <summary>
///     TransactionDetails
/// </summary>
public class TransactionDetails
{
    /// <summary>
    ///     success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    ///     details
    /// </summary>
    [JsonPropertyName("details")]
    public TransactionDetailData? Details { get; set; }

    /// <summary>
    ///     error
    /// </summary>
    [JsonPropertyName("error")]
    public ErrorData? Error { get; set; }
}

/// <summary>
///     TransactionDetailData
/// </summary>
public class TransactionDetailData
{
    /// <summary>
    ///     blockhash
    /// </summary>
    [JsonPropertyName("blockhash")]
    public string? BlockHash { get; set; }

    /// <summary>
    ///     blocktime
    /// </summary>
    [JsonPropertyName("blocktime")]
    public long BlockTime { get; set; }

    /// <summary>
    ///     confirmations
    /// </summary>
    [JsonPropertyName("confirmations")]
    public long Confirmations { get; set; }

    /// <summary>
    ///     hash
    /// </summary>
    [JsonPropertyName("hash")]
    public string? Hash { get; set; }

    /// <summary>
    ///     hex
    /// </summary>
    [JsonPropertyName("hex")]
    public string? Hex { get; set; }

    /// <summary>
    ///     locktime
    /// </summary>
    [JsonPropertyName("locktime")]
    public long LockTime { get; set; }

    /// <summary>
    ///     Size
    /// </summary>
    [JsonPropertyName("size")]
    public long Size { get; set; }

    /// <summary>
    ///     time
    /// </summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }

    /// <summary>
    ///     txid
    /// </summary>
    [JsonPropertyName("txid")]
    public string? TxId { get; set; }

    /// <summary>
    ///     version
    /// </summary>
    [JsonPropertyName("version")]
    public long Version { get; set; }

    /// <summary>
    ///     vin
    /// </summary>
    [JsonPropertyName("vin")]
    public IEnumerable<TransactionDetailVin>? Vin { get; set; }

    /// <summary>
    ///     vout
    /// </summary>
    [JsonPropertyName("vout")]
    public IEnumerable<TransactionDetailVout>? Vout { get; set; }
}

/// <summary>
///     TransactionDetailVout
/// </summary>
public class TransactionDetailVout
{
    /// <summary>
    ///     n
    /// </summary>
    [JsonPropertyName("n")]
    public int N { get; set; }

    /// <summary>
    ///     scriptPubKey
    /// </summary>
    [JsonPropertyName("scriptPubKey")]
    public ScriptPubKey? ScriptPubKey { get; set; }

    /// <summary>
    ///     value
    /// </summary>
    [JsonPropertyName("value")]
    public decimal Value { get; set; }
}

/// <summary>
///     TransactionDetailVin
/// </summary>
public class TransactionDetailVin
{
    /// <summary>
    ///     scriptSig
    /// </summary>
    [JsonPropertyName("scriptSig")]
    public ScriptSig? ScriptSig { get; set; }

    /// <summary>
    ///     sequence
    /// </summary>
    [JsonPropertyName("sequence")]
    public long Sequence { get; set; }

    /// <summary>
    ///     txid
    /// </summary>
    [JsonPropertyName("txid")]
    public string? Txid { get; set; }

    /// <summary>
    ///     vout
    /// </summary>
    [JsonPropertyName("vout")]
    public int Vout { get; set; }
}

/// <summary>
///     ScriptSig
/// </summary>
public class ScriptSig
{
    /// <summary>
    ///     asm
    /// </summary>
    [JsonPropertyName("asm")]
    public string? Asm { get; set; }

    /// <summary>
    ///     hex
    /// </summary>
    [JsonPropertyName("hex")]
    public string? Hex { get; set; }
}

/// <summary>
/// </summary>
public class ErrorData
{
    /// <summary>
    ///     success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    ///     error
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }
}

/// <summary>
///     TransactionsDetail
/// </summary>
public class TransactionsDetail
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
    public IEnumerable<TransactionsDetailData>? Transactions { get; set; }
}

/// <summary>
///     TransactionsDetailData
/// </summary>
public class TransactionsDetailData
{
    /// <summary>
    ///     details
    /// </summary>
    [JsonPropertyName("details")]
    public TransactionDetailData? Details { get; set; }

    /// <summary>
    ///     txid
    /// </summary>
    [JsonPropertyName("txid")]
    public string? Txid { get; set; }
}