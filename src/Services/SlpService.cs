using System.Net.Http.Json;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Response.Slp;

namespace Cash.NetCore.Services;

/// <summary>
/// 
/// </summary>
public class SlpService: BaseHttpClient, ISlpService
{
    private readonly string _cashModule;

    /// <inheritdoc />
    public SlpService(HttpClient cashHttpClient, CashConfiguration cashConfiguration) : base(cashHttpClient,
        cashConfiguration)
    {
        _cashModule = CashModule.Slp;
    }

    /// <inheritdoc />
    public async Task<SlpConvertAddress?> GetConvertAddressAsync(string address)
    {
         var queryParameters = $"{_cashModule}".AddParam(SlpModuleAction.SlpConvert)
            .AddParam(address);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<SlpConvertAddress>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<SlpConvertAddress>?> GetConvertAddressesAsync(string[] addresses)
    {
        var url = $"{_cashModule}"
            .AddParam(SlpModuleAction.SlpConvert);
        using var response = await CashHttpClient.PostAsJsonAsync(url, new
            {
                addresses
            })
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<IEnumerable<SlpConvertAddress>>(responseStream);
        return result;
    }
}