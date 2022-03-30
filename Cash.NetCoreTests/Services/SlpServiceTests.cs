using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Response.Slp;
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
        var result = new SlpConvertAddress
        {
            SlpAddress = "simpleledger:qz9tzs6d5097ejpg279rg0rnlhz546q4fsnck9wh5m",
            CashAddress = "bitcoincash:qz9tzs6d5097ejpg279rg0rnlhz546q4fslra7mh29",
            LegacyAddress = "1DeLbv5EMzLEFDvQ8wZiKeSuPGGtSSz5HP"
        };
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
        var results = new List<SlpConvertAddress>
        {
            new()
            {
                SlpAddress = "simpleledger:qrxa0unrn67rtn85v7asfddhhth43ecnxua0antk2l",
                CashAddress = "bitcoincash:qrxa0unrn67rtn85v7asfddhhth43ecnxu35kg7k5p",
                LegacyAddress = "1KmQDaJdUDwwEFRwVwGwTqJ9gqBzyGYzjY"
            },
            new()
            {
                SlpAddress = "simpleledger:qz9tzs6d5097ejpg279rg0rnlhz546q4fsnck9wh5m",
                CashAddress = "bitcoincash:qz9tzs6d5097ejpg279rg0rnlhz546q4fslra7mh29",
                LegacyAddress = "1DeLbv5EMzLEFDvQ8wZiKeSuPGGtSSz5HP"
            }
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetTokenWhitelistAsyncTest()
    {
        var info = await _slpService!.GetTokenWhitelistAsync();
        var results = new List<SlpTokenWhitelist>
        {
            new()
            {
                Name = "USDH",
                TokenId = "c4b0d62156b3fa5c8f3436079b5394f7edc1bef5dc1cd2f9d0c4d46f82cca479"
            },
            new()
            {
                Name = "SPICE",
                TokenId = "4de69e374a8ed21cbddd47f2338cc0f479dc58daa2bbe11cd604ca488eca0ddf"
            },
            new()
            {
                Name = "PSF",
                TokenId = "38e97c5d7d3585a2cbf3f9580c82ca33985f9cb0845d4dcce220cb709f9538b0"
            },
            new()
            {
                Name = "TROUT",
                TokenId = "a4fb5c2da1aa064e25018a43f9165040071d9e984ba190c222a7f59053af84b2"
            },
            new()
            {
                Name = "PSFTEST",
                TokenId = "d0ef4de95b78222bfee2326ab11382f4439aa0855936e2fe6ac129a8d778baa0"
            }
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
}