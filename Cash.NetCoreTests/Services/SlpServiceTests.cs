using System;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cash.NetCoreTests.Services;

[TestClass]
public class SlpServiceTests : TestBase
{
    private ISlpService? _slpService;

    [TestInitialize]
    public void SlpServiceTest()
    {
        _slpService = _serviceProvider.GetService<ISlpService>();
    }

    [TestMethod]
    public async Task GetConvertAddressAsyncTest()
    {
        var info = await _slpService!.GetConvertAddressAsync(
            "simpleledger:qz9tzs6d5097ejpg279rg0rnlhz546q4fsnck9wh5m");
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetConvertAddressesAsyncTest()
    {
        var info = await _slpService!.GetConvertAddressesAsync(new[]
        {
            "simpleledger:qrxa0unrn67rtn85v7asfddhhth43ecnxua0antk2l",
            "simpleledger:qz9tzs6d5097ejpg279rg0rnlhz546q4fsnck9wh5m"
        });
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
}