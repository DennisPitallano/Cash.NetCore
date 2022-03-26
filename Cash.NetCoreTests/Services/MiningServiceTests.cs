using System;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cash.NetCoreTests.Services;

[TestClass]
public class MiningServiceTests : TestBase
{
    private IMiningService? _miningService;

    [TestInitialize]
    public void MiningServiceTest()
    {
        _miningService = _serviceProvider.GetService<IMiningService>();
    }

    [TestMethod]
    public async Task GetNetworkHashpsAsyncTest()
    {
        var info = await _miningService!.GetNetworkHashpsAsync(120,-1);
        var info1 = await _miningService!.GetNetworkHashpsAsync(120,1);
        Assert.IsTrue(info >0, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
}