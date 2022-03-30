using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Response.Control;
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
        var networkInfo = new NetworkInfo
        {
            Version = 23000000,
            Subversion = "/Bitcoin Cash Node:23.0.0(EB32.0)/",
            ProtocolVersion = 70015,
            LocalServices = "0000000000000425",
            LocalRelay = true,
            TimeOffSet = 0,
            NetworkActive = true,
            Connections = 84,
            Networks = new List<Network>
            {
                new()
                {
                    Name = "ipv4",
                    Limited = false,
                    Reachable = true,
                    Proxy = "",
                    ProxyRandomizeCredentials = false
                },
                new()
                {
                    Name = "ipv6",
                    Limited = false,
                    Reachable = true,
                    Proxy = "",
                    ProxyRandomizeCredentials = false
                },
                new()
                {
                    Name = "onion",
                    Limited = true,
                    Reachable = false,
                    Proxy = "",
                    ProxyRandomizeCredentials = false
                }
            },
            RelayFee = (decimal) 0.00001,
            ExcessUTxoCharge = 0,
            LocalAddresses = null,
            Warnings = ""
        };
        var info = await _controlService!.GetNetworkInfoAsync();
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
}