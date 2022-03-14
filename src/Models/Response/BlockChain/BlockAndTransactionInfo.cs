namespace Cash.NetCore.Models.Response.BlockChain;

/// <summary>
///     BlockAndTransactionInfo
/// </summary>
public class BlockAndTransactionInfo
{
    /// <summary>
    ///     hash
    /// </summary>
    [JsonPropertyName("hash")]
    public string? Hash { get; set; }

    /// <summary>
    ///     confirmations
    /// </summary>
    [JsonPropertyName("confirmations")]
    public long Confirmations { get; set; }

    /// <summary>
    ///     size
    /// </summary>
    [JsonPropertyName("size")]
    public long Size { get; set; }

    /// <summary>
    ///     height
    /// </summary>
    [JsonPropertyName("height")]
    public long Height { get; set; }

    /// <summary>
    ///     version
    /// </summary>
    [JsonPropertyName("version")]
    public int Version { get; set; }

    /// <summary>
    ///     versionHex
    /// </summary>
    [JsonPropertyName("versionHex")]
    public string? VersionHex { get; set; }

    /// <summary>
    ///     merkleroot
    /// </summary>
    [JsonPropertyName("merkleroot")]
    public string? Merkleroot { get; set; }

    /// <summary>
    ///     tx
    /// </summary>
    [JsonPropertyName("tx")]
    public IEnumerable<BlockTransactionInfo>? Tx { get; set; }

    /// <summary>
    ///     time
    /// </summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }

    /// <summary>
    ///     mediantime
    /// </summary>
    [JsonPropertyName("mediantime")]
    public long Mediantime { get; set; }

    /// <summary>
    ///     mediantime
    /// </summary>
    [JsonPropertyName("nonce")]
    public long Nonce { get; set; }

    /// <summary>
    ///     bits
    /// </summary>
    [JsonPropertyName("bits")]
    public string? Bits { get; set; }

    /// <summary>
    ///     difficulty
    /// </summary>
    [JsonPropertyName("difficulty")]
    public decimal Difficulty { get; set; }

    /// <summary>
    ///     chainwork
    /// </summary>
    [JsonPropertyName("chainwork")]
    public string? Chainwork { get; set; }

    /// <summary>
    ///     nTx
    /// </summary>
    [JsonPropertyName("nTx")]
    public long NTx { get; set; }

    /// <summary>
    ///     previousblockhash
    /// </summary>
    [JsonPropertyName("previousblockhash")]
    public string? Previousblockhash { get; set; }

    /// <summary>
    ///     nextblockhash
    /// </summary>
    [JsonPropertyName("nextblockhash")]
    public string? Nextblockhash { get; set; }
}

/// <summary>
///     TransactionInfo
/// </summary>
public class BlockTransactionInfo
{
    /// <summary>
    ///     txid
    /// </summary>
    [JsonPropertyName("txid")]
    public string? Txid { get; set; }

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
    ///     size
    /// </summary>
    [JsonPropertyName("size")]
    public long Size { get; set; }

    /// <summary>
    ///     locktime
    /// </summary>
    [JsonPropertyName("locktime")]
    public long Locktime { get; set; }

    /// <summary>
    ///     vin
    /// </summary>
    [JsonPropertyName("vin")]
    public IEnumerable<BlockTransactionInputInfo>? Vin { get; set; }

    /// <summary>
    ///     vout
    /// </summary>
    [JsonPropertyName("vout")]
    public IEnumerable<BlockTransactionOutputInfo>? Vout { get; set; }

    /// <summary>
    ///     hex
    /// </summary>
    [JsonPropertyName("hex")]
    public string? Hex { get; set; }
}

/// <summary>
///     BlockTransactionOutputInfo
/// </summary>
public class BlockTransactionOutputInfo
{
    /// <summary>
    ///     value
    /// </summary>
    [JsonPropertyName("value")]
    public decimal Value { get; set; }

    /// <summary>
    ///     n
    /// </summary>
    [JsonPropertyName("n")]
    public long N { get; set; }

    /// <summary>
    ///     scriptPubKey
    /// </summary>
    [JsonPropertyName("scriptPubKey")]
    public BlockTransactionOutputScriptPubKeyInfo? ScriptPubKey { get; set; }
}

/// <summary>
///     BlockTransactionOutputScriptPubKeyInfo
/// </summary>
public class BlockTransactionOutputScriptPubKeyInfo
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

    /// <summary>
    ///     reqSigs
    /// </summary>
    [JsonPropertyName("reqSigs")]
    public long ReqSigs { get; set; }

    /// <summary>
    ///     type
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    ///     addresses
    /// </summary>
    [JsonPropertyName("addresses")]
    public IEnumerable<string>? Addresses { get; set; }
}

/// <summary>
/// </summary>
public class BlockTransactionInputInfo
{
    /// <summary>
    ///     txid
    /// </summary>
    [JsonPropertyName("txid")]
    public string? Txid { get; set; }

    /// <summary>
    ///     vout
    /// </summary>
    [JsonPropertyName("vout")]
    public long Vout { get; set; }

    /// <summary>
    ///     scriptSig
    /// </summary>
    [JsonPropertyName("scriptSig")]
    public BlockTransactionInputScriptSigInfo? ScriptSig { get; set; }

    /// <summary>
    ///     sequence
    /// </summary>
    [JsonPropertyName("sequence")]
    public long Sequence { get; set; }
}

/// <summary>
///     BlockTransactionInputScriptSigInfo
/// </summary>
public class BlockTransactionInputScriptSigInfo
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