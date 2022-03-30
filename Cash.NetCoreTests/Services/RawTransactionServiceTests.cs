using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Response.BlockChain;
using Cash.NetCore.Models.Response.ElectrumX;
using Cash.NetCore.Models.Response.RawTransaction;
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
        var decodedScripts = new List<DecodeScript>
        {
            new()
            {
                Asm =
                    "0 0 0 59 OP_MIN OP_UNKNOWN OP_UNKNOWN OP_ROLL OP_ROT b27ac72c3e67768f617fc81bc3888a51323a OP_LESSTHAN OP_NOP9 OP_HASH256 1e5e4a000000006a4730440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26 OP_UNKNOWN OP_ADD OP_UNKNOWN OP_2SWAP 33 -8142088 10 24916 41ddc91af39ff90cd711cdcde03a87b144b883b524660c39ffffffff01807c814a000000001976a914d7e7c4e0b70eaa67ceff9d2823d1bbb9 OP_UNKNOWN OP_UNKNOWN OP_BOOLAND 1 OP_EQUALVERIFY OP_CHECKSIG 0 0 0 0",
                Type = "nonstandard",
                P2Sh = "bitcoincash:pp2jmzk695tg8dxnvxln5ppsrnggw6c8hg0sl8nrxf"
            },
            new()
            {
                Asm =
                    "0 0 0 59 OP_MIN OP_UNKNOWN OP_UNKNOWN OP_ROLL OP_ROT b27ac72c3e67768f617fc81bc3888a51323a OP_LESSTHAN OP_NOP9 OP_HASH256 1e5e4a000000006a4730440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26 OP_UNKNOWN OP_ADD OP_UNKNOWN OP_2SWAP 33 -8142088 10 24916 41ddc91af39ff90cd711cdcde03a87b144b883b524660c39ffffffff01807c814a000000001976a914d7e7c4e0b70eaa67ceff9d2823d1bbb9 OP_UNKNOWN OP_UNKNOWN OP_BOOLAND 1 OP_EQUALVERIFY OP_CHECKSIG 0 0 0 0",
                Type = "nonstandard",
                P2Sh = "bitcoincash:pp2jmzk695tg8dxnvxln5ppsrnggw6c8hg0sl8nrxf"
            }
        };
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
        var decodedScripts = new List<RawTransaction>
        {
            new()
            {
                TxId = "d86c34adaeae19171fd98fe0ffd89bfb92a1e6f0339f5e4f18d837715fd25758",
                Hash = "d86c34adaeae19171fd98fe0ffd89bfb92a1e6f0339f5e4f18d837715fd25758",
                Version = 1,
                Size = 191,
                LockTime = 0,
                RawTransactionVin = new List<RawTransactionVin>
                {
                    new()
                    {
                        Txid = "4a5e1e4baab89f3a32518a88c31bc87f618f76673e2cc77ab2127b7afdeda33b",
                        Vout = 0,
                        ScriptSig = new ScriptSig
                        {
                            Asm =
                                "30440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72[ALL] 03083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39",
                            Hex =
                                "4730440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72012103083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39"
                        },
                        Sequence = 4294967295
                    }
                },
                RawTransactionVout = new List<RawTransactionVout>
                {
                    new()
                    {
                        Value = (decimal) 12.5,
                        N = 0,
                        ScriptPubKey = new ScriptPubKey
                        {
                            Asm =
                                "OP_DUP OP_HASH160 d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a51 OP_EQUALVERIFY OP_CHECKSIG",
                            Hex = "76a914d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a5188ac",
                            ReqSigs = 1,
                            Type = "pubkeyhash",
                            Addresses = new List<string>
                            {
                                "bitcoincash:qrt7038qku825e7wl7wjsg73hwuldhu62yz9t0u9ng"
                            }
                        }
                    }
                }
            },
            new()
            {
                TxId = "d86c34adaeae19171fd98fe0ffd89bfb92a1e6f0339f5e4f18d837715fd25758",
                Hash = "d86c34adaeae19171fd98fe0ffd89bfb92a1e6f0339f5e4f18d837715fd25758",
                Version = 1,
                Size = 191,
                LockTime = 0,
                RawTransactionVin = new List<RawTransactionVin>
                {
                    new()
                    {
                        Txid = "4a5e1e4baab89f3a32518a88c31bc87f618f76673e2cc77ab2127b7afdeda33b",
                        Vout = 0,
                        ScriptSig = new ScriptSig
                        {
                            Asm =
                                "30440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72[ALL] 03083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39",
                            Hex =
                                "4730440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72012103083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39"
                        },
                        Sequence = 4294967295
                    }
                },
                RawTransactionVout = new List<RawTransactionVout>
                {
                    new()
                    {
                        Value = (decimal) 12.5,
                        N = 0,
                        ScriptPubKey = new ScriptPubKey
                        {
                            Asm =
                                "OP_DUP OP_HASH160 d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a51 OP_EQUALVERIFY OP_CHECKSIG",
                            Hex = "76a914d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a5188ac",
                            ReqSigs = 1,
                            Type = "pubkeyhash",
                            Addresses = new List<string>
                            {
                                "bitcoincash:qrt7038qku825e7wl7wjsg73hwuldhu62yz9t0u9ng"
                            }
                        }
                    }
                }
            }
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetDecodeRawTransactionAsyncTest()
    {
        var info = await _rawTransactionService!.GetDecodeRawTransactionAsync(
            "02000000010e991f7ccec410f27d333f737f149b5d3be6728687da81072e638aed0063a176010000006b483045022100cd20443b0af090053450bc4ab00d563d4ac5955bb36e0135b00b8a96a19f233302205047f2c70a08c6ef4b76f2d198b33a31d17edfaa7e1e9e865894da0d396009354121024d4e7f522f67105b7bf5f9dbe557e7b2244613fdfcd6fe09304f93877328f6beffffffff02a0860100000000001976a9140ee020c07f39526ac5505c54fa1ab98490979b8388acb5f0f70b000000001976a9143a9b2b0c12fe722fcf653b6ef5dcc38732d6ff5188ac00000000");
        var decodedRawTransaction = new RawTransaction
        {
            TxId = "d86c34adaeae19171fd98fe0ffd89bfb92a1e6f0339f5e4f18d837715fd25758",
            Hash = "d86c34adaeae19171fd98fe0ffd89bfb92a1e6f0339f5e4f18d837715fd25758",
            Version = 1,
            Size = 191,
            LockTime = 0,
            RawTransactionVin = new List<RawTransactionVin>
            {
                new()
                {
                    Txid = "4a5e1e4baab89f3a32518a88c31bc87f618f76673e2cc77ab2127b7afdeda33b",
                    Vout = 0,
                    ScriptSig = new ScriptSig
                    {
                        Asm =
                            "30440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72[ALL] 03083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39",
                        Hex =
                            "4730440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72012103083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39"
                    },
                    Sequence = 4294967295
                }
            },
            RawTransactionVout = new List<RawTransactionVout>
            {
                new()
                {
                    Value = (decimal) 12.5,
                    N = 0,
                    ScriptPubKey = new ScriptPubKey
                    {
                        Asm =
                            "OP_DUP OP_HASH160 d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a51 OP_EQUALVERIFY OP_CHECKSIG",
                        Hex = "76a914d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a5188ac",
                        ReqSigs = 1,
                        Type = "pubkeyhash",
                        Addresses = new List<string>
                        {
                            "bitcoincash:qrt7038qku825e7wl7wjsg73hwuldhu62yz9t0u9ng"
                        }
                    }
                }
            }
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetDecodeScriptAsyncTest()
    {
        var info = await _rawTransactionService!.GetDecodeScriptAsync(
            "4830450221009a51e00ec3524a7389592bc27bea4af5104a59510f5f0cfafa64bbd5c164ca2e02206c2a8bbb47eabdeed52f17d7df668d521600286406930426e3a9415fe10ed592012102e6e1423f7abde8b70bca3e78a7d030e5efabd3eb35c19302542b5fe7879c1a16");

        var decodedScript = new DecodeScript
        {
            Asm =
                "30450221009a51e00ec3524a7389592bc27bea4af5104a59510f5f0cfafa64bbd5c164ca2e02206c2a8bbb47eabdeed52f17d7df668d521600286406930426e3a9415fe10ed59201 02e6e1423f7abde8b70bca3e78a7d030e5efabd3eb35c19302542b5fe7879c1a16",
            Type = "nonstandard",
            P2Sh = "bitcoincash:pqwndulzwft8dlmqrteqyc9hf823xr3lcc7ypt74ts"
        };
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
        var rawTransactions = new List<RawTransaction>
        {
            new()
            {
                TxId = "a5f972572ee1753e2fd2457dd61ce5f40fa2f8a30173d417e49feef7542c96a1",
                Hash = "a5f972572ee1753e2fd2457dd61ce5f40fa2f8a30173d417e49feef7542c96a1",
                Version = 1,
                Size = 192,
                LockTime = 0,
                RawTransactionVin = new List<RawTransactionVin>
                {
                    new()
                    {
                        Txid = "5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e",
                        Vout = 1,
                        ScriptSig = new ScriptSig
                        {
                            Asm =
                                "3045022100cf9869b1e8c5e5da7bb6753a92171ee17c2bb53a5ed1db25b0a056d9ad459e4e022067c47af184c110cf832fa2f86ce1eebf363eb72293cc450f7ae3d82aad9da22c[ALL|FORKID] 0299b1eedeb115b5880cd5e0df0717bd982748a8e003e34371dc36301e17ee0ed6",
                            Hex =
                                "483045022100cf9869b1e8c5e5da7bb6753a92171ee17c2bb53a5ed1db25b0a056d9ad459e4e022067c47af184c110cf832fa2f86ce1eebf363eb72293cc450f7ae3d82aad9da22c41210299b1eedeb115b5880cd5e0df0717bd982748a8e003e34371dc36301e17ee0ed6"
                        },
                        Sequence = 4294967295
                    }
                },
                RawTransactionVout = new List<RawTransactionVout>
                {
                    new()
                    {
                        Value = new decimal(0.00009805),
                        N = 0,
                        ScriptPubKey = new ScriptPubKey
                        {
                            Asm =
                                "OP_DUP OP_HASH160 e46b114b3908efe7f18cd1435d2e2ffa16a936fd OP_EQUALVERIFY OP_CHECKSIG",
                            Hex = "76a914e46b114b3908efe7f18cd1435d2e2ffa16a936fd88ac",
                            ReqSigs = 1,
                            Type = "pubkeyhash",
                            Addresses = new List<string>
                            {
                                "bitcoincash:qrjxky2t8yywlel33ng5xhfw9lapd2fkl5p5dj7qsw"
                            }
                        }
                    }
                },
                Hex =
                    "01000000015eafe1a59cbbb4b5cf4b315ef0e2739ca9bdb7d9f0b09b14d105ad1a53dc6551010000006b483045022100cf9869b1e8c5e5da7bb6753a92171ee17c2bb53a5ed1db25b0a056d9ad459e4e022067c47af184c110cf832fa2f86ce1eebf363eb72293cc450f7ae3d82aad9da22c41210299b1eedeb115b5880cd5e0df0717bd982748a8e003e34371dc36301e17ee0ed6ffffffff014d260000000000001976a914e46b114b3908efe7f18cd1435d2e2ffa16a936fd88ac00000000",
                BlockHash = "0000000000000000015a670527f131686736987bc3889bc44674795ed64ef40d",
                Confirmations = 176875,
                Time = 1542758880,
                BlockTime = 1542758880
            },
            new()
            {
                TxId = "5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e",
                Hash = "5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e",
                Version = 1,
                Size = 226,
                LockTime = 0,
                RawTransactionVin = new List<RawTransactionVin>
                {
                    new()
                    {
                        Txid = "287494433cb225a988f07d1d937938f3bb6e34bcb447fef23e293ef6aa08a126",
                        Vout = 1,
                        ScriptSig = new ScriptSig
                        {
                            Asm =
                                "3045022100d02c2248c5f3fdcffd0f90e371194e9f87d0e7034e286e267e18dfda25de123f022074cdb79a2224ae471a996ddb0d524d3470ea18f3a5d13031c1be249ae54843f1[ALL|FORKID] 03c9f617abf3e0f5663a3591581d9fbdd990e7ac30995f8739b006fee8f5b5e6cb",
                            Hex =
                                "483045022100d02c2248c5f3fdcffd0f90e371194e9f87d0e7034e286e267e18dfda25de123f022074cdb79a2224ae471a996ddb0d524d3470ea18f3a5d13031c1be249ae54843f1412103c9f617abf3e0f5663a3591581d9fbdd990e7ac30995f8739b006fee8f5b5e6cb"
                        },
                        Sequence = 4294967295
                    }
                },
                RawTransactionVout = new List<RawTransactionVout>
                {
                    new()
                    {
                        Value = (decimal) 0.00031988,
                        N = 0,
                        ScriptPubKey = new ScriptPubKey
                        {
                            Asm =
                                "OP_DUP OP_HASH160 00d75d903c57e418e718a2dab998a441a7117e78 OP_EQUALVERIFY OP_CHECKSIG",
                            Hex = "76a91400d75d903c57e418e718a2dab998a441a7117e7888ac",
                            ReqSigs = 1,
                            Type = "pubkeyhash",
                            Addresses = new List<string>
                            {
                                "bitcoincash:qqqdwhvs83t7gx88rz3d4wvc53q6wyt70qe2wxnkgg"
                            }
                        }
                    },
                    new()
                    {
                        Value = (decimal) 0.0001,
                        N = 1,
                        ScriptPubKey = new ScriptPubKey
                        {
                            Asm =
                                "OP_DUP OP_HASH160 a0f531f4ff810a415580c12e54a7072946bb927e OP_EQUALVERIFY OP_CHECKSIG",
                            Hex = "76a914a0f531f4ff810a415580c12e54a7072946bb927e88ac",
                            ReqSigs = 1,
                            Type = "pubkeyhash",
                            Addresses = new List<string>
                            {
                                "bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c"
                            }
                        }
                    }
                },
                Hex =
                    "010000000126a108aaf63e293ef2fe47b4bc346ebbf33879931d7df088a925b23c43947428010000006b483045022100d02c2248c5f3fdcffd0f90e371194e9f87d0e7034e286e267e18dfda25de123f022074cdb79a2224ae471a996ddb0d524d3470ea18f3a5d13031c1be249ae54843f1412103c9f617abf3e0f5663a3591581d9fbdd990e7ac30995f8739b006fee8f5b5e6cbffffffff02f47c0000000000001976a91400d75d903c57e418e718a2dab998a441a7117e7888ac10270000000000001976a914a0f531f4ff810a415580c12e54a7072946bb927e88ac00000000",
                BlockHash = "000000000000000000bdc52a11408781f1f41b744ee8e5c43df8cda242f09144",
                Confirmations = 178049,
                Time = 1542037792,
                BlockTime = 1542037792
            }
        };
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
        var rawTransactions = new List<string>
        {
            "01000000015eafe1a59cbbb4b5cf4b315ef0e2739ca9bdb7d9f0b09b14d105ad1a53dc6551010000006b483045022100cf9869b1e8c5e5da7bb6753a92171ee17c2bb53a5ed1db25b0a056d9ad459e4e022067c47af184c110cf832fa2f86ce1eebf363eb72293cc450f7ae3d82aad9da22c41210299b1eedeb115b5880cd5e0df0717bd982748a8e003e34371dc36301e17ee0ed6ffffffff014d260000000000001976a914e46b114b3908efe7f18cd1435d2e2ffa16a936fd88ac00000000",
            "010000000126a108aaf63e293ef2fe47b4bc346ebbf33879931d7df088a925b23c43947428010000006b483045022100d02c2248c5f3fdcffd0f90e371194e9f87d0e7034e286e267e18dfda25de123f022074cdb79a2224ae471a996ddb0d524d3470ea18f3a5d13031c1be249ae54843f1412103c9f617abf3e0f5663a3591581d9fbdd990e7ac30995f8739b006fee8f5b5e6cbffffffff02f47c0000000000001976a91400d75d903c57e418e718a2dab998a441a7117e7888ac10270000000000001976a914a0f531f4ff810a415580c12e54a7072946bb927e88ac00000000"
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetRawTransactionVerboseAsyncTest()
    {
        var info = await _rawTransactionService!.GetRawTransactionVerboseAsync(
            "a5f972572ee1753e2fd2457dd61ce5f40fa2f8a30173d417e49feef7542c96a1");
        var rawTransaction = new RawTransaction
        {
            TxId = "a5f972572ee1753e2fd2457dd61ce5f40fa2f8a30173d417e49feef7542c96a1",
            Hash = "a5f972572ee1753e2fd2457dd61ce5f40fa2f8a30173d417e49feef7542c96a1",
            Version = 1,
            Size = 192,
            LockTime = 0,
            RawTransactionVin = new List<RawTransactionVin>
            {
                new()
                {
                    Txid = "5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e",
                    Vout = 1,
                    ScriptSig = new ScriptSig
                    {
                        Asm =
                            "3045022100cf9869b1e8c5e5da7bb6753a92171ee17c2bb53a5ed1db25b0a056d9ad459e4e022067c47af184c110cf832fa2f86ce1eebf363eb72293cc450f7ae3d82aad9da22c[ALL|FORKID] 0299b1eedeb115b5880cd5e0df0717bd982748a8e003e34371dc36301e17ee0ed6",
                        Hex =
                            "483045022100cf9869b1e8c5e5da7bb6753a92171ee17c2bb53a5ed1db25b0a056d9ad459e4e022067c47af184c110cf832fa2f86ce1eebf363eb72293cc450f7ae3d82aad9da22c41210299b1eedeb115b5880cd5e0df0717bd982748a8e003e34371dc36301e17ee0ed6"
                    },
                    Sequence = 4294967295
                }
            },
            RawTransactionVout = new List<RawTransactionVout>
            {
                new()
                {
                    Value = new decimal(0.00009805),
                    N = 0,
                    ScriptPubKey = new ScriptPubKey
                    {
                        Asm =
                            "OP_DUP OP_HASH160 e46b114b3908efe7f18cd1435d2e2ffa16a936fd OP_EQUALVERIFY OP_CHECKSIG",
                        Hex = "76a914e46b114b3908efe7f18cd1435d2e2ffa16a936fd88ac",
                        ReqSigs = 1,
                        Type = "pubkeyhash",
                        Addresses = new List<string>
                        {
                            "bitcoincash:qrjxky2t8yywlel33ng5xhfw9lapd2fkl5p5dj7qsw"
                        }
                    }
                }
            },
            Hex =
                "01000000015eafe1a59cbbb4b5cf4b315ef0e2739ca9bdb7d9f0b09b14d105ad1a53dc6551010000006b483045022100cf9869b1e8c5e5da7bb6753a92171ee17c2bb53a5ed1db25b0a056d9ad459e4e022067c47af184c110cf832fa2f86ce1eebf363eb72293cc450f7ae3d82aad9da22c41210299b1eedeb115b5880cd5e0df0717bd982748a8e003e34371dc36301e17ee0ed6ffffffff014d260000000000001976a914e46b114b3908efe7f18cd1435d2e2ffa16a936fd88ac00000000",
            BlockHash = "0000000000000000015a670527f131686736987bc3889bc44674795ed64ef40d",
            Confirmations = 176875,
            Time = 1542758880,
            BlockTime = 1542758880
        };
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