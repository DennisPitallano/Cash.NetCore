using System;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cash.NetCoreTests.Services;

[TestClass]
public class PsfSlpServiceTests : TestBase
{
    private IPsfSlpService? _psfSlpService;

    [TestInitialize]
    public void PsfSlpServiceTest()
    {
        _psfSlpService = _serviceProvider.GetService<IPsfSlpService>();
    }

    [TestMethod]
    public async Task GetNetworkHashpsAsyncTest()
    {
        var info = await _psfSlpService!.GetIndexerStatusAsync();
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetTokenStatusAsyncTest()
    {
        var info = await _psfSlpService!.GetTokenStatusAsync("a4fb5c2da1aa064e25018a43f9165040071d9e984ba190c222a7f59053af84b2");
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetPsfSlpBalanceAsyncTest()
    {
        var info = await _psfSlpService!.GetPsfSlpBalanceAsync("bitcoincash:qzmd5vxgh9m22m6fgvm57yd6kjnjl9qnwywsf3583n");
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetPsfSlpTransactionDataAsyncTest()
    {
        var info = await _psfSlpService!.GetPsfSlpTransactionDataAsync("d5ef5c3d16584f2840a572166607dede9a67f74160047ac03c7c27840c891a5c");
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
}