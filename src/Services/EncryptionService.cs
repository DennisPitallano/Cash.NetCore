using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Response.ElectrumX;
using Cash.NetCore.Models.Response.Encryption;

namespace Cash.NetCore.Services;

/// <inheritdoc cref="IEncryptionService" />
public class EncryptionService: BaseHttpClient, IEncryptionService
{
    private readonly string _cashModule;

    /// <inheritdoc />
    public EncryptionService(HttpClient cashHttpClient, CashConfiguration cashConfiguration) : base(cashHttpClient,
        cashConfiguration)
    {
        _cashModule = CashModule.Encryption;
    }

    /// <inheritdoc />
    public async Task<AddressPublicKey?> GetPublicKeyAsync(string address)
    {
        var queryParameters = $"{_cashModule}".AddParam(EncryptionModuleAction.PublicKey)
            .AddParam(address);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<AddressPublicKey>(responseStream);
        return result;
    }
}