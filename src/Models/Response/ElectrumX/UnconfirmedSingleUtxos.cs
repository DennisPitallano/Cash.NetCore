namespace Cash.NetCore.Models.Response.ElectrumX;

/// <summary>
///     UnconfirmedSingleUtxos
/// </summary>
public class UnconfirmedSingleUtxos
{
    /// <summary>
    ///     success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("utxos")]
    public IEnumerable<Utxos>? Utxos { get; set; }
}

/// <summary>
///     Utxos
/// </summary>
public class Utxos
{
    /// <summary>
    ///     fee
    /// </summary>
    [JsonPropertyName("fee")]
    public long Fee { get; set; }

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

public class UnconfirmedUtxos
{
    /// <summary>
    ///     success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    ///     utxos
    /// </summary>
    [JsonPropertyName("utxos")]
    public IEnumerable<UtxosData>? Utxos { get; set; }
}

/// <summary>
///     UtxosData
/// </summary>
public class UtxosData
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("utxos")]
    public IEnumerable<Utxos>? Utxos { get; set; }
    
    /// <summary>
    ///     address
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }
}