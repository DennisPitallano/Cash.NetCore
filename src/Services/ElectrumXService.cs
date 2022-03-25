using System.Net.Http.Json;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Request.ElectrumX;
using Cash.NetCore.Models.Response.ElectrumX;

namespace Cash.NetCore.Services;

/// <inheritdoc cref="IElectrumXService" />
public class ElectrumXService : BaseHttpClient, IElectrumXService
{
    private readonly string _cashModule;

    /// <inheritdoc />
    public ElectrumXService(HttpClient cashHttpClient, CashConfiguration cashConfiguration) : base(cashHttpClient,
        cashConfiguration)
    {
        _cashModule = CashModule.ElectrumX;
    }

    /// <inheritdoc />
    public async Task<BlockHeaderCount?> GetElectrumXBlockHeadersCountAsync(long height, int count)
    {
        var queryParameters = $"{_cashModule}".AddParam(ElectrumXModuleAction.GetElectrumXBlockHeadersCount)
            .AddParam(height.ToString()).AddQueryString("count", count);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<BlockHeaderCount>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<BalanceInfo?> GetElectrumXBalanceAsync(string address)
    {
        var queryParameters = $"{_cashModule}".AddParam(ElectrumXModuleAction.GetBalance)
            .AddParam(address);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<BalanceInfo>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<BalancesInfo?> GetElectrumXBalancesAsync(string[] addresses)
    {
        var url = $"{_cashModule}"
            .AddParam(ElectrumXModuleAction.GetBalance);
        using var response = await CashHttpClient.PostAsJsonAsync(url, new
            {
                addresses
            })
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<BalancesInfo>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<BlockHeaderHeightsCounts?> GetElectrumXBlockHeadersHeightCountAsync(List<BlockHeadersRequest> heightsAndCounts)
    {
        var url = $"{_cashModule}"
            .AddParam(ElectrumXModuleAction.GetElectrumXBlockHeadersCount);
        using var response = await CashHttpClient.PostAsJsonAsync(url, new
            {
                heights = heightsAndCounts
            })
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<BlockHeaderHeightsCounts>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<TransactionHistories?> GetElectrumXTransactionHistoryAsync(string[] addresses)
    {
        var url = $"{_cashModule}"
            .AddParam(ElectrumXModuleAction.GetTransactions);
        using var response = await CashHttpClient.PostAsJsonAsync(url, new
            {
                addresses
            })
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<TransactionHistories>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<TransactionDetails?> GetElectrumXTransactionDetailsAsync(string txid)
    {
        var queryParameters = $"{_cashModule}".AddParam(ElectrumXModuleAction.GetTransactionDetails)
            .AddParam(txid);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<TransactionDetails>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<TransactionsDetail?> GetElectrumXTransactionDetailsAsync(string[] txIds)
    {
        var url = $"{_cashModule}"
            .AddParam(ElectrumXModuleAction.GetTransactionDetails);
        using var response = await CashHttpClient.PostAsJsonAsync(url, new
            {
                txids = txIds
            })
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<TransactionsDetail>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<TransactionHistorySingle?> GetElectrumXTransactionHistoryAsync(string address)
    {
        var queryParameters = $"{_cashModule}".AddParam(ElectrumXModuleAction.GetTransactions)
            .AddParam(address);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<TransactionHistorySingle>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<UnconfirmedSingleUtxos?> GetUnConfirmedAsync(string address)
    {
        var queryParameters = $"{_cashModule}".AddParam(ElectrumXModuleAction.GetUnConfirmed)
            .AddParam(address);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<UnconfirmedSingleUtxos>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<UnconfirmedUtxos?> GetUnConfirmedAsync(string[] addresses)
    {
        var url = $"{_cashModule}"
            .AddParam(ElectrumXModuleAction.GetUnConfirmed);
        using var response = await CashHttpClient.PostAsJsonAsync(url, new
            {
                addresses
            })
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<UnconfirmedUtxos>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<UtxosInfo?> GetUTxosAsync(string[] addresses)
    {
        var url = $"{_cashModule}"
            .AddParam(ElectrumXModuleAction.GetUnConfirmedTransactions);
        using var response = await CashHttpClient.PostAsJsonAsync(url, new
            {
                addresses
            })
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<UtxosInfo>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<SingleUtxos?> GetUTxosAsync(string address)
    {
        var queryParameters = $"{_cashModule}".AddParam(ElectrumXModuleAction.GetUnConfirmedTransactions)
            .AddParam(address);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<SingleUtxos>(responseStream);
        return result;
    }
}