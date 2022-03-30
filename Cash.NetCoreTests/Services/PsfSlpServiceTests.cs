using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cash.NetCore.Contracts;
using Cash.NetCore.Extensions;
using Cash.NetCore.Models.Response.BlockChain;
using Cash.NetCore.Models.Response.ElectrumX;
using Cash.NetCore.Models.Response.PsfSlp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cash.NetCoreTests.Services;

[TestClass]
public class PsfSlpServiceTests : TestBase
{
    private IPsfSlpService? _psfSlpService;

    [TestInitialize]
    public void PsfSlpServiceTest()
    {
        _psfSlpService = _serviceProvider.GetService<IPsfSlpService>();
    }

    [TestMethod]
    public async Task GetNetworkHashpsAsyncTest()
    {
        var info = await _psfSlpService!.GetIndexerStatusAsync();
        var indexerStatus = new IndexerStatus
        {
            Status = new Indexes
            {
                StartBlockHeight = 543376,
                SyncedBlockHeight = 734240,
                ChainBlockHeight = 733701
            }
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetTokenStatusAsyncTest()
    {
        var info = await _psfSlpService!.GetTokenStatusAsync(
            "a4fb5c2da1aa064e25018a43f9165040071d9e984ba190c222a7f59053af84b2");
        var tokenStatus = new PsfSlpTokenStatus
        {
            TokenData = new TokenData
            {
                Type = 1,
                Ticker = "TROUT",
                Name = "Trout's test token",
                TokenId = "a4fb5c2da1aa064e25018a43f9165040071d9e984ba190c222a7f59053af84b2",
                DocumentUri = "troutsblog.com",
                DocumentHash = "",
                Decimals = 2,
                MintBatonIsActive = true,
                TokensInCirculationBn = "100097954886",
                TokensInCirculationStr = "100097954886",
                BlockCreated = 622414,
                TotalBurned = "2045114",
                TotalMinted = "100100000000"
            }
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetPsfSlpBalanceAsyncTest()
    {
        var info = await _psfSlpService!.GetPsfSlpBalanceAsync(
            "bitcoincash:qzmd5vxgh9m22m6fgvm57yd6kjnjl9qnwywsf3583n");
        var balance = new PsfSlpBalance
        {
            Balance = new PsfSlpBalanceInfo
            {
                UTxos = new List<PsfSlpBalanceUtxos>
                {
                    new()
                    {
                        Txid = "afa539c5b7dda42f1ada1d19cc3f0e4aeb3eb97bb681484e1b0b5eb22b9a7f3f",
                        Vout = 1,
                        Type = "token",
                        TokenType = 1,
                        Qty = "1",
                        TokenId = "f1d0631716fefeb597df18fe2eea5d12e2cc86af0e4604e7255077626aaec1f8",
                        Address = "bitcoincash:qzmd5vxgh9m22m6fgvm57yd6kjnjl9qnwywsf3583n",
                        Decimals = 0,
                        EffectiveQty = "1",
                        Value = (decimal) 0.00000546
                    },
                    new()
                    {
                        Txid = "9bef6a568a026c479b6ba891fa01d0acb3331e85d19bbb910282a6a9fb27e931",
                        Vout = 1,
                        Type = "token",
                        TokenType = 1,
                        Qty = "0",
                        TokenId = "301d4ef718298369815ee98618acf548aeda763a7a6221978955312fa2a476b4",
                        Address = "bitcoincash:qzmd5vxgh9m22m6fgvm57yd6kjnjl9qnwywsf3583n",
                        Decimals = 0,
                        EffectiveQty = "0",
                        Value = (decimal) 0.00000546
                    }
                },
                Txs = new List<PsfSlpTxs>
                {
                    new()
                    {
                        Txid = "497a892af5c1ee4d7cee9348ad261453bcdaedc65edd5383c42f21b304a7f6e1",
                        Height = 669965
                    },
                    new()
                    {
                        Txid = "e9e711f10890dd6bc59b71433dbb34a09734f5a0d8e04d6bd338a7791a488b4b",
                        Height = 669965
                    },
                    new()
                    {
                        Txid = "afa539c5b7dda42f1ada1d19cc3f0e4aeb3eb97bb681484e1b0b5eb22b9a7f3f",
                        Height = 670912
                    },
                    new()
                    {
                        Txid = "2d2b9a887f6f98065575eec2cf9c69940ec41653a0975c084d40b7737cf74720",
                        Height = 678619
                    }
                },
                Balances = new List<PsfSlpBalanceDetail>
                {
                    new()
                    {
                        TokenId = "f1d0631716fefeb597df18fe2eea5d12e2cc86af0e4604e7255077626aaec1f8",
                        Qty = "1"
                    },
                    new()
                    {
                        TokenId = "301d4ef718298369815ee98618acf548aeda763a7a6221978955312fa2a476b4",
                        Qty = "0"
                    },
                    new()
                    {
                        TokenId = "02e0c4057b9d5962ca5d51d4fa2bd814e11e7e3f98afcf5b19be7966c68027ad",
                        Qty = "0"
                    },
                    new()
                    {
                        TokenId = "2d860662801067828be3c4f504ce31b2a1a36c2cdbc6d92f6160920f66b0a9ee",
                        Qty = "88"
                    },
                    new()
                    {
                        TokenId = "7a427a156fe70f83d3ccdd17e75804cc0df8c95c64ce04d256b3851385002a0b",
                        Qty = "1"
                    }
                }
            }
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }

    [TestMethod]
    public async Task GetPsfSlpTransactionDataAsyncTest()
    {
        var info = await _psfSlpService!.GetPsfSlpTransactionDataAsync(
            "d5ef5c3d16584f2840a572166607dede9a67f74160047ac03c7c27840c891a5c");

        var transaction = new PsfSlpTransaction
        {
            TxData = new PsfSlpTransactionData
            {
                TxId = "d5ef5c3d16584f2840a572166607dede9a67f74160047ac03c7c27840c891a5c",
                Hash = "d5ef5c3d16584f2840a572166607dede9a67f74160047ac03c7c27840c891a5c",
                Version = 2,
                Size = 766,
                LockTime = 0,
                Vin = new List<PsfSlpTransactionDataVin>
                {
                    new()
                    {
                        Txid = "78426a9b089a52e93aac82b1ae06aae160116f0e65453ffcaf27b012e3d089c8",
                        Vout = 1,
                        ScriptSig = new ScriptSig
                        {
                            Asm =
                                "3044022070ec2c752a8ab70dddbda98943045de9c3e66b7721448d16921134f932552c4502205f855f703f030bacb1ffc6dccf0cff6f1aeaf6b89ee2a6c7bb54829769d8d3aa[ALL|FORKID] 0379cb3d35c712cebbf609d2ce6b1c0d4b70dd27bbb3a9b0bd5491a5954aeb4687",
                            Hex =
                                "473044022070ec2c752a8ab70dddbda98943045de9c3e66b7721448d16921134f932552c4502205f855f703f030bacb1ffc6dccf0cff6f1aeaf6b89ee2a6c7bb54829769d8d3aa41210379cb3d35c712cebbf609d2ce6b1c0d4b70dd27bbb3a9b0bd5491a5954aeb4687"
                        },
                        Sequence = 4294967295,
                        Address = "bitcoincash:qzmd5vxgh9m22m6fgvm57yd6kjnjl9qnwywsf3583n",
                        Value = (decimal) 0.00000546,
                        TokenQtyStr = "3",
                        TokenQty = 3,
                        TokenId = "02e0c4057b9d5962ca5d51d4fa2bd814e11e7e3f98afcf5b19be7966c68027ad"
                    },
                    new()
                    {
                        Txid = "d723a5dd57c48ea9d69b248ba586e69d49084c970956db520d263f9b6d59ceb0",
                        Vout = 1,
                        ScriptSig = new ScriptSig
                        {
                            Asm =
                                "304402206f510267fafb26c2a808381c3b9de6af02eb0b8fd21a951aa56f1cf6652770400220410acf9b8b0ed242833492b5973020eeef78d3dcd81f9f25e9e1d3d137274d30[ALL|FORKID] 0379cb3d35c712cebbf609d2ce6b1c0d4b70dd27bbb3a9b0bd5491a5954aeb4687",
                            Hex =
                                "47304402206f510267fafb26c2a808381c3b9de6af02eb0b8fd21a951aa56f1cf6652770400220410acf9b8b0ed242833492b5973020eeef78d3dcd81f9f25e9e1d3d137274d3041210379cb3d35c712cebbf609d2ce6b1c0d4b70dd27bbb3a9b0bd5491a5954aeb4687"
                        },
                        Sequence = 4294967295,
                        Address = "bitcoincash:qzmd5vxgh9m22m6fgvm57yd6kjnjl9qnwywsf3583n",
                        Value = (decimal) 0.00000546,
                        TokenQtyStr = "0",
                        TokenQty = 0,
                        TokenId = "02e0c4057b9d5962ca5d51d4fa2bd814e11e7e3f98afcf5b19be7966c68027ad"
                    },
                    new()
                    {
                        Txid = "fb2a4baa0aa1e69609d373b5b53770fcea2bb7c899c9ecbe51bfa193d05cce5b",
                        Vout = 2,
                        ScriptSig = new ScriptSig
                        {
                            Asm =
                                "3045022100b7abe253b84f19407b223d57b47ff4e472747feec0797c545598c5eb7fe5dc5f0220160e9410deae317bfaf51f62e5c82e83ce658685da506e3ab62e435e0305fb31[ALL|FORKID] 0379cb3d35c712cebbf609d2ce6b1c0d4b70dd27bbb3a9b0bd5491a5954aeb4687",
                            Hex =
                                "483045022100b7abe253b84f19407b223d57b47ff4e472747feec0797c545598c5eb7fe5dc5f0220160e9410deae317bfaf51f62e5c82e83ce658685da506e3ab62e435e0305fb3141210379cb3d35c712cebbf609d2ce6b1c0d4b70dd27bbb3a9b0bd5491a5954aeb4687"
                        },
                        Sequence = 4294967295,
                        Address = "bitcoincash:qzmd5vxgh9m22m6fgvm57yd6kjnjl9qnwywsf3583n",
                        Value = (decimal) 0.00000546,
                        TokenQty = 0,
                        TokenQtyStr = "0",
                        TokenId = null
                    },
                    new()
                    {
                        Txid = "fb2a4baa0aa1e69609d373b5b53770fcea2bb7c899c9ecbe51bfa193d05cce5b",
                        Vout = 3,
                        ScriptSig = new ScriptSig
                        {
                            Asm =
                                "3045022100cf29ad3390631bd221e6f9fa3defe7bc99e2ffce5ebd5ce4bc7ad5aab320da78022036806de1ed220e886db15727bca97716a9b543b8c1cd062a84f9881168be9f0d[ALL|FORKID] 0379cb3d35c712cebbf609d2ce6b1c0d4b70dd27bbb3a9b0bd5491a5954aeb4687",
                            Hex =
                                "483045022100cf29ad3390631bd221e6f9fa3defe7bc99e2ffce5ebd5ce4bc7ad5aab320da78022036806de1ed220e886db15727bca97716a9b543b8c1cd062a84f9881168be9f0d41210379cb3d35c712cebbf609d2ce6b1c0d4b70dd27bbb3a9b0bd5491a5954aeb4687"
                        },
                        Sequence = 4294967295,
                        Address = "bitcoincash:qzmd5vxgh9m22m6fgvm57yd6kjnjl9qnwywsf3583n",
                        Value = (decimal) 0.00024852,
                        TokenQty = 0,
                        TokenQtyStr = "0",
                        TokenId = null
                    }
                },
                Vout = new List<PsfSlpTransactionDataVout>
                {
                    new()
                    {
                        Value = 0,
                        N = 0,
                        ScriptPubKey = new ScriptPubKey
                        {
                            Asm =
                                "OP_RETURN 5262419 1 1145980243 02e0c4057b9d5962ca5d51d4fa2bd814e11e7e3f98afcf5b19be7966c68027ad 0000000000000000",
                            Hex =
                                "6a04534c500001010453454e442002e0c4057b9d5962ca5d51d4fa2bd814e11e7e3f98afcf5b19be7966c68027ad080000000000000000",
                            Type = "nulldata"
                        },
                        TokenQty = null,
                        TokenQtyStr = null
                    },
                    new()
                    {
                        Value = (decimal) 0.00000546,
                        N = 1,
                        ScriptPubKey = new ScriptPubKey
                        {
                            Asm =
                                "OP_DUP OP_HASH160 b6da30c8b976a56f4943374f11bab4a72f941371 OP_EQUALVERIFY OP_CHECKSIG",
                            Hex = "76a914b6da30c8b976a56f4943374f11bab4a72f94137188ac",
                            ReqSigs = 1,
                            Type = "pubkeyhash",
                            Addresses = new List<string>
                            {
                                "bitcoincash:qzmd5vxgh9m22m6fgvm57yd6kjnjl9qnwywsf3583n"
                            }
                        },
                        TokenQtyStr = "0",
                        TokenQty = 0
                    },
                    new()
                    {
                        Value = (decimal) 0.00000546,
                        N = 2,
                        ScriptPubKey = new ScriptPubKey
                        {
                            Asm =
                                "OP_DUP OP_HASH160 b6da30c8b976a56f4943374f11bab4a72f941371 OP_EQUALVERIFY OP_CHECKSIG",
                            Hex = "76a914b6da30c8b976a56f4943374f11bab4a72f94137188ac",
                            ReqSigs = 1,
                            Type = "pubkeyhash",
                            Addresses = new List<string>
                            {
                                "bitcoincash:qzmd5vxgh9m22m6fgvm57yd6kjnjl9qnwywsf3583n"
                            }
                        },
                        TokenQtyStr = null,
                        TokenQty = null
                    },
                    new()
                    {
                        Value = (decimal) 0.0002244,
                        N = 3,
                        ScriptPubKey = new ScriptPubKey
                        {
                            Asm =
                                "OP_DUP OP_HASH160 b6da30c8b976a56f4943374f11bab4a72f941371 OP_EQUALVERIFY OP_CHECKSIG",
                            Hex = "76a914b6da30c8b976a56f4943374f11bab4a72f94137188ac",
                            ReqSigs = 1,
                            Type = "pubkeyhash",
                            Addresses = new List<string>
                            {
                                "bitcoincash:qzmd5vxgh9m22m6fgvm57yd6kjnjl9qnwywsf3583n"
                            }
                        },
                        TokenQty = null,
                        TokenQtyStr = null
                    }
                },
                Hex =
                    "0200000004c889d0e312b027affc3f45650e6f1160e1aa06aeb182ac3ae9529a089b6a4278010000006a473044022070ec2c752a8ab70dddbda98943045de9c3e66b7721448d16921134f932552c4502205f855f703f030bacb1ffc6dccf0cff6f1aeaf6b89ee2a6c7bb54829769d8d3aa41210379cb3d35c712cebbf609d2ce6b1c0d4b70dd27bbb3a9b0bd5491a5954aeb4687ffffffffb0ce596d9b3f260d52db5609974c08499de686a58b249bd6a98ec457dda523d7010000006a47304402206f510267fafb26c2a808381c3b9de6af02eb0b8fd21a951aa56f1cf6652770400220410acf9b8b0ed242833492b5973020eeef78d3dcd81f9f25e9e1d3d137274d3041210379cb3d35c712cebbf609d2ce6b1c0d4b70dd27bbb3a9b0bd5491a5954aeb4687ffffffff5bce5cd093a1bf51beecc999c8b72beafc7037b5b573d30996e6a10aaa4b2afb020000006b483045022100b7abe253b84f19407b223d57b47ff4e472747feec0797c545598c5eb7fe5dc5f0220160e9410deae317bfaf51f62e5c82e83ce658685da506e3ab62e435e0305fb3141210379cb3d35c712cebbf609d2ce6b1c0d4b70dd27bbb3a9b0bd5491a5954aeb4687ffffffff5bce5cd093a1bf51beecc999c8b72beafc7037b5b573d30996e6a10aaa4b2afb030000006b483045022100cf29ad3390631bd221e6f9fa3defe7bc99e2ffce5ebd5ce4bc7ad5aab320da78022036806de1ed220e886db15727bca97716a9b543b8c1cd062a84f9881168be9f0d41210379cb3d35c712cebbf609d2ce6b1c0d4b70dd27bbb3a9b0bd5491a5954aeb4687ffffffff040000000000000000376a04534c500001010453454e442002e0c4057b9d5962ca5d51d4fa2bd814e11e7e3f98afcf5b19be7966c68027ad08000000000000000022020000000000001976a914b6da30c8b976a56f4943374f11bab4a72f94137188ac22020000000000001976a914b6da30c8b976a56f4943374f11bab4a72f94137188aca8570000000000001976a914b6da30c8b976a56f4943374f11bab4a72f94137188ac00000000",
                BlockHash = "000000000000000004391adddbbe8a00c15240682dd5954fb6dd8cd9e1ca4b69",
                Confirmations = 52186,
                Time = 1617055596,
                BlockTime = 1617055596,
                BlockHeight = 680895,
                IsSlpTx = true,
                TokenTxType = "SEND",
                TokenId = "02e0c4057b9d5962ca5d51d4fa2bd814e11e7e3f98afcf5b19be7966c68027ad",
                TokenType = 1,
                TokenTicker = "SNC",
                TokenName = "Sincretica",
                TokenDecimals = 0,
                TokenUri = "mint.bitcoin.com",
                TokenDocHash = "",
                IsValidSlp = true
            }
        };
        Assert.IsTrue(info != null, "Info is not empty");
        Console.WriteLine($"Hash: {info.ToJsonFormat()}");
    }
}