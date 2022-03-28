using Cash.NetCore.Models.Response.BlockChain;
using Cash.NetCore.Models.Response.ElectrumX;

namespace Cash.NetCore.Models.Response.RawTransaction;

/// <summary>
/// </summary>
public class RawTransaction
{
    /// <summary>
    ///     txid
    /// </summary>
    [JsonPropertyName("txid")]
    public string? TxId { get; set; }

    /// <summary>
    ///     hash
    /// </summary>
    [JsonPropertyName("hash")]
    public string? Hash { get; set; }

    /// <summary>
    ///     version
    /// </summary>
    [JsonPropertyName("version")]
    public long Version { get; set; }

    /// <summary>
    ///     Size
    /// </summary>
    [JsonPropertyName("size")]
    public long Size { get; set; }

    /// <summary>
    ///     locktime
    /// </summary>
    [JsonPropertyName("locktime")]
    public long LockTime { get; set; }

    /// <summary>
    ///     Vin
    /// </summary>
    [JsonPropertyName("vin")]
    public IEnumerable<RawTransactionVin>? RawTransactionVin { get; set; }

    /// <summary>
    ///     Vout
    /// </summary>
    [JsonPropertyName("vout")]
    public IEnumerable<RawTransactionVout>? RawTransactionVout { get; set; }

    /// <summary>
    ///     hex
    /// </summary>
    [JsonPropertyName("hex")]
    public string? Hex { get; set; }

    /// <summary>
    ///     blockhash
    /// </summary>
    [JsonPropertyName("blockhash")]
    public string? BlockHash { get; set; }

    /// <summary>
    ///     confirmations
    /// </summary>
    [JsonPropertyName("confirmations")]
    public long? Confirmations { get; set; }

    /// <summary>
    ///     time
    /// </summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>
    ///     blocktime
    /// </summary>
    [JsonPropertyName("blocktime")]
    public long? BlockTime { get; set; }
}

/// <summary>
///     RawTransactionVout
/// </summary>
public class RawTransactionVout
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
///     RawTransactionVin
/// </summary>
public class RawTransactionVin
{
    /// <summary>
    ///     txid
    /// </summary>
    [JsonPropertyName("txid")]
    public string? Txid { get; set; }

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
    ///     vout
    /// </summary>
    [JsonPropertyName("vout")]
    public int Vout { get; set; }

    /// <summary>
    ///     coinbase
    /// </summary>
    [JsonPropertyName("coinbase")]
    public string? Coinbase { get; set; }
}