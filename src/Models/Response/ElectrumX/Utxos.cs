namespace Cash.NetCore.Models.Response.ElectrumX;

/// <summary>
///     SingleUtxos
/// </summary>
public class SingleUtxos
{
    /// <summary>
    ///     success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("utxos")]
    public IEnumerable<UtxosDetail>? Utxos { get; set; }
}

/// <summary>
///     Utxos
/// </summary>
public class UtxosDetail
{
    /// <summary>
    ///     fee
    /// </summary>
    [JsonPropertyName("value")]
    public long Value { get; set; }

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
    /// <summary>
    ///     tx_pos
    /// </summary>
    [JsonPropertyName("tx_pos")]
    public int TxPos { get; set; }
}

/// <summary>
/// UtxosInfo
/// </summary>
public class UtxosInfo
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
    public IEnumerable<UtxosInfoData>? Utxos { get; set; }
}

/// <summary>
///     UtxosData
/// </summary>
public class UtxosInfoData
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("utxos")]
    public IEnumerable<UtxosDetail>? Utxos { get; set; }
    
    /// <summary>
    ///     address
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }
}
