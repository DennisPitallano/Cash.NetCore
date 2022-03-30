using System;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Response.Mining;
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
        var info = await _miningService!.GetNetworkHashpsAsync(120, -1);
        var info1 = await _miningService!.GetNetworkHashpsAsync(120, 1);
        Assert.IsTrue(info > 0, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetMiningInfoAsyncTest()
    {
        var info = await _miningService!.GetMiningInfoAsync();
        var miningInfo = new MiningInfo
        {
            Blocks = 734236,
            CurrentBlockSize = 0,
            CurrentBlockTx = 0,
           Difficulty = (decimal) 227336239671.5679,
            Networkhashps = 1579123811663756000,
           Pooledtx = 2,
            Chain = "main",
            Warnings = ""
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
}