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
        var hash = await _blockChainService!.GetBlockAsync(
            "000000000000000002a5fe0bdd6e3f04342a975c0f55e57f97e73bb90041676b");
        Assert.IsTrue(hash != null, "Hash is not empty");
        Console.WriteLine($"Hash: {hash}");
    }

    [TestMethod]
    public async Task GetBlockVerbosity1AsyncTest()
    {
        var blockInfo =
            await _blockChainService!.GetBlockVerbosity1Async(
                "000000000000000002a5fe0bdd6e3f04342a975c0f55e57f97e73bb90041676b");
        Assert.IsTrue(blockInfo != null, "Block Info is not empty");
        Console.WriteLine($"Hash: {blockInfo.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetBlockVerbosity2AsyncTest()
    {
        var blockInfo =
            await _blockChainService!.GetBlockVerbosity2Async(
                "000000000000000002a5fe0bdd6e3f04342a975c0f55e57f97e73bb90041676b");
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

    [TestMethod]
    public async Task GetMempoolEntryAsyncTest()
    {
        var info = await _blockChainService!.GetMempoolEntryAsync(new[]
        {
            "960c18c38e6947c7cc6a2abfe2448e223ce5908b246af1b7a49b20c0c8242565",
            "bc7e9459debf330460a531730b1776f363db1223d2215d73ed239ae0418f6514"
        });
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetMempoolSingleEntryAsyncTest()
    {
        var info = await _blockChainService!.GetMempoolEntryAsync("5fd16a623c9faa985afbeb5f5831944a7e65669ba63fbb48b0433c54e3dba8fe");
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetDifficultyAsyncTest()
    {
        var result = await _blockChainService!.GetDifficultyAsync();
        Assert.IsTrue(result != null, "Value is not empty");
        Console.WriteLine($"Hash: {result}");
    }

    [TestMethod]
    public async Task GetMempoolInfoAsyncTest()
    {
        var info = await _blockChainService!.GetMempoolInfoAsync();
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetBlockHeaderVerboseAsyncTest()
    {
        var infoVerbose =
            await _blockChainService!.GetBlockHeaderVerboseAsync(
                "000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201");
        Assert.IsTrue(infoVerbose != null, "Info is not empty");

        Console.WriteLine($"Hash: {infoVerbose.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetBlockHeaderAsyncTest()
    {
        var info = await _blockChainService!.GetBlockHeaderAsync(
            "000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201");
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetBlockHeadersAsyncTest()
    {
        var info = await _blockChainService!.GetBlockHeadersAsync(new[]
        {
            "000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201",
            "00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3"
        });
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
    
    [TestMethod]
    public async Task GetBlockHeadersVerboseAsyncTest()
    {
        var info = await _blockChainService!.GetBlockHeadersVerboseAsync(new[]
        {
            "000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201",
            "00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3"
        });
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
}