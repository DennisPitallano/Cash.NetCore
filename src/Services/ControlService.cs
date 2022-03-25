using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Response.Control;

namespace Cash.NetCore.Services;

/// <inheritdoc cref="IControlService" />
public class ControlService : BaseHttpClient, IControlService
{
    private readonly string _cashModule;

    /// <inheritdoc />
    public ControlService(HttpClient cashHttpClient, CashConfiguration cashConfiguration) : base(cashHttpClient,
        cashConfiguration)
    {
        _cashModule = CashModule.Control;
    }

    /// <inheritdoc />
    public async Task<NetworkInfo?> GetNetworkInfoAsync()
    {
        var queryParameters = $"{_cashModule}".AddParam(ControlModuleAction.Getnetworkinfo);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<NetworkInfo>(responseStream);
        return result;
    }
}