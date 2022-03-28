namespace Cash.NetCore.Constants;

internal static class ContentTypes
{
    public const string FormUrlEncoded = "application/x-www-form-urlencoded";
    public const string MultiPartFormData = "multipart/form-data";
    public const string Json = "application/json";
}

internal static class Versions
{
    public const string V5 = "/v5";
}

internal static class CashModule
{
    public const string BlockChain = $"{Versions.V5}/blockchain";
    public const string Control = $"{Versions.V5}/control";
    public const string ElectrumX = $"{Versions.V5}/electrumx";
    public const string Encryption = $"{Versions.V5}/encryption";
    public const string Mining = $"{Versions.V5}/mining";
    public const string PsfSlp = $"{Versions.V5}/psf/slp"; 
    public const string Price = $"{Versions.V5}/price";
    public const string RawTransaction = $"{Versions.V5}/rawtransactions";
    public const string Slp = $"{Versions.V5}/slp";
    public const string Util = $"{Versions.V5}/util";
}

internal static class BlockChainModuleAction
{
    public const string GetBlockChainBlockCount = "/getBlockCount";
    public const string GetChainTips = "/getChainTips";

    public const string GetMempoolAncestors = "/getMempoolAncestors"; // TODO: for clarification
    public const string GetTxOutProofSingle = "/getTxOutProofSingle"; // TODO: for clarification

    public const string GetTxOut = "/getTxOut";
    public const string GetBestBlockHash = "/getBestBlockHash";
    public const string GetBlock = "/getBlock";
    public const string GetBlockHash = "/getBlockHash";
    public const string GetBlockchainInfo = "/getBlockchainInfo";

    public const string GetMempoolEntry = "/getMempoolEntry";

    public const string GetDifficulty = "/getDifficulty";
    public const string GetMempoolInfo = "/getMempoolInfo";

    public const string GetBlockHeader = "/getBlockHeader";

    public const string GetRawMempool = "/getRawMempool"; // TODO: for clarification
}

internal static class ControlModuleAction
{
    public const string Getnetworkinfo = "/getnetworkinfo";
}

internal static class DsProofModuleAction
{
    public const string GetDsProof = "/getdsproof"; // TODO: for clarification
}

internal static class ElectrumXModuleAction
{
    public const string GetDsProof = "/tx/broadcast"; // TODO: for clarification

    public const string GetElectrumXBlockHeadersCount = "/block/headers";

    public const string GetBalance = "/balance";

    public const string GetTransactions = "/transactions";

    public const string  GetTransactionDetails = "/tx/data";

    public const string GetUnConfirmed = "/unconfirmed";

    public const string GetUnConfirmedTransactions = "/utxos";
}

internal static class EncryptionModuleAction
{
    public const string PublicKey = "/publickey";
}

internal static class MiningModuleAction
{
    public const string GetMiningInfo = "/getmininginfo";
    public const string GetNetworkHashps = "/getNetworkHashps";
}

internal static class PsfSlpModuleAction
{
    public const string Status = "/status";
    public const string Token = "/token";
    public const string Address = "/address";
    public const string TransactionId = "/txid";
}

internal static class PriceModuleAction
{
    public const string GetRates = "/rates";
    public const string GetBchUsdPrice = "/usd";
    public const string GeteCashUsdPrice = "/bchausd";
}


internal static class RawTransactionModuleAction
{
    public const string DecodeScript = "/decodeScript";
    public const string DecodeRawTransaction = "/decodeRawTransaction";
    public const string GetRawTransaction = "/getRawTransaction";

    public const string SendRawTransaction = "/sendRawTransaction"; // TODO : for clarification
}

internal static class SlpModuleAction
{
    public const string SlpConvert= "/convert";
    public const string SlpWhitelist = "/whitelist";
    public const string ValidateTxid2 = "/validateTxid2"; // TODO: for clarification

    public const string GenerateSendOpReturn = "/generateSendOpReturn"; // TODO: for clarification
}

internal static class UtilModuleAction
{
    public const string ValidateAddress= "/validateAddress";
}
