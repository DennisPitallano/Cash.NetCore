using System.Net.Http.Json;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Response.PsfSlp;

namespace Cash.NetCore.Services;

/// <inheritdoc cref="IPsfSlpService" />
public class PsfSlpService : BaseHttpClient, IPsfSlpService
{
    private readonly string _cashModule;

    /// <inheritdoc />
    public PsfSlpService(HttpClient cashHttpClient, CashConfiguration cashConfiguration) : base(cashHttpClient,
        cashConfiguration)
    {
        _cashModule = CashModule.PsfSlp;
    }

    /// <inheritdoc />
    public async Task<IndexerStatus?> GetIndexerStatusAsync()
    {
        var queryParameters = $"{_cashModule}".AddParam(PsfSlpModuleAction.Status);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<IndexerStatus>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<PsfSlpTokenStatus?> GetTokenStatusAsync(string token)
    {
        var url = $"{_cashModule}"
            .AddParam(PsfSlpModuleAction.Token);
        using var response = await CashHttpClient.PostAsJsonAsync(url, new
            {
                tokenId = token
            })
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<PsfSlpTokenStatus>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<PsfSlpBalance?> GetPsfSlpBalanceAsync(string address)
    {
        var url = $"{_cashModule}"
            .AddParam(PsfSlpModuleAction.Address);
        using var response = await CashHttpClient.PostAsJsonAsync(url, new
            {
                address
            })
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<PsfSlpBalance>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<PsfSlpTransaction?> GetPsfSlpTransactionDataAsync(string txid)
    {
        var url = $"{_cashModule}"
            .AddParam(PsfSlpModuleAction.TransactionId);
        using var response = await CashHttpClient.PostAsJsonAsync(url, new
            {
                txid
            })
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<PsfSlpTransaction>(responseStream);
        return result;
    }
}