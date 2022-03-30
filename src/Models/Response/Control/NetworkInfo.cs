namespace Cash.NetCore.Models.Response.Control;

/// <summary>
///     NetworkInfo
/// </summary>
public class NetworkInfo
{
    /// <summary>
    ///     version
    /// </summary>
    [JsonPropertyName("version")]
    public long Version { get; set; }

    /// <summary>
    ///     subversion
    /// </summary>
    [JsonPropertyName("subversion")]
    public string? Subversion { get; set; }

    /// <summary>
    ///     protocolversion
    /// </summary>
    [JsonPropertyName("protocolversion")]
    public long ProtocolVersion { get; set; }

    /// <summary>
    ///     localservices
    /// </summary>
    [JsonPropertyName("localservices")]
    public string? LocalServices { get; set; }

    /// <summary>
    ///     localrelay
    /// </summary>
    [JsonPropertyName("localrelay")]
    public bool LocalRelay { get; set; }

    /// <summary>
    ///     timeoffset
    /// </summary>
    [JsonPropertyName("timeoffset")]
    public int TimeOffSet { get; set; }

    /// <summary>
    ///     networkactive
    /// </summary>
    [JsonPropertyName("networkactive")]
    public bool NetworkActive { get; set; }

    /// <summary>
    ///     connections
    /// </summary>
    [JsonPropertyName("connections")]
    public long Connections { get; set; }

    /// <summary>
    ///     networks
    /// </summary>
    [JsonPropertyName("networks")]
    public IEnumerable<Network>? Networks { get; set; }

    /// <summary>
    ///     relayfee
    /// </summary>
    [JsonPropertyName("relayfee")]
    public decimal RelayFee { get; set; }

    /// <summary>
    ///     excessutxocharge
    /// </summary>
    [JsonPropertyName("excessutxocharge")]
    public long ExcessUTxoCharge { get; set; }

    /// <summary>
    ///     localaddresses
    /// </summary>
    [JsonPropertyName("localaddresses")]
    public List<string>? LocalAddresses { get; set; }

    /// <summary>
    ///     warnings
    /// </summary>
    [JsonPropertyName("warnings")]
    public string? Warnings { get; set; }
}

/// <summary>
/// Network
/// </summary>
public class Network
{
    /// <summary>
    ///     name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    ///     limited
    /// </summary>
    [JsonPropertyName("limited")]
    public bool Limited { get; set; }

    /// <summary>
    ///     reachable
    /// </summary>
    [JsonPropertyName("reachable")]
    public bool Reachable { get; set; }

    /// <summary>
    ///     proxy
    /// </summary>
    [JsonPropertyName("proxy")]
    public string? Proxy { get; set; }

    /// <summary>
    ///     proxy_randomize_credentials
    /// </summary>
    [JsonPropertyName("proxy_randomize_credentials")]
    public bool ProxyRandomizeCredentials { get; set; }
}