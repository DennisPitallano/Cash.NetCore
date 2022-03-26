using Cash.NetCore.Models.Response.Encryption;

namespace Cash.NetCore.Contracts;

/// <summary>
/// IEncryptionService
/// </summary>
public interface IEncryptionService
{
    Task<AddressPublicKey?> GetPublicKeyAsync(string address);
}