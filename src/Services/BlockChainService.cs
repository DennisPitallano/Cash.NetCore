using System.Net.Http.Json;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Request.BlockChain;
using Cash.NetCore.Models.Response.BlockChain;

namespace Cash.NetCore.Services;

/// <inheritdoc cref="IBlockChainService" />
public class BlockChainService : BaseHttpClient, IBlockChainService
{
    private readonly string _cashModule;

    /// <inheritdoc />
    public BlockChainService(HttpClient cashHttpClient, CashConfiguration cashConfiguration) : base(cashHttpClient,
        cashConfiguration)
    {
        _cashModule = CashModule.BlockChain;
    }

    /// <inheritdoc />
    public async Task<long> GetBlockCountAsc()
    {
        var queryParameters = $"{_cashModule}".AddParam(BlockChainModuleAction.GetBlockChainBlockCount);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<long>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ChainTip>?> GetChainTipsAsc()
    {
        var queryParameters = $"{_cashModule}".AddParam(BlockChainModuleAction.GetChainTips);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<IEnumerable<ChainTip>>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<TransactionOutput?> GetTxOutAsync(string txId, int n, bool includeMempool)
    {
        var queryParameters = $"{_cashModule}".AddParam(BlockChainModuleAction.GetTxOut)
            .AddParam(txId).AddParam(n).AddQueryString("mempool", includeMempool);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<TransactionOutput>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<TransactionOutput?> GetTxOutAsync(TransactionOutputRequest param)
    {
        using var response = await CashHttpClient.PostAsJsonAsync($"{_cashModule}"
                .AddParam(BlockChainModuleAction.GetTxOut), param)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<TransactionOutput>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<string?> GetBestBlockHashAsync()
    {
        var queryParameters = $"{_cashModule}".AddParam(BlockChainModuleAction.GetBestBlockHash);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<string>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<string?> GetBlockAsync(string blockhash)
    {
        using var response = await CashHttpClient.PostAsJsonAsync($"{_cashModule}"
                .AddParam(BlockChainModuleAction.GetBlock), new
            {
                blockhash,
                verbosity = 0
            })
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<string>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<BlockInfo?> GetBlockVerbosity1Async(string blockhash)
    {
        using var response = await CashHttpClient.PostAsJsonAsync($"{_cashModule}"
                .AddParam(BlockChainModuleAction.GetBlock), new
            {
                blockhash,
                verbosity = 1
            })
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<BlockInfo>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<BlockAndTransactionInfo?> GetBlockVerbosity2Async(string blockhash)
    {
        using var response = await CashHttpClient.PostAsJsonAsync($"{_cashModule}"
                .AddParam(BlockChainModuleAction.GetBlock), new
            {
                blockhash,
                verbosity = 2
            })
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<BlockAndTransactionInfo>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<string?> GetBlockHashAsync(string height)
    {
        var queryParameters = $"{_cashModule}".AddParam(BlockChainModuleAction.GetBlockHash).AddParam(height);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<string>(responseStream);
        return result;
    }

    /// <inheritdoc />
    public async Task<BlockChainInfo?> GetBlockChainInfoAsync()
    {
        var queryParameters = $"{_cashModule}".AddParam(BlockChainModuleAction.GetBlockchainInfo);
        using var response = await CashHttpClient.GetAsync($"{queryParameters}")
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<BlockChainInfo>(responseStream);
        return result;
    }
}