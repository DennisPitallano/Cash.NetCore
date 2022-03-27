namespace Cash.NetCore.Models.Response.PsfSlp;

/// <summary>
///     PsfSlpBalance
/// </summary>
public class PsfSlpBalance
{
    /// <summary>
    ///     balance
    /// </summary>
    [JsonPropertyName("balance")]
    public PsfSlpBalanceInfo? Balance { get; set; }
}

/// <summary>
/// </summary>
public class PsfSlpBalanceInfo
{
    /// <summary>
    ///     utxos
    /// </summary>
    [JsonPropertyName("utxos")]
    public IEnumerable<PsfSlpBalanceUtxos>? UTxos { get; set; }

    /// <summary>
    ///     utxos
    /// </summary>
    [JsonPropertyName("txs")]
    public IEnumerable<PsfSlpTxs>? Txs { get; set; }

    /// <summary>
    ///     balances
    /// </summary>
    [JsonPropertyName("balances")]
    public IEnumerable<PsfSlpBalanceDetail>? Balances { get; set; }
}

/// <summary>
///     PsfSlpBalanceDetail
/// </summary>
public class PsfSlpBalanceDetail
{
    /// <summary>
    ///     token_id
    /// </summary>
    [JsonPropertyName("tokenId")]
    public string? TokenId { get; set; }

    /// <summary>
    ///     qty
    /// </summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }
}

/// <summary>
///     PsfSlpTxs
/// </summary>
public class PsfSlpTxs
{
    /// <summary>
    ///     txid
    /// </summary>
    [JsonPropertyName("txid")]
    public string? Txid { get; set; }

    /// <summary>
    ///     height
    /// </summary>
    [JsonPropertyName("height")]
    public long Height { get; set; }
}

/// <summary>
///     PsfSlpBalanceUtxos
/// </summary>
public class PsfSlpBalanceUtxos
{
    /// <summary>
    ///     Txid
    /// </summary>
    [JsonPropertyName("txid")]
    public string? Txid { get; set; }

    /// <summary>
    ///     vout
    /// </summary>
    [JsonPropertyName("vout")]
    public int? Vout { get; set; }

    /// <summary>
    ///     Token
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    ///     tokenType
    /// </summary>
    [JsonPropertyName("tokenType")]
    public int TokenType { get; set; }

    /// <summary>
    ///     qty
    /// </summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>
    ///     tokenId
    /// </summary>
    [JsonPropertyName("tokenId")]
    public string? TokenId { get; set; }

    /// <summary>
    ///     address
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("decimals")]
    public int Decimals { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("effectiveQty")]
    public string? EffectiveQty { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("value")]
    public decimal Value { get; set; }
}