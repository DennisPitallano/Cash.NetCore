namespace Cash.NetCore.Models.Response.BlockChain;

/// <summary>
/// </summary>
public class TransactionOutput
{
    /// <summary>
    ///     bestblock
    /// </summary>
    [JsonPropertyName("bestblock")]
    public string? BestBlock { get; set; }

    /// <summary>
    ///     confirmations
    /// </summary>
    [JsonPropertyName("confirmations")]
    public int Confirmations { get; set; }

    /// <summary>
    ///     value
    /// </summary>
    [JsonPropertyName("value")]
    public int Value { get; set; }

    /// <summary>
    ///     scriptPubKey
    /// </summary>
    [JsonPropertyName("scriptPubKey")]
    public ScriptPubKey? ScriptPubKey { get; set; }

    /// <summary>
    ///     coinbase
    /// </summary>
    [JsonPropertyName("coinbase")]
    public bool Coinbase { get; set; }
}

/// <summary>
///     ScriptPubKey
/// </summary>
public class ScriptPubKey
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
    public int ReqSigs { get; set; }

    /// <summary>
    ///     type
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    ///     addresses
    /// </summary>
    [JsonPropertyName("addresses")]
    public List<string>? Addresses { get; set; }
}