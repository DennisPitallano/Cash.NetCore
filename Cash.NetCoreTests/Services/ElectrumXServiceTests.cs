using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Request.ElectrumX;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cash.NetCoreTests.Services;

[TestClass]
public class ElectrumXServiceTests : TestBase
{
    private IElectrumXService? _electrumXService;

    [TestInitialize]
    public void ElectrumXServiceTest()
    {
        _electrumXService = _serviceProvider.GetService<IElectrumXService>();
    }

    [TestMethod]
    public async Task GetElectrumXBlockHeadersCountAsyncTest()
    {
        var info = await _electrumXService!.GetElectrumXBlockHeadersCountAsync(42, 2);
        Assert.IsTrue(info != null, "Info is not empty");
        Assert.AreEqual(info.Headers.ToList().Count, 2, "Count is correct");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }


    [TestMethod]
    public async Task GetElectrumXBalanceAsyncTest()
    {
        var info = await _electrumXService!.GetElectrumXBalanceAsync(
            "bitcoincash:qr69kyzha07dcecrsvjwsj4s6slnlq4r8c30lxnur3");
        Assert.IsTrue(info != null, "Info is not empty");
        Assert.AreEqual(1600, info.Balance.Confirmed, "Balance is correct");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetElectrumXBalancesAsyncTest()
    {
        var info = await _electrumXService!.GetElectrumXBalancesAsync(
            new[]
            {
                "bitcoincash:qr69kyzha07dcecrsvjwsj4s6slnlq4r8c30lxnur3",
                "bitcoincash:qr69kyzha07dcecrsvjwsj4s6slnlq4r8c30lxnur3"
            });
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetElectrumXBlockHeadersHeightCountAsyncTest()
    {
        var parameters = new List<BlockHeadersRequest>
        {
            new()
            {
                Height = 42,
                Count = 2
            },
            new()
            {
                Height = 100,
                Count = 5
            }
        };

        var info = await _electrumXService!.GetElectrumXBlockHeadersHeightCountAsync(
            parameters
        );
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetElectrumTransactionHistoryAsyncTest()
    {
        var info = await _electrumXService!.GetElectrumXTransactionHistoryAsync(
            new[]
            {
                "bitcoincash:qr69kyzha07dcecrsvjwsj4s6slnlq4r8c30lxnur3",
                "bitcoincash:qr69kyzha07dcecrsvjwsj4s6slnlq4r8c30lxnur3"
            });
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetElectrumTransactionHistoryAsyncErrorTest()
    {
        var info = await _electrumXService!.GetElectrumXTransactionHistoryAsync(
            new[]
            {
                "bitcoincash:qr69kyzha07dcecrsvjwsj4s6slnlq4r8c30lxnura",
                "bitcoincash:qr69kyzha07dcecrsvjwsj4s6slnlq4r8c30lxnur3"
            });
        Assert.IsTrue(info.Error != null, "Error is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetElectrumXTransactionDetailsAsyncTest()
    {
        var info = await _electrumXService!.GetElectrumXTransactionDetailsAsync(
            "4db095f34d632a4daf942142c291f1f2abb5ba2e1ccac919d85bdc2f671fb251");
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetElectrumXTransactionsDetailAsyncTest()
    {
        var info = await _electrumXService!.GetElectrumXTransactionDetailsAsync(
            new[]
            {
                "4db095f34d632a4daf942142c291f1f2abb5ba2e1ccac919d85bdc2f671fb251",
                "4db095f34d632a4daf942142c291f1f2abb5ba2e1ccac919d85bdc2f671fb251"
            });
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetElectrumTransactionHistorySingleAsyncTest()
    {
        var info = await _electrumXService!.GetElectrumXTransactionHistoryAsync(
            "bitcoincash:qr69kyzha07dcecrsvjwsj4s6slnlq4r8c30lxnur3");
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    
    [TestMethod]
    public async Task GetUnConfirmedAsyncTest()
    {
        var info = await _electrumXService!.GetUnConfirmedAsync(
            new[]
            {
                "bitcoincash:qp6v49705kspvke4h05djauds96d659pduzj3mud0e",
                "bitcoincash:qq74tkwnqzvsu9gady9ndskwd9fa565tas8yzjs8ve"
            });
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetUnConfirmedSingleAsyncTest()
    {
        var info = await _electrumXService!.GetUnConfirmedAsync(
            "bitcoincash:qp6v49705kspvke4h05djauds96d659pduzj3mud0e");
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
    
    
    [TestMethod]
    public async Task GetUTxosAsyncTest()
    {
        var info = await _electrumXService!.GetUTxosAsync(
            new[]
            {
                "bitcoincash:qp6v49705kspvke4h05djauds96d659pduzj3mud0e",
                "bitcoincash:qq74tkwnqzvsu9gady9ndskwd9fa565tas8yzjs8ve"
            });
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetUTxosSingleAsyncTest()
    {
        var info = await _electrumXService!.GetUTxosAsync(
            "bitcoincash:qp6v49705kspvke4h05djauds96d659pduzj3mud0e");
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
}