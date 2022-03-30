using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Request.ElectrumX;
using Cash.NetCore.Models.Response.BlockChain;
using Cash.NetCore.Models.Response.ElectrumX;
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
        var blockHeaders = new BlockHeaderCount
        {
            Success = true,
            Headers = new List<string>
            {
                "010000008b52bbd72c2f49569059f559c1b1794de5192e4f7d6d2b03c7482bad0000000083e4f8a9d502ed0c419075c1abb5d56f878a2e9079e5612bfb76a2dc37d9c42741dd6849ffff001d2b909dd6",
                "01000000f528fac1bcb685d0cd6c792320af0300a5ce15d687c7149548904e31000000004e8985a786d864f21e9cbb7cbdf4bc9265fe681b7a0893ac55a8e919ce035c2f85de6849ffff001d385ccb7c"
            }
        };
        var info = await _electrumXService!.GetElectrumXBlockHeadersCountAsync(42, 2);
        Assert.IsTrue(info != null, "Info is not empty");
        Assert.AreEqual(info.Headers.ToList().Count, 2, "Count is correct");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }


    [TestMethod]
    public async Task GetElectrumXBalanceAsyncTest()
    {
        var electrumXBalance = new BalanceInfo
        {
            Success = true,
            Balance = new Balance
            {
                Confirmed = 1600,
                Unconfirmed = 0
            }
        };
        var info = await _electrumXService!.GetElectrumXBalanceAsync(
            "bitcoincash:qr69kyzha07dcecrsvjwsj4s6slnlq4r8c30lxnur3");
        Assert.IsTrue(info != null, "Info is not empty");
        Assert.AreEqual(1600, info.Balance.Confirmed, "Balance is correct");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetElectrumXBalancesAsyncTest()
    {
        var electrumXBalances = new BalancesInfo
        {
            Success = true,
            BalancesInfoData = new List<BalancesInfoData>
            {
                new()
                {
                    Balance = new Balance
                    {
                        Confirmed = 7000,
                        Unconfirmed = 0
                    },
                    Address = "bitcoincash:qrdka2205f4hyukutc2g0s6lykperc8nsu5u2ddpqf"
                },
                new()
                {
                    Balance = new Balance
                    {
                        Confirmed = 17278,
                        Unconfirmed = 0
                    },
                    Address = "bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c"
                }
            }
        };
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

        var blockHeaders = new BlockHeaderHeightsCounts
        {
            Success = true,
            Headers = new List<BlockHeaderHeightCount>
            {
                new()
                {
                    Headers = new List<string>
                    {
                        "010000008b52bbd72c2f49569059f559c1b1794de5192e4f7d6d2b03c7482bad0000000083e4f8a9d502ed0c419075c1abb5d56f878a2e9079e5612bfb76a2dc37d9c42741dd6849ffff001d2b909dd6",
                        "01000000f528fac1bcb685d0cd6c792320af0300a5ce15d687c7149548904e31000000004e8985a786d864f21e9cbb7cbdf4bc9265fe681b7a0893ac55a8e919ce035c2f85de6849ffff001d385ccb7c"
                    }
                },
                new()
                {
                    Headers = new List<string>
                    {
                        "0100000095194b8567fe2e8bbda931afd01a7acd399b9325cb54683e64129bcd00000000660802c98f18fd34fd16d61c63cf447568370124ac5f3be626c2e1c3c9f0052d19a76949ffff001d33f3c25d",
                        "010000009a22db7fd25e719abf9e8ccf869fbbc1e22fa71822a37efae054c17b00000000f7a5d0816883ec2f4d237082b47b4d3a6a26549d65ac50d8527b67ab4cb7e6cfadaa6949ffff001d15fa87f6",
                        "0100000084999d1fa0ae9b7eb8b75fa8ad765c6d467a6117015860dce4d89bb600000000ceefaf23adb1009753545c230a374c48851676ccb7d6f004b66dd302ceb5443b4eae6949ffff001d192e9d71",
                        "01000000192f62105285f84e7876b764dde15cc96e3689ccd39ff1131f18041600000000f38b91a939e7f81483f88ffcf3da8607fd928a093746a03b5eb4964ae0a4d2886bb16949ffff001d1541834f",
                        "01000000753fbb8b0a766119fe8e9347b55cf6f977bc961d7dff46b87c050921000000004bb7d646fe8e6678ab8829cc899a89f256b6cf19dbddd494a773b057c374002489b36949ffff001d1766221f"
                    }
                }
            }
        };

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
        var transactionHistories = new TransactionHistories
        {
            Success = true,
            Transactions = new List<TransactionHistory>
            {
                new()
                {
                    Transactions = new List<TransactionHistoryData>
                    {
                        new()
                        {
                            Height = 500029,
                            TxHash = "1dcd59449918de93a1ad0fd23133a4ce107f6e3680609fc48b74f73cc719764f"
                        },
                        new()
                        {
                            Height = 501087,
                            TxHash = "39b94ef9573b453efcd1491998b332066a37ec6c6ef31dd30152ea211453839e"
                        }
                    },
                    Address = "bitcoincash:qr69kyzha07dcecrsvjwsj4s6slnlq4r8c30lxnur3"
                },
                new()
                {
                    Transactions = new List<TransactionHistoryData>
                    {
                        new()
                        {
                            Height = 528850,
                            TxHash = "81039b1d7b855b133f359f9dc65f776bd105650153a941675fedc504228ddbd3"
                        },
                        new()
                        {
                            Height = 528952,
                            TxHash = "544c15ce35c0f2e808d28f29d6587f1ec9276233e29856b7f2938cf0daef0026"
                        }
                    },
                    Address = "bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c"
                }
            }
        };
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

        var transactionDetails = new TransactionDetails
        {
            Success = true,
            Details = new TransactionDetailData
            {
                BlockHash = "0000000000000000002aaf94953da3b487317508ebd1003a1d75d6d6ec2e75cc",
                BlockTime = 1578327094,
                Confirmations = 116969,
                Hash = "4db095f34d632a4daf942142c291f1f2abb5ba2e1ccac919d85bdc2f671fb251",
                Hex =
                    "020000000265d13ef402840c8a51f39779afb7ae4d49e4b0a3c24a3d0e7742038f2c679667010000006441dd1dd72770cadede1a7fd0363574846c48468a398ddfa41a9677c74cac8d2652b682743725a3b08c6c2021a629011e11a264d9036e9d5311e35b5f4937ca7b4e4121020797d8fd4d2fa6fd7cdeabe2526bfea2b90525d6e8ad506ec4ee3c53885aa309ffffffff65d13ef402840c8a51f39779afb7ae4d49e4b0a3c24a3d0e7742038f2c679667000000006441347d7f218c11c04487c1ad8baac28928fb10e5054cd4494b94d078cfa04ccf68e064fb188127ff656c0b98e9ce87f036d183925d0d0860605877d61e90375f774121028a53f95eb631b460854fc836b2e5d31cad16364b4dc3d970babfbdcc3f2e4954ffffffff035ac355000000000017a914189ce02e332548f4804bac65cba68202c9dbf822878dfd0800000000001976a914285bb350881b21ac89724c6fb6dc914d096cd53b88acf9ef3100000000001976a91445f1f1c4a9b9419a5088a3e9c24a293d7a150e6488ac00000000",
                LockTime = 0,
                Size = 392,
                Time = 1578327094,
                TxId = "4db095f34d632a4daf942142c291f1f2abb5ba2e1ccac919d85bdc2f671fb251",
                Version = 2,
                Vin = new List<TransactionDetailVin>
                {
                    new()
                    {
                        ScriptSig = new ScriptSig
                        {
                            Asm =
                                "dd1dd72770cadede1a7fd0363574846c48468a398ddfa41a9677c74cac8d2652b682743725a3b08c6c2021a629011e11a264d9036e9d5311e35b5f4937ca7b4e[ALL|FORKID] 020797d8fd4d2fa6fd7cdeabe2526bfea2b90525d6e8ad506ec4ee3c53885aa309",
                            Hex =
                                "41dd1dd72770cadede1a7fd0363574846c48468a398ddfa41a9677c74cac8d2652b682743725a3b08c6c2021a629011e11a264d9036e9d5311e35b5f4937ca7b4e4121020797d8fd4d2fa6fd7cdeabe2526bfea2b90525d6e8ad506ec4ee3c53885aa309"
                        },
                        Sequence = 4294967295,
                        Vout = 1,
                        Txid = "6796672c8f0342770e3d4ac2a3b0e4494daeb7af7997f3518a0c8402f43ed165"
                    },
                    new()
                    {
                        ScriptSig = new ScriptSig
                        {
                            Asm =
                                "347d7f218c11c04487c1ad8baac28928fb10e5054cd4494b94d078cfa04ccf68e064fb188127ff656c0b98e9ce87f036d183925d0d0860605877d61e90375f77[ALL|FORKID] 028a53f95eb631b460854fc836b2e5d31cad16364b4dc3d970babfbdcc3f2e4954",
                            Hex =
                                "41347d7f218c11c04487c1ad8baac28928fb10e5054cd4494b94d078cfa04ccf68e064fb188127ff656c0b98e9ce87f036d183925d0d0860605877d61e90375f774121028a53f95eb631b460854fc836b2e5d31cad16364b4dc3d970babfbdcc3f2e4954"
                        },
                        Sequence = 4294967295,
                        Vout = 0,
                        Txid = "6796672c8f0342770e3d4ac2a3b0e4494daeb7af7997f3518a0c8402f43ed165"
                    }
                },
                Vout = new List<TransactionDetailVout>
                {
                    new()
                    {
                        N = 0,
                        ScriptPubKey = new ScriptPubKey
                        {
                            Asm = "OP_HASH160 189ce02e332548f4804bac65cba68202c9dbf822 OP_EQUAL",
                            Hex = "a914189ce02e332548f4804bac65cba68202c9dbf82287",
                            ReqSigs = 1,
                            Type = "scripthash",
                            Addresses = new List<string>
                            {
                                "bitcoincash:pqvfecpwxvj53ayqfwkxtjaxsgpvnklcyg8xewk9hl"
                            }
                        },
                        Value = (decimal) 0.0562057
                    },
                    new()
                    {
                        N = 1,
                        ScriptPubKey = new ScriptPubKey
                        {
                            Asm =
                                "OP_DUP OP_HASH160 285bb350881b21ac89724c6fb6dc914d096cd53b OP_EQUALVERIFY OP_CHECKSIG",
                            Hex = "76a914285bb350881b21ac89724c6fb6dc914d096cd53b88ac",
                            ReqSigs = 1,
                            Type = "pubkeyhash",
                            Addresses = new List<string>
                            {
                                "bitcoincash:qq59hv6s3qdjrtyfwfxxldkuj9xsjmx48vrz882knz"
                            }
                        },
                        Value = (decimal) 0.00589197
                    },
                    new()
                    {
                        N = 2,
                        ScriptPubKey = new ScriptPubKey
                        {
                            Asm =
                                "OP_DUP OP_HASH160 45f1f1c4a9b9419a5088a3e9c24a293d7a150e64 OP_EQUALVERIFY OP_CHECKSIG",
                            Hex = "76a91445f1f1c4a9b9419a5088a3e9c24a293d7a150e6488ac",
                            ReqSigs = 1,
                            Type = "pubkeyhash",
                            Addresses = new List<string>
                            {
                                "bitcoincash:qpzlruwy4xu5rxjs3z37nsj29y7h59gwvsu4ddp0u4"
                            }
                        },
                        Value = (decimal) 0.03272697
                    }
                }
            }
        };
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
                "ff03401fd979bd980b8dce8410d875048b437054e6b2df3f49379eac34df8110"
            });

        var transactionsDetail = new TransactionsDetail
        {
            Success = true,
            Transactions = new List<TransactionsDetailData>
            {
                new()
                {
                    Details = new TransactionDetailData
                    {
                        BlockHash = "0000000000000000002aaf94953da3b487317508ebd1003a1d75d6d6ec2e75cc",
                        BlockTime = 1578327094,
                        Confirmations = 116993,
                        Hash = "4db095f34d632a4daf942142c291f1f2abb5ba2e1ccac919d85bdc2f671fb251",
                        Hex =
                            "020000000265d13ef402840c8a51f39779afb7ae4d49e4b0a3c24a3d0e7742038f2c679667010000006441dd1dd72770cadede1a7fd0363574846c48468a398ddfa41a9677c74cac8d2652b682743725a3b08c6c2021a629011e11a264d9036e9d5311e35b5f4937ca7b4e4121020797d8fd4d2fa6fd7cdeabe2526bfea2b90525d6e8ad506ec4ee3c53885aa309ffffffff65d13ef402840c8a51f39779afb7ae4d49e4b0a3c24a3d0e7742038f2c679667000000006441347d7f218c11c04487c1ad8baac28928fb10e5054cd4494b94d078cfa04ccf68e064fb188127ff656c0b98e9ce87f036d183925d0d0860605877d61e90375f774121028a53f95eb631b460854fc836b2e5d31cad16364b4dc3d970babfbdcc3f2e4954ffffffff035ac355000000000017a914189ce02e332548f4804bac65cba68202c9dbf822878dfd0800000000001976a914285bb350881b21ac89724c6fb6dc914d096cd53b88acf9ef3100000000001976a91445f1f1c4a9b9419a5088a3e9c24a293d7a150e6488ac00000000",
                        LockTime = 0,
                        Size = 392,
                        Time = 1578327094,
                        TxId = "4db095f34d632a4daf942142c291f1f2abb5ba2e1ccac919d85bdc2f671fb251",
                        Version = 2,
                        Vin = new List<TransactionDetailVin>
                        {
                            new()
                            {
                                ScriptSig = new ScriptSig
                                {
                                    Asm =
                                        "dd1dd72770cadede1a7fd0363574846c48468a398ddfa41a9677c74cac8d2652b682743725a3b08c6c2021a629011e11a264d9036e9d5311e35b5f4937ca7b4e[ALL|FORKID] 020797d8fd4d2fa6fd7cdeabe2526bfea2b90525d6e8ad506ec4ee3c53885aa309",
                                    Hex =
                                        "41dd1dd72770cadede1a7fd0363574846c48468a398ddfa41a9677c74cac8d2652b682743725a3b08c6c2021a629011e11a264d9036e9d5311e35b5f4937ca7b4e4121020797d8fd4d2fa6fd7cdeabe2526bfea2b90525d6e8ad506ec4ee3c53885aa309"
                                },
                                Sequence = 4294967295,
                                Txid = "6796672c8f0342770e3d4ac2a3b0e4494daeb7af7997f3518a0c8402f43ed165",
                                Vout = 1
                            },
                            new()
                            {
                                ScriptSig = new ScriptSig
                                {
                                    Asm =
                                        "347d7f218c11c04487c1ad8baac28928fb10e5054cd4494b94d078cfa04ccf68e064fb188127ff656c0b98e9ce87f036d183925d0d0860605877d61e90375f77[ALL|FORKID] 028a53f95eb631b460854fc836b2e5d31cad16364b4dc3d970babfbdcc3f2e4954",
                                    Hex =
                                        "41347d7f218c11c04487c1ad8baac28928fb10e5054cd4494b94d078cfa04ccf68e064fb188127ff656c0b98e9ce87f036d183925d0d0860605877d61e90375f774121028a53f95eb631b460854fc836b2e5d31cad16364b4dc3d970babfbdcc3f2e4954"
                                },
                                Sequence = 4294967295,
                                Txid = "6796672c8f0342770e3d4ac2a3b0e4494daeb7af7997f3518a0c8402f43ed165",
                                Vout = 0
                            }
                        },
                        Vout = new List<TransactionDetailVout>
                        {
                            new()
                            {
                                N = 0,
                                ScriptPubKey = new ScriptPubKey
                                {
                                    Asm = "OP_HASH160 189ce02e332548f4804bac65cba68202c9dbf822 OP_EQUAL",
                                    Hex = "a914189ce02e332548f4804bac65cba68202c9dbf82287",
                                    ReqSigs = 1,
                                    Type = "scripthash",
                                    Addresses = new List<string>
                                    {
                                        "bitcoincash:pqvfecpwxvj53ayqfwkxtjaxsgpvnklcyg8xewk9hl"
                                    }
                                },
                                Value = (decimal) 0.0562057
                            },
                            new()
                            {
                                N = 1,
                                ScriptPubKey = new ScriptPubKey
                                {
                                    Asm =
                                        "OP_DUP OP_HASH160 285bb350881b21ac89724c6fb6dc914d096cd53b OP_EQUALVERIFY OP_CHECKSIG",
                                    Hex = "76a914285bb350881b21ac89724c6fb6dc914d096cd53b88ac",
                                    ReqSigs = 1,
                                    Type = "pubkeyhash",
                                    Addresses = new List<string>
                                    {
                                        "bitcoincash:qq59hv6s3qdjrtyfwfxxldkuj9xsjmx48vrz882knz"
                                    }
                                },
                                Value = (decimal) 0.00589197
                            },
                            new()
                            {
                                N = 2,
                                ScriptPubKey = new ScriptPubKey
                                {
                                    Asm =
                                        "OP_DUP OP_HASH160 45f1f1c4a9b9419a5088a3e9c24a293d7a150e64 OP_EQUALVERIFY OP_CHECKSIG",
                                    Hex = "76a91445f1f1c4a9b9419a5088a3e9c24a293d7a150e6488ac",
                                    ReqSigs = 1,
                                    Type = "pubkeyhash",
                                    Addresses = new List<string>
                                    {
                                        "bitcoincash:qpzlruwy4xu5rxjs3z37nsj29y7h59gwvsu4ddp0u4"
                                    }
                                },
                                Value = (decimal) 0.03272697
                            }
                        }
                    },
                    Txid = "4db095f34d632a4daf942142c291f1f2abb5ba2e1ccac919d85bdc2f671fb251"
                },
                new()
                {
                    Details = new TransactionDetailData
                    {
                        BlockHash = "0000000000000000018dde4ae5e0a65231f3e0847888d23c30aab8867554afaa",
                        BlockTime = 1648655328,
                        Confirmations = 1,
                        Hash = "ff03401fd979bd980b8dce8410d875048b437054e6b2df3f49379eac34df8110",
                        Hex =
                            "0200000002bb076f278fb6da0d4139db44d6b39bb0075ee39067e8e59c913e2ce364bbefd4010000006a473044022078125597cc2d68c2d3f4d11a7252a8804b69e6ce80abebc027edcf6fde8eef8602201bad60058d7f14dbc5be714c76fc958d97eaa78fae7c6ea4ff3eab9ccaf5949341210270c976d907dd0d5e25ff16addc4b99d06edf279c9a04637c8bd6c18d5859fe2effffffffc8522523ff01f5f49a5e9759abdbe3d00e9046fbf52be7547095c50c455ba949010000006b483045022100ea5cb9a4dd44367d52d2ca063d4afd3d11299d0e55cdc5d917c8efd265f2bc80022077fc930aecdd830930fff75fc9d87ac9f2bdce5a468433658ccee8a27c88bee1412102886cce80857360fce1dda8956813952989eba7d9a3077008c22953ca78af0e6fffffffff024b49d300000000001976a9143a06fc7cc97302b3f0d60a3a09bdf7c78833447188aca70f0000000000001976a9149710b0ebd2c9ce0cae7a90841652389bcfed946888ac00000000",
                        LockTime = 0,
                        Size = 373,
                        Time = 1648655328,
                        TxId = "ff03401fd979bd980b8dce8410d875048b437054e6b2df3f49379eac34df8110",
                        Version = 2,
                        Vin = new List<TransactionDetailVin>
                        {
                            new()
                            {
                                ScriptSig = new ScriptSig
                                {
                                    Asm =
                                        "3044022078125597cc2d68c2d3f4d11a7252a8804b69e6ce80abebc027edcf6fde8eef8602201bad60058d7f14dbc5be714c76fc958d97eaa78fae7c6ea4ff3eab9ccaf59493[ALL|FORKID] 0270c976d907dd0d5e25ff16addc4b99d06edf279c9a04637c8bd6c18d5859fe2e",
                                    Hex =
                                        "473044022078125597cc2d68c2d3f4d11a7252a8804b69e6ce80abebc027edcf6fde8eef8602201bad60058d7f14dbc5be714c76fc958d97eaa78fae7c6ea4ff3eab9ccaf5949341210270c976d907dd0d5e25ff16addc4b99d06edf279c9a04637c8bd6c18d5859fe2e"
                                },
                                Sequence = 4294967295,
                                Txid = "d4efbb64e32c3e919ce5e86790e35e07b09bb3d644db39410ddab68f276f07bb",
                                Vout = 1
                            },
                            new()
                            {
                                ScriptSig = new ScriptSig
                                {
                                    Asm =
                                        "3045022100ea5cb9a4dd44367d52d2ca063d4afd3d11299d0e55cdc5d917c8efd265f2bc80022077fc930aecdd830930fff75fc9d87ac9f2bdce5a468433658ccee8a27c88bee1[ALL|FORKID] 02886cce80857360fce1dda8956813952989eba7d9a3077008c22953ca78af0e6f",
                                    Hex =
                                        "483045022100ea5cb9a4dd44367d52d2ca063d4afd3d11299d0e55cdc5d917c8efd265f2bc80022077fc930aecdd830930fff75fc9d87ac9f2bdce5a468433658ccee8a27c88bee1412102886cce80857360fce1dda8956813952989eba7d9a3077008c22953ca78af0e6f"
                                },
                                Sequence = 4294967295,
                                Txid = "49a95b450cc5957054e72bf5fb46900ed0e3dbab59975e9af4f501ff232552c8",
                                Vout = 1
                            }
                        },
                        Vout = new List<TransactionDetailVout>
                        {
                            new()
                            {
                                N = 0,
                                ScriptPubKey = new ScriptPubKey
                                {
                                    Asm =
                                        "OP_DUP OP_HASH160 3a06fc7cc97302b3f0d60a3a09bdf7c788334471 OP_EQUALVERIFY OP_CHECKSIG",
                                    Hex = "76a9143a06fc7cc97302b3f0d60a3a09bdf7c78833447188ac",
                                    ReqSigs = 1,
                                    Type = "pubkeyhash",
                                    Addresses = new List<string>
                                    {
                                        "bitcoincash:qqaqdlrue9es9vls6c9r5zda7lrcsv6ywyq2mt0wuf"
                                    }
                                },
                                Value = (decimal) 0.13846859
                            },
                            new()
                            {
                                N = 1,
                                ScriptPubKey = new ScriptPubKey
                                {
                                    Asm =
                                        "OP_DUP OP_HASH160 9710b0ebd2c9ce0cae7a90841652389bcfed9468 OP_EQUALVERIFY OP_CHECKSIG",
                                    Hex = "76a9149710b0ebd2c9ce0cae7a90841652389bcfed946888ac",
                                    ReqSigs = 1,
                                    Type = "pubkeyhash",
                                    Addresses = new List<string>
                                    {
                                        "bitcoincash:qzt3pv8t6tyuur9w02ggg9jj8zdulmv5dqzvlf63s4"
                                    }
                                },
                                Value = (decimal) 0.00004007
                            }
                        }
                    },
                    Txid = "ff03401fd979bd980b8dce8410d875048b437054e6b2df3f49379eac34df8110"
                }
            }
        };

        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetElectrumTransactionHistorySingleAsyncTest()
    {
        var info = await _electrumXService!.GetElectrumXTransactionHistoryAsync(
            "bitcoincash:qr69kyzha07dcecrsvjwsj4s6slnlq4r8c30lxnur3");

        var transactionHistory = new TransactionHistorySingle
        {
            Success = true,
            Transactions = new List<TransactionHistoryData>
            {
                new()
                {
                    Height = 603416,
                    TxHash = "eef683d236d88e978bd406419f144057af3fe1b62ef59162941c1a9f05ded62c"
                },
                new()
                {
                    Height = 646894,
                    TxHash = "4c695fae636f3e8e2edc571d11756b880ccaae744390f3950d798ce7b5e25754"
                }
            }
        };
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
        var Utxos = new UnconfirmedUtxos
        {
            Success = true,
            Utxos = new List<UtxosData>
            {
                new()
                {
                    Utxos = new List<Utxos>
                    {
                        new()
                        {
                            Fee = 219,
                            Height = 0,
                            TxHash = "0fc11070429e563a0e12338511f7014d2ffa6dadf0dd13827045ef2a8b4246d6"
                        },
                        new()
                        {
                            Fee = 219,
                            Height = -1,
                            TxHash = "aad0b34ecb9abf20684400cc36ddc910745d02aaf7b2041e7bd789998d48afc7"
                        }
                    },
                    Address = "bitcoincash:qp2ejsu4zt3k42723zh06az2s5rqjmrvhqp74tlslr"
                },
                new()
                {
                    Utxos = new List<Utxos>
                    {
                        new()
                        {
                            Fee = 220,
                            Height = 0,
                            TxHash = "0bca5ef42d63b46876bb2a87e94efd3ed35269d86b60b1e3048f09f8474bfa26"
                        }
                    },
                    Address = "bitcoincash:qq78sq7ugu0kfuc4nlp4wxsqawfaf8z3vyf0lcn7l0"
                }
            }
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetUnConfirmedSingleAsyncTest()
    {
        var info = await _electrumXService!.GetUnConfirmedAsync(
            "bitcoincash:qp6v49705kspvke4h05djauds96d659pduzj3mud0e");
        var utxos = new UnconfirmedSingleUtxos
        {
            Success = true,
            Utxos = new List<Utxos>
            {
                new()
                {
                    Fee = 219,
                    Height = 0,
                    TxHash = "0fc11070429e563a0e12338511f7014d2ffa6dadf0dd13827045ef2a8b4246d6"
                },
                new()
                {
                    Fee = 219,
                    Height = -1,
                    TxHash = "aad0b34ecb9abf20684400cc36ddc910745d02aaf7b2041e7bd789998d48afc7"
                }
            }
        };
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
        var transactions = new UtxosInfo
        {
            Success = true,
            Utxos = new List<UtxosInfoData>
            {
                new()
                {
                    Utxos = new List<UtxosDetail>
                    {
                        new()
                        {
                            Height = 734231,
                            TxHash = "fda94cd08e11f74ec1f70ac5aec4f83a648ff6488fae87f90182481f7685ed03",
                            TxPos = 0,
                            Value = 15374
                        },
                        new()
                        {
                            Height = 734232,
                            TxHash = "c79ca3e77e1091126eca7658430f028c9457db9503625b60d4f03dc30d787a6f",
                            TxPos = 0,
                            Value = 1330
                        },
                        new()
                        {
                            Height = 734233,
                            TxHash = "0c1c3ef092a276af6710aa9e9840e1448039daf76419b62e86fae942c7c1a65b",
                            TxPos = 0,
                            Value = 1331
                        },
                        new()
                        {
                            Height = 734233,
                            TxHash = "1f8e602f95f04b4ca4ea820609679783d08803d76ff988b1f0414f027509fe0e",
                            TxPos = 0,
                            Value = 2662
                        },
                        new()
                        {
                            Height = 734233,
                            TxHash = "70c1c938f95196742d393c60d1ece9fdba5d05109bf7cf79e4c34540fb108038",
                            TxPos = 0,
                            Value = 1331
                        },
                        new()
                        {
                            Height = 734233,
                            TxHash = "a330b1c599718a9cdf18d11b587b959e1d185069b2f95260e8a4e495b0e8a08d",
                            TxPos = 0,
                            Value = 1065
                        },
                        new()
                        {
                            Height = 734233,
                            TxHash = "fc1b98a5ea8a10b38c4a761ea04ab1734c546532069d29aacba254081f0bb2e9",
                            TxPos = 0,
                            Value = 1996
                        },
                        new()
                        {
                            Height = 0,
                            TxHash = "2576e213f12ce6a64badc5498e74a9891cb2f9314047f0cb087812ae53ab8809",
                            TxPos = 0,
                            Value = 2662
                        },
                        new()
                        {
                            Height = 0,
                            TxHash = "465dc5d80417f243aac066febc45fecb05feda658ad45bed814b1152e774193e",
                            TxPos = 0,
                            Value = 1597
                        },
                        new()
                        {
                            Height = 0,
                            TxHash = "6675789f1d5320ec7a279f3685c5e1f6ca18bd99ab9a32849ebc06ce7c16281e",
                            TxPos = 0,
                            Value = 2661
                        },
                        new()
                        {
                            Height = 0,
                            TxHash = "f63d70a3da7d6a18344aab31cac78c79eaaf4641ee8f30169a48032d05361166",
                            TxPos = 0,
                            Value = 2663
                        }
                    },
                    Address = "bitcoincash:qp6v49705kspvke4h05djauds96d659pduzj3mud0e"
                },
                new()
                {
                    Utxos = new List<UtxosDetail>
                    {
                        new()
                        {
                            Height = 0,
                            TxHash = "3fa0f70f3f338b3b69f12608be1050fe7cdf28eac28d733fe944b079736b1114",
                            TxPos = 1,
                            Value = 18597047
                        }
                    },
                    Address = "bitcoincash:qq74tkwnqzvsu9gady9ndskwd9fa565tas8yzjs8ve"
                }
            }
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetUTxosSingleAsyncTest()
    {
        var info = await _electrumXService!.GetUTxosAsync(
            "bitcoincash:qp6v49705kspvke4h05djauds96d659pduzj3mud0e");
        var transactions = new SingleUtxos
        {
            Success = true,
            Utxos = new List<UtxosDetail>
            {
                new()
                {
                    Height = 734231,
                    TxHash = "fda94cd08e11f74ec1f70ac5aec4f83a648ff6488fae87f90182481f7685ed03",
                    TxPos = 0,
                    Value = 15374
                },
                new()
                {
                    Height = 734232,
                    TxHash = "c79ca3e77e1091126eca7658430f028c9457db9503625b60d4f03dc30d787a6f",
                    TxPos = 0,
                    Value = 1330
                },
                new()
                {
                    Height = 734233,
                    TxHash = "0c1c3ef092a276af6710aa9e9840e1448039daf76419b62e86fae942c7c1a65b",
                    TxPos = 0,
                    Value = 1331
                },
                new()
                {
                    Height = 734233,
                    TxHash = "1f8e602f95f04b4ca4ea820609679783d08803d76ff988b1f0414f027509fe0e",
                    TxPos = 0,
                    Value = 2662
                },
                new()
                {
                    Height = 734233,
                    TxHash = "70c1c938f95196742d393c60d1ece9fdba5d05109bf7cf79e4c34540fb108038",
                    TxPos = 0,
                    Value = 1331
                },
                new()
                {
                    Height = 734233,
                    TxHash = "a330b1c599718a9cdf18d11b587b959e1d185069b2f95260e8a4e495b0e8a08d",
                    TxPos = 0,
                    Value = 1065
                },
                new()
                {
                    Height = 734233,
                    TxHash = "fc1b98a5ea8a10b38c4a761ea04ab1734c546532069d29aacba254081f0bb2e9",
                    TxPos = 0,
                    Value = 1996
                },
                new()
                {
                    Height = 0,
                    TxHash = "2576e213f12ce6a64badc5498e74a9891cb2f9314047f0cb087812ae53ab8809",
                    TxPos = 0,
                    Value = 2662
                },
                new()
                {
                    Height = 0,
                    TxHash = "465dc5d80417f243aac066febc45fecb05feda658ad45bed814b1152e774193e",
                    TxPos = 0,
                    Value = 1597
                },
                new()
                {
                    Height = 0,
                    TxHash = "6675789f1d5320ec7a279f3685c5e1f6ca18bd99ab9a32849ebc06ce7c16281e",
                    TxPos = 0,
                    Value = 2661
                },
                new()
                {
                    Height = 0,
                    TxHash = "f63d70a3da7d6a18344aab31cac78c79eaaf4641ee8f30169a48032d05361166",
                    TxPos = 0,
                    Value = 2663
                }
            }
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
}