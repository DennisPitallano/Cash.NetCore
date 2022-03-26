namespace Cash.NetCore.Models.Response.Encryption;

/// <summary>
/// 
/// </summary>
public  class AddressPublicKey
{
    /// <summary>
    ///     success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    
    /// <summary>
    /// publicKey
    /// </summary>
    [JsonPropertyName("publicKey")]
    public string? PublicKey { get; set; }
}