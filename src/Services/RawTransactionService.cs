using System.Net.Http.Json;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Response.RawTransaction;

namespace Cash.NetCore.Services;

/// <summary>
///     RawTransactionService
/// </summary>
public class RawTransactionService : BaseHttpClient, IRawTransactionService
{
    private readonly string _cashModule;

    /// <inheritdoc />
    public RawTransactionService(HttpClient cashHttpClient, CashConfiguration cashConfiguration) : base(cashHttpClient,
        cashConfiguration)
    {
        _cashModule = CashModule.RawTransaction;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<DecodeScript>?> GetDecodeScriptsAsync(string[] hexes)
    {
        var url = $"{_cashModule}"
            .AddParam(RawTransactionModuleAction.DecodeScript);
        using var response = await CashHttpClient.PostAsJsonAsync(url, new
            {
                hexes
            })
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<IEnumerable<DecodeScript>>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<RawTransaction>?> GetDecodeBulkRawTransactionsAsync(string[] hexes)
    {
        var url = $"{_cashModule}"
            .AddParam(RawTransactionModuleAction.DecodeRawTransaction);
        using var response = await CashHttpClient.PostAsJsonAsync(url, new
            {
                hexes
            })
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<IEnumerable<RawTransaction>>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<RawTransaction?> GetDecodeRawTransactionAsync(string hex)
    {
        var queryParameters = $"{_cashModule}".AddParam(RawTransactionModuleAction.DecodeRawTransaction)
            .AddParam(hex);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<RawTransaction>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<DecodeScript?> GetDecodeScriptAsync(string hex)
    {
        var queryParameters = $"{_cashModule}".AddParam(RawTransactionModuleAction.DecodeScript)
            .AddParam(hex);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<DecodeScript>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<RawTransaction>?> GetRawTransactionsVerboseAsync(string[] txids)
    {
        var url = $"{_cashModule}"
            .AddParam(RawTransactionModuleAction.GetRawTransaction);
        using var response = await CashHttpClient.PostAsJsonAsync(url, new
            {
                txids,
                verbose = true
            })
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<IEnumerable<RawTransaction>>(responseStream);
        return result;
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<string>?> GetRawTransactionsAsync(string[] txids)
    {
        var url = $"{_cashModule}"
            .AddParam(RawTransactionModuleAction.GetRawTransaction);
        using var response = await CashHttpClient.PostAsJsonAsync(url, new
            {
                txids
            })
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<IEnumerable<string>>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<RawTransaction?> GetRawTransactionVerboseAsync(string txid)
    {
        var queryParameters = $"{_cashModule}".AddParam(RawTransactionModuleAction.GetRawTransaction)
            .AddParam(txid).AddQueryString("verbose", "true");
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<RawTransaction>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<string?> GetRawTransactionAsync(string txid)
    {
        var queryParameters = $"{_cashModule}".AddParam(RawTransactionModuleAction.GetRawTransaction)
            .AddParam(txid);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<string>(responseStream);
        return result;
    }
}