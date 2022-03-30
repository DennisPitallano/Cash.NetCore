using System;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Response.Encryption;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cash.NetCoreTests.Services;

[TestClass]
public class EncryptionServiceTests : TestBase
{
    private IEncryptionService? _encryptionService;

    [TestInitialize]
    public void EncryptionServiceTest()
    {
        _encryptionService = _serviceProvider.GetService<IEncryptionService>();
    }

    [TestMethod]
    public async Task GetPublicKeyAsyncAsyncTest()
    {
        var info = await _encryptionService!.GetPublicKeyAsync(
            "bitcoincash:qrdka2205f4hyukutc2g0s6lykperc8nsu5u2ddpqf");
        var publicKey = new AddressPublicKey
        {
            Success = true,
            PublicKey = "03b0208e675505d457ef20f9b7605e5d27f85cf6e3a95eadffd8badf80f0c6f604"
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Assert.AreEqual("03b0208e675505d457ef20f9b7605e5d27f85cf6e3a95eadffd8badf80f0c6f604", info.PublicKey);
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
}