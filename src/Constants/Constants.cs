namespace Cash.NetCore.Constants;

internal static class Headers
{
    public const string Authorization = "Authorization";
    public const string ContentType = "Content-Type";
    public const string Accept = "Accept";
    public const string Bearer = "Bearer";
}

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

    public const string GetMempoolEntry = "/getMempoolEntry"; // TODO: for clarification

    public const string GetDifficulty = "/getDifficulty";
    public const string GetMempoolInfo = "/getMempoolInfo";

    public const string GetBlockHeader = "/getBlockHeader";

    public const string GetRawMempool = "/getRawMempool"; // TODO: for clarification


}

internal static class ControlModuleAction
{
    public const string Getnetworkinfo = "/getnetworkinfo";
}