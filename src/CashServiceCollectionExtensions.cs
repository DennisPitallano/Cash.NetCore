﻿using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cash.NetCore;

/// <summary>
/// </summary>
public static class CashServiceCollectionExtensions
{
    /// <summary>
    ///     AddCashService CollectionExtensions
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    /// <param name="configuration">IConfiguration</param>
    public static void AddCashServices(this IServiceCollection? services, IConfiguration configuration)
    {
        if (services == null) return;

        var cashConfiguration = new CashConfiguration();
        configuration.GetSection(nameof(CashOptions)).Bind(cashConfiguration);
        services.AddSingleton(cashConfiguration);

        var configureClient = new Action<HttpClient>(client =>
        {
            client.BaseAddress = new Uri(cashConfiguration.CashOptions.Uri!);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentTypes.Json));
        });

        services.AddHttpClient<IBlockChainService, BlockChainService>(configureClient);
        services.AddHttpClient<IControlService, ControlService>(configureClient);
        services.AddHttpClient<IElectrumXService, ElectrumXService>(configureClient);
        services.AddHttpClient<IEncryptionService, EncryptionService>(configureClient);
        services.AddHttpClient<IMiningService, MiningService>(configureClient);
        services.AddHttpClient<IPsfSlpService, PsfSlpService>(configureClient);
        services.AddHttpClient<IPriceService, PriceService>(configureClient);
        services.AddHttpClient<IRawTransactionService, RawTransactionService>(configureClient);
        services.AddHttpClient<ISlpService, SlpService>(configureClient);
        services.AddHttpClient<IUtilService, UtilService>(configureClient);
    }
}