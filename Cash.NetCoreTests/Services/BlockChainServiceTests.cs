using System;
using System.Collections.Generic;
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
        var chainTipsList = new List<ChainTip>
        {
            new()
            {
                Height = 733367,
                Hash = "0000000000000000042b60032e34fe13c82ca56aad660469b859ea122aa1d14c",
                BranchLen = 0,
                Status = "active"
            },
            new()
            {
                Height = 699255,
                Hash = "00000000000000000414796698752eec1e9d71133c41e85af67c15c1e2c8c90d",
                BranchLen = 1,
                Status = "valid-headers"
            }
        };
        var chainTips = await _blockChainService!.GetChainTipsAsc();

        Assert.IsTrue(chainTips!.ToList().Count > 0, "Chain tips is not empty");

        Console.WriteLine($"Chain tips: {chainTips.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetTxOutAsyncTest()
    {
        var txOut = new TransactionOutput
        {
            BestBlock = "000000000000000004e19c1b14333cf75838cf92dfac8f29fcc3f64c2d5c6506",
            Confirmations = 732406,
            Value = 50,
            ScriptPubKey = new ScriptPubKey
            {
                Asm =
                    "04f5eeb2b10c944c6b9fbcfff94c35bdeecd93df977882babc7f3a2cf7f5c81d3b09a68db7f0e04f21de5d4230e75e6dbe7ad16eefe0d4325a62067dc6f369446a OP_CHECKSIG",
                Hex =
                    "4104f5eeb2b10c944c6b9fbcfff94c35bdeecd93df977882babc7f3a2cf7f5c81d3b09a68db7f0e04f21de5d4230e75e6dbe7ad16eefe0d4325a62067dc6f369446aac",
                ReqSigs = 1,
                Type = "pubkey",
                Addresses = new List<string>
                {
                    "bitcoincash:qpej6mkrwca4tvy2snq4crhrf88v4ljspysx0ueetk"
                }
            },
            Coinbase = true
        };

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
        var bInfo = new BlockInfo
        {
            Hash = "000000000000000002a5fe0bdd6e3f04342a975c0f55e57f97e73bb90041676b",
            Confirmations = 53175,
            Size = 1791085,
            Height = 680319,
            Version = 541065216,
            VersionHex = "20400000",
            Merkleroot = "c77548898036ebbaf6f323a963d4bdcfd5a29ec45b2ff9c7dcc504c6916c1b96",
            Tx = new List<string>
            {
                "461b942756fe15c29a6f12f8dddf43a252545576384423cc40356a79334503a3",
                "0009236270fbf86fe3d0ca4cb96bb9de212c8e5f5836a03239fccbe843c33843",
                "00272489414f8265c12e66c2f28537472f18d4922ae5974bb01dc6ccf24e2ce1",
                "00627b161e2199304fc04c856a9b154f981fecefaca187937ea8fe80bd0d4e74",
                "ffb2dae51ee98f9a8655b0e3c54294de4d6e9c065a0305626f2cdf5843f4ee9e",
                "ffc481803620d08a0e0825ed940405771b47d5f28d9e2539347907eabcd10adb"
            },
            Time = 1616698749,
            Mediantime = 1616696565,
            Nonce = 2400115052,
            Bits = "1805dd73",
            Difficulty = (decimal) 187466001665.8389,
            Chainwork = "000000000000000000000000000000000000000001627d68a55a9240dc6985dc",
            NTx = 2288,
            Previousblockhash = "0000000000000000058144693512a3ebd41e00cb24b343db91e41a0ceeefcf94",
            Nextblockhash = "0000000000000000036538eebb64f032eafb29ea45f3f4ea550d9593e82bc2b6"
        };
        var blockInfo =
            await _blockChainService!.GetBlockVerbosity1Async(
                "000000000000000002a5fe0bdd6e3f04342a975c0f55e57f97e73bb90041676b");
        Assert.IsTrue(blockInfo != null, "Block Info is not empty");
        Console.WriteLine($"Hash: {blockInfo.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetBlockVerbosity2AsyncTest()
    {
        var bInfo = new BlockAndTransactionInfo
        {
            Hash = "000000000000000002a5fe0bdd6e3f04342a975c0f55e57f97e73bb90041676b",
            Confirmations = 53175,
            Size = 1791085,
            Height = 680319,
            Version = 541065216,
            VersionHex = "20400000",
            Merkleroot = "c77548898036ebbaf6f323a963d4bdcfd5a29ec45b2ff9c7dcc504c6916c1b96",
            Tx = new List<BlockTransactionInfo>
            {
                new()
                {
                    Txid = "0009236270fbf86fe3d0ca4cb96bb9de212c8e5f5836a03239fccbe843c33843",
                    Hash = "0009236270fbf86fe3d0ca4cb96bb9de212c8e5f5836a03239fccbe843c33843",
                    Version = 2,
                    Size = 219,
                    Locktime = 0,
                    Vin = new List<BlockTransactionInputInfo>
                    {
                        new()
                        {
                            Txid = "5702d86870a3988ae60da9d440e154d00dda4e23f262092f2fa3f8a8f7a997f4",
                            Vout = 1,
                            ScriptSig = new BlockTransactionInputScriptSigInfo
                            {
                                Asm =
                                    "aec1f6aadbde697b9cfbd84e7b2b93f86e0031019f463b23cce29092dfe056e60421c8d5f6cc44c0f1f07626f8f64b4ca8faaecf4754fe9c99be500b90a76b95[ALL|FORKID] 02719a7031742b71a93c082ac943fe42a1e12ae9868770216ad16fed1f2e46960a",
                                Hex =
                                    "41aec1f6aadbde697b9cfbd84e7b2b93f86e0031019f463b23cce29092dfe056e60421c8d5f6cc44c0f1f07626f8f64b4ca8faaecf4754fe9c99be500b90a76b95412102719a7031742b71a93c082ac943fe42a1e12ae9868770216ad16fed1f2e46960a"
                            },
                            Sequence = 0
                        }
                    },
                    Vout = new List<BlockTransactionOutputInfo>
                    {
                        new()
                        {
                            Value = (decimal) 0.00008316,
                            N = 0,
                            ScriptPubKey = new BlockTransactionOutputScriptPubKeyInfo
                            {
                                Asm =
                                    "OP_DUP OP_HASH160 ae4eb12324368fdc93fd44196a7238afbb6b74a8 OP_EQUALVERIFY OP_CHECKSIG",
                                Hex = "76a914ae4eb12324368fdc93fd44196a7238afbb6b74a888ac",
                                ReqSigs = 1,
                                Type = "pubkeyhash",
                                Addresses = new List<string>
                                {
                                    "bitcoincash:qzhyavfrysmglhynl4zpj6nj8zhmk6m54q53mggtej"
                                }
                            }
                        },
                        new()
                        {
                            Value = (decimal) 0.09344132,
                            N = 1,
                            ScriptPubKey = new BlockTransactionOutputScriptPubKeyInfo
                            {
                                Asm =
                                    "OP_DUP OP_HASH160 2815129632d4ce37831269e03c0e2dacd8123403 OP_EQUALVERIFY OP_CHECKSIG",
                                Hex = "76a9142815129632d4ce37831269e03c0e2dacd812340388ac",
                                ReqSigs = 1,
                                Type = "pubkeyhash",
                                Addresses = new List<string>
                                {
                                    "bitcoincash:qq5p2y5kxt2vudurzf57q0qw9kkdsy35qv77w2ss9z"
                                }
                            }
                        }
                    },
                    Hex =
                        "0200000001f497a9f7a8f8a32f2f0962f2234eda0dd054e140d4a90de68a98a37068d80257010000006441aec1f6aadbde697b9cfbd84e7b2b93f86e0031019f463b23cce29092dfe056e60421c8d5f6cc44c0f1f07626f8f64b4ca8faaecf4754fe9c99be500b90a76b95412102719a7031742b71a93c082ac943fe42a1e12ae9868770216ad16fed1f2e46960a00000000027c200000000000001976a914ae4eb12324368fdc93fd44196a7238afbb6b74a888ac84948e00000000001976a9142815129632d4ce37831269e03c0e2dacd812340388ac00000000"
                }
            }
        };
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
        var blockChainInfo = new BlockChainInfo
        {
            Chain = "main",
            Blocks = 733493,
            Headers = 733493,
            BestBlockHash = "000000000000000000ceaa574ae44c327f6752313480317485f803071541a646",
            Difficulty = (decimal) 216278704324.5844,
            MedianTime = 1648564783,
            VerificationProgress = (decimal) 0.9999768649036239,
            Initialblockdownload = false,
            ChainWork = "000000000000000000000000000000000000000001904042e3350fd37a060abb",
            SizeOnDisk = 203399747530,
            Pruned = false,
            Warnings = ""
        };
        var hash = await _blockChainService!.GetBlockChainInfoAsync();
        Assert.IsTrue(hash != null, "Hash is not empty");
        Console.WriteLine($"Hash: {hash.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetMempoolEntryAsyncTest()
    {
        var memPool = new List<MempoolEntry>
        {
            new()
            {
                Fees = new Fees
                {
                    Base = (decimal) 0.0000022,
                    Modified = (decimal) 0.0000022
                },
                Size = 219,
                Time = 1648603325,
                Height = 733547,
                Depends = new List<string>
                {
                    "403513ba5ff16b669d988a7b26c00a71ec210f941efc48a8e657868f694c8c6a"
                },
                SpentBy = new List<string>
                {
                    "58564fe80f07b38b96311d6335c33cd15c0f109a968405e6913a3b7c14138630"
                }
            },
            new()
            {
                Fees = new Fees
                {
                    Base = (decimal) 0.0000022,
                    Modified = (decimal) 0.0000022
                },
                Size = 219,
                Time = 1648603334,
                Height = 733547,
                Depends = null,
                SpentBy = new List<string>
                {
                    "bb6bc3b4b45e8ca771bab82b3461973d00f45bc6abe3e17731a3c2434019c88f"
                }
            },
            new()
            {
                Fees = new Fees
                {
                    Base = (decimal) 0.00000228,
                    Modified = (decimal) 0.00000228
                },
                Size = 224,
                Time = 1648603335,
                Height = 733547,
                Depends = new List<string>
                {
                    "a605dbaa9520bddf989c54c6a121ac3def5b9adaf4bee89adc0810bb48ca3c71"
                },
                SpentBy = null
            }
        };
        var info = await _blockChainService!.GetMempoolEntryAsync(new[]
        {
            "4e991ad6d80813a2b868598143b88165d4482fcdb7fb94774603fd1e248e058d",
            "b3b5d627b4d692154fb9ccc58639522d09418f3349bd49ed6c3f52c86f7128b4",
            "4d87e62ada41ab9f99e64b010c2a09c6773dc64f2eabfdfdfd1fce353953c304"
        });
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetMempoolSingleEntryAsyncTest()
    {
        var info = await _blockChainService!.GetMempoolEntryAsync(
            "5fd16a623c9faa985afbeb5f5831944a7e65669ba63fbb48b0433c54e3dba8fe");
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
        var memPoolInfo = new MempoolInfo
        {
            Loaded = true,
            Size = 430,
            MempoolBytes = 186389,
            Usage = 602688,
            MaxMempoolBytes = 320000000,
            Mempoolminfee = (decimal) 0.00001,
            Minrelaytxfee = (decimal) 0.00001
        };
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
        var blockHeaders = new List<string>
        {
            "0000002023e5e672edd0277e68e5e57e2880056f7113b0ebd631380400000000000000009190c16e9e1eddde7ab26afa1eb08ef509cac26f28e35a657e331b5e6479f24a60c1f6591ab909185070d8d6",
            "0000002001b2328355f4a4dc9efa5c610687304507b7df9f3f4de105000000000000000096a61a8599a2e392438f391bdfbd20ab7b91e7775c005293454058b2f4c7fc010dc7f6591ab909189aa0768f"
        };
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
        var blockHeaders = new List<BlockHeader>
        {
            new()
            {
                Hash = "000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201",
                Confirmations = 233553,
                Height = 500000,
                Version = 536870912,
                VersionHex = "20000000",
                Merkleroot = "4af279645e1b337e655ae3286fc2ca09f58eb01efa6ab27adedd1e9e6ec19091",
                Time = 1509343584,
                Mediantime = 1509336533,
                Nonce = 3604508752,
                Bits = "1809b91a",
                Difficulty = (decimal) 113081236211.4533,
                Chainwork = "0000000000000000000000000000000000000000007ae48aca46e3b449ad9714",
                NTx = 150,
                Previousblockhash = "0000000000000000043831d6ebb013716f0580287ee5e5687e27d0ed72e6e523",
                Nextblockhash = "00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3"
            },
            new()
            {
                Hash = "00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3",
                Confirmations = 233552,
                Height = 500001,
                Version = 536870912,
                VersionHex = "20000000",
                Merkleroot = "01fcc7f4b25840459352005c77e7917bab20bddf1b398f4392e3a299851aa696",
                Time = 1509345037,
                Mediantime = 1509336585,
                Nonce = 2406916250,
                Bits = "1809b91a",
                Difficulty = (decimal) 113081236211.4533,
                Chainwork = "0000000000000000000000000000000000000000007ae4a51e8bf2ecccf1d9a1",
                NTx = 196,
                Previousblockhash = "000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201",
                Nextblockhash = "00000000000000000797607b2b69d1561027dbaf28545a33d6ec3adb89f8e564"
            }
        };
        var info = await _blockChainService!.GetBlockHeadersVerboseAsync(new[]
        {
            "000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201",
            "00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3"
        });
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
}