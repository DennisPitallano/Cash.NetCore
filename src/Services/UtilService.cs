using System.Net.Http.Json;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Response.Util;

namespace Cash.NetCore.Services;

/// <summary>
/// UtilService
/// </summary>
public class UtilService: BaseHttpClient, IUtilService  
{
    private readonly string _cashModule;

    /// <inheritdoc />
    public UtilService(HttpClient cashHttpClient, CashConfiguration cashConfiguration) : base(cashHttpClient,
        cashConfiguration)
    {
        _cashModule = CashModule.Util;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<AddressInfo>?> ValidateAddressesAsync(string[] addresses)
    {
        var url = $"{_cashModule}"
            .AddParam(UtilModuleAction.ValidateAddress);
        using var response = await CashHttpClient.PostAsJsonAsync(url, new
            {
                addresses
            })
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<IEnumerable<AddressInfo>>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<AddressInfo?> ValidateAddressAsync(string address)
    {
        var queryParameters = $"{_cashModule}".AddParam(UtilModuleAction.ValidateAddress)
            .AddParam(address);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<AddressInfo>(responseStream);
        return result;
    }
}