using System;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cash.NetCoreTests.Services;

[TestClass]
public class RawTransactionServiceTests : TestBase
{
    private IRawTransactionService? _rawTransactionService;

    [TestInitialize]
    public void RawTransactionServiceTest()
    {
        _rawTransactionService = _serviceProvider.GetService<IRawTransactionService>();
    }

    [TestMethod]
    public async Task GGetDecodeScriptsAsyncTest()
    {
        var info = await _rawTransactionService!.GetDecodeScriptsAsync(
            new[]
            {
                "01000000013ba3edfd7a7b12b27ac72c3e67768f617fc81bc3888a51323a9fb8aa4b1e5e4a000000006a4730440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72012103083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39ffffffff01807c814a000000001976a914d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a5188ac00000000",
                "01000000013ba3edfd7a7b12b27ac72c3e67768f617fc81bc3888a51323a9fb8aa4b1e5e4a000000006a4730440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72012103083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39ffffffff01807c814a000000001976a914d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a5188ac00000000"
            });
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetDecodeBulkRawTransactionsAsyncTest()
    {
        var info = await _rawTransactionService!.GetDecodeBulkRawTransactionsAsync(
            new[]
            {
                "01000000013ba3edfd7a7b12b27ac72c3e67768f617fc81bc3888a51323a9fb8aa4b1e5e4a000000006a4730440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72012103083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39ffffffff01807c814a000000001976a914d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a5188ac00000000",
                "01000000013ba3edfd7a7b12b27ac72c3e67768f617fc81bc3888a51323a9fb8aa4b1e5e4a000000006a4730440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72012103083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39ffffffff01807c814a000000001976a914d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a5188ac00000000"
            });
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetDecodeRawTransactionAsyncTest()
    {
        var info = await _rawTransactionService!.GetDecodeRawTransactionAsync(
            "02000000010e991f7ccec410f27d333f737f149b5d3be6728687da81072e638aed0063a176010000006b483045022100cd20443b0af090053450bc4ab00d563d4ac5955bb36e0135b00b8a96a19f233302205047f2c70a08c6ef4b76f2d198b33a31d17edfaa7e1e9e865894da0d396009354121024d4e7f522f67105b7bf5f9dbe557e7b2244613fdfcd6fe09304f93877328f6beffffffff02a0860100000000001976a9140ee020c07f39526ac5505c54fa1ab98490979b8388acb5f0f70b000000001976a9143a9b2b0c12fe722fcf653b6ef5dcc38732d6ff5188ac00000000");
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetDecodeScriptAsyncTest()
    {
        var info = await _rawTransactionService!.GetDecodeScriptAsync(
            "4830450221009a51e00ec3524a7389592bc27bea4af5104a59510f5f0cfafa64bbd5c164ca2e02206c2a8bbb47eabdeed52f17d7df668d521600286406930426e3a9415fe10ed592012102e6e1423f7abde8b70bca3e78a7d030e5efabd3eb35c19302542b5fe7879c1a16");
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetRawTransactionsVerboseAsyncTest()
    {
        var info = await _rawTransactionService!.GetRawTransactionsVerboseAsync(
            new[]
            {
                "a5f972572ee1753e2fd2457dd61ce5f40fa2f8a30173d417e49feef7542c96a1",
                "5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e"
            });
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetRawTransactionsAsyncTest()
    {
        var info = await _rawTransactionService!.GetRawTransactionsAsync(
            new[]
            {
                "a5f972572ee1753e2fd2457dd61ce5f40fa2f8a30173d417e49feef7542c96a1",
                "5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e"
            });
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetRawTransactionVerboseAsyncTest()
    {
        var info = await _rawTransactionService!.GetRawTransactionVerboseAsync(
            "fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33");
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetRawTransactionAsyncTest()
    {
        var info = await _rawTransactionService!.GetRawTransactionAsync(
            "fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33");
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }    
}