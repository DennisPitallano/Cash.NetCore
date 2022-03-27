using Cash.NetCore.Models.Response.BlockChain;
using Cash.NetCore.Models.Response.ElectrumX;

namespace Cash.NetCore.Models.Response.PsfSlp;

/// <summary>
///     PsfSlpTransactionData
/// </summary>
public class PsfSlpTransaction
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("txData")]
    public PsfSlpTransactionData? TxData { get; set; }
}

/// <summary>
///     PsfSlpTransactionData
/// </summary>
public class PsfSlpTransactionData
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
    public IEnumerable<PsfSlpTransactionDataVin>? Vin { get; set; }

    /// <summary>
    ///     vout
    /// </summary>
    [JsonPropertyName("vout")]
    public IEnumerable<PsfSlpTransactionDataVout>? Vout { get; set; }

    /// <summary>
    ///     blockheight
    /// </summary>
    [JsonPropertyName("blockheight")]
    public long BlockHeight { get; set; }

    /// <summary>
    ///     isSlpTx
    /// </summary>
    [JsonPropertyName("isSlpTx")]
    public bool IsSlpTx { get; set; }

    /// <summary>
    ///     tokenTxType
    /// </summary>
    [JsonPropertyName("tokenTxType")]
    public string? TokenTxType { get; set; }

    /// <summary>
    ///     tokenId
    /// </summary>
    [JsonPropertyName("tokenId")]
    public string? TokenId { get; set; }

    /// <summary>
    ///     tokenType
    /// </summary>
    [JsonPropertyName("tokenType")]
    public int TokenType { get; set; }

    /// <summary>
    ///     tokenTicker
    /// </summary>
    [JsonPropertyName("tokenTicker")]
    public string? TokenTicker { get; set; }

    /// <summary>
    ///     tokenName
    /// </summary>
    [JsonPropertyName("tokenName")]
    public string? TokenName { get; set; }

    /// <summary>
    ///     tokenDecimals
    /// </summary>
    [JsonPropertyName("tokenDecimals")]
    public int TokenDecimals { get; set; }

    /// <summary>
    ///     tokenUri
    /// </summary>
    [JsonPropertyName("tokenUri")]
    public string? TokenUri { get; set; }

    /// <summary>
    ///     tokenDocHash
    /// </summary>
    [JsonPropertyName("tokenDocHash")]
    public string? TokenDocHash { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("isValidSlp")]
    public bool IsValidSlp { get; set; }
}

/// <summary>
///     PsfSlpTransactionDataVout
/// </summary>
public class PsfSlpTransactionDataVout
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

    /// <summary>
    ///     tokenQtyStr
    /// </summary>
    [JsonPropertyName("tokenQtyStr")]
    public string? TokenQtyStr { get; set; }

    /// <summary>
    ///     tokenQty
    /// </summary>
    [JsonPropertyName("tokenQty")]
    public long? TokenQty { get; set; }
}

/// <summary>
///     PsfSlpTransactionDataVin
/// </summary>
public class PsfSlpTransactionDataVin
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
    ///     Address
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    ///     value
    /// </summary>
    [JsonPropertyName("value")]
    public decimal Value { get; set; }

    /// <summary>
    ///     tokenQtyStr
    /// </summary>
    [JsonPropertyName("tokenQtyStr")]
    public string? TokenQtyStr { get; set; }

    /// <summary>
    ///     tokenQty
    /// </summary>
    [JsonPropertyName("tokenQty")]
    public long? TokenQty { get; set; }

    /// <summary>
    ///     tokenId
    /// </summary>
    [JsonPropertyName("tokenId")]
    public string? TokenId { get; set; }
}