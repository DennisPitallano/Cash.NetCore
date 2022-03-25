using System;
using System.Linq;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Request.BlockChain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cash.NetCoreTests.Services;

[TestClass]
public class ControlServiceTests : TestBase
{
    private IControlService? _controlService;

    [TestInitialize]
    public void ControlServiceTest()
    {
        _controlService = _serviceProvider.GetService<IControlService>();
    }
    
    [TestMethod]
    public async Task GetBlockHeadersVerboseAsyncTest()
    {
        var info = await _controlService!.GetNetworkInfoAsync();
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
}