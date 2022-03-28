using System;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
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
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
}