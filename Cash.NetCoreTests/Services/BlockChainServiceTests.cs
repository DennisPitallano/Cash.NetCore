using System;
using System.Linq;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Request.BlockChain;
using Cash.NetCore.Models.Response.BlockChain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cash.NetCoreTests.Services;

[TestClass]
public class BlockChainServiceTests : TestBase
{
    private IBlockChainService? _blockChainService;

    [TestInitialize]
    public void BlockChainServiceTest()
    {
        _blockChainService = _serviceProvider.GetService<IBlockChainService>();
    }

    [TestMethod]
    public async Task GetBlockCountAscTest()
    {
        var blockCount = await _blockChainService!.GetBlockCountAsc();
        Assert.IsTrue(blockCount > 700000, "Block count is less than 50000");
        Console.WriteLine($"Block count: {blockCount}");
        //Assert.AreEqual(731573,blockCount);
    }

    [TestMethod]
    public async Task GetChainTipsAscTest()
    {
        var chainTips = await _blockChainService!.GetChainTipsAsc();
        Assert.IsTrue(chainTips!.ToList().Count > 0, "Chain tips is not empty");
        Console.WriteLine($"Chain tips: {chainTips.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetTxOutAsyncTest()
    {
        var result = await _blockChainService!.GetTxOutAsync(
            "fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33",
            0, false);
        var result2 = await _blockChainService!.GetTxOutAsync(
            "f228050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33",
            0, false);
        Assert.IsTrue(result != null, "Transaction Output is not empty");
        Assert.IsTrue(result2 == null, "Transaction Output is empty");

        var resultPost = await _blockChainService!.GetTxOutAsync(
            new TransactionOutputRequest
            {
                Mempool = false,
                TxId = "fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33",
                Vout = 0
            });
        var resultPost2 = await _blockChainService!.GetTxOutAsync(new TransactionOutputRequest
        {
            Mempool = false,
            TxId = "f228050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33",
            Vout = 0
        });

        Assert.IsTrue(result != null, "Transaction Output is not empty");
        Assert.IsTrue(result2 == null, "Transaction Output is empty");

        Assert.IsTrue(resultPost != null, "Transaction Output is not empty");
        Assert.IsTrue(resultPost2 == null, "Transaction Output is empty");
        Console.WriteLine($"Chain tips: {result.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetBestBlockHashAsyncTest()
    {
        var hash = await _blockChainService!.GetBestBlockHashAsync();
        Assert.IsTrue(hash != null, "Hash is not empty");
        Console.WriteLine($"Hash: {hash}");
    }

    [TestMethod]
    public async Task GetBlockAsyncTest()
    {
        var hash = await _blockChainService!.GetBlockAsync("000000000000000002a5fe0bdd6e3f04342a975c0f55e57f97e73bb90041676b");
        Assert.IsTrue(hash != null, "Hash is not empty");
        Console.WriteLine($"Hash: {hash}");
    }

    [TestMethod]
    public async Task GetBlockVerbosity1AsyncTest()
    {
        var blockInfo = await _blockChainService!.GetBlockVerbosity1Async("000000000000000002a5fe0bdd6e3f04342a975c0f55e57f97e73bb90041676b");
        Assert.IsTrue(blockInfo != null, "Block Info is not empty");
        Console.WriteLine($"Hash: {blockInfo.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetBlockVerbosity2AsyncTest()
    {
        var blockInfo = await _blockChainService!.GetBlockVerbosity2Async("000000000000000002a5fe0bdd6e3f04342a975c0f55e57f97e73bb90041676b");
        Assert.IsTrue(blockInfo != null, "Block Info is not empty");
       // Console.WriteLine($"Hash: {blockInfo.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetBlockHashAsyncTest()
    {
        var hash = await _blockChainService!.GetBlockHashAsync("544444");
        Assert.IsTrue(hash != null, "Hash is not empty");
        Console.WriteLine($"Hash: {hash}");
    }

    [TestMethod]
    public async Task GetBlockChainInfoAsyncTest()
    {
        var hash = await _blockChainService!.GetBlockChainInfoAsync();
        Assert.IsTrue(hash != null, "Hash is not empty");
        Console.WriteLine($"Hash: {hash.ToJsonFormat()}");
    }
}