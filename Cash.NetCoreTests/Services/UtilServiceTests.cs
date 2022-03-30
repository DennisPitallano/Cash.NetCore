using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Response.Util;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cash.NetCoreTests.Services;

[TestClass]
public class UtilServiceTests : TestBase
{
    private IUtilService? _utilService;

    [TestInitialize]
    public void UtilServiceTest()
    {
        _utilService = _serviceProvider.GetService<IUtilService>();
    }

    [TestMethod]
    public async Task ValidateAddressAsyncTest()
    {
        var info = await _utilService!.ValidateAddressAsync(
            "bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c");
        var result = new AddressInfo
        {
            IsValid = true,
            Address = "bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c",
            ScriptPubKey = "76a914a0f531f4ff810a415580c12e54a7072946bb927e88ac",
            IsScript = false
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task ValidateAddressesAsyncTest()
    {
        var info = await _utilService!.ValidateAddressesAsync(new[]
        {
            "bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c",
            "bitcoincash:qrehqueqhw629p6e57994436w730t4rzasnly00ht0"
        });

        var results = new List<AddressInfo>()
        {
            new AddressInfo
            {
                IsValid = true,
                Address = "bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c",
                ScriptPubKey = "76a914a0f531f4ff810a415580c12e54a7072946bb927e88ac",
                IsScript = false
            },
            new AddressInfo()
                {
                    IsValid = true,
                    Address = "bitcoincash:qrehqueqhw629p6e57994436w730t4rzasnly00ht0",
                    ScriptPubKey = "76a914f3707320bbb4a28759a78a5ad63a77a2f5d462ec88ac",
                   IsScript = false
                }
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
}