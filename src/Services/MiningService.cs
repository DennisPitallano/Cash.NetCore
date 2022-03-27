using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Response.Mining;

namespace Cash.NetCore.Services;

/// <inheritdoc cref="IMiningService" />
public class MiningService : BaseHttpClient, IMiningService
{
    private readonly string _cashModule;

    /// <inheritdoc />
    public MiningService(HttpClient cashHttpClient, CashConfiguration cashConfiguration) : base(cashHttpClient,
        cashConfiguration)
    {
        _cashModule = CashModule.Mining;
    }

    /// <inheritdoc />
    public async Task<decimal> GetNetworkHashpsAsync(int nblocks, int nheight)
    {
        var queryParameters = $"{_cashModule}".AddParam(MiningModuleAction.GetNetworkHashps)
            .AddQueryString("nblocks", nblocks).AddQueryString("height", nheight);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<decimal>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<MiningInfo?> GetMiningInfoAsync()
    {
        var queryParameters = $"{_cashModule}".AddParam(MiningModuleAction.GetMiningInfo);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<MiningInfo>(responseStream);
        return result;
    }
}