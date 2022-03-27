using System;
using System.Linq;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cash.NetCoreTests.Services;

[TestClass]
public class PriceServiceTests : TestBase
{
    private IPriceService? _priceService;

    [TestInitialize]
    public void PriceServiceTest()
    {
        _priceService = _serviceProvider.GetService<IPriceService>();
    }

    [TestMethod]
    public async Task GetRatesAsyncTest()
    {
        var info = await _priceService!.GetRatesAsync();
        Assert.IsTrue(info != null, "Info is not empty");
        var rates = info.FirstOrDefault(a => a.Key=="USD");
        Assert.IsTrue(rates.Value != null, "Rates is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetUsdPriceAsyncTest()
    {
        var info = await _priceService!.GetBchUsdPriceAsync();
        Assert.IsTrue(info>0, "Info is not empty");
        Console.WriteLine($"Value: {info.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GeteCashUsdPriceAsyncTest()
    {
        var info = await _priceService!.GeteCashUsdPriceAsync();
        Assert.IsTrue(info>0, "Info is not empty");
        Console.WriteLine($"Value: {info.ToJsonFormat()}");
    }
}