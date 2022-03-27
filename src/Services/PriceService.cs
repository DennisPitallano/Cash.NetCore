using Cash.NetCore.Extensions;

namespace Cash.NetCore.Services;

/// <summary>
/// PriceService
/// </summary>
public class PriceService: BaseHttpClient, IPriceService
{
    private readonly string _cashModule;

    /// <inheritdoc />
    public PriceService(HttpClient cashHttpClient, CashConfiguration cashConfiguration) : base(cashHttpClient,
        cashConfiguration)
    {
        _cashModule = CashModule.Price;
    }

    /// <inheritdoc />
    public async Task<IDictionary<string, string>?> GetRatesAsync()
    {
        var queryParameters = $"{_cashModule}".AddParam(PriceModuleAction.GetRates);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<IDictionary<string, string>>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<decimal> GetBchUsdPriceAsync()
    {
        var queryParameters = $"{_cashModule}".AddParam(PriceModuleAction.GetBchUsdPrice);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<IDictionary<string, decimal>>(responseStream);
        return result?["usd"] ?? 0;
    }

    /// <inheritdoc />
    public async Task<decimal> GeteCashUsdPriceAsync()
    {
        var queryParameters = $"{_cashModule}".AddParam(PriceModuleAction.GeteCashUsdPrice);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<IDictionary<string, decimal>>(responseStream);
        return result?["usd"] ?? 0;
    }
}