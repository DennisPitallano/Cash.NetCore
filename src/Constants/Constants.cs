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
}

internal static class BlockChainModuleAction
{
    public static string GetBlockChainBlockCount = "/getBlockCount";
    public static string GetChainTips = "/getChainTips";

    public static string GetMempoolAncestors = "/getMempoolAncestors"; // TODO: for clarification
    public static string GetTxOutProofSingle = "/getTxOutProofSingle"; // TODO: for clarification

    public static string GetTxOut = "/getTxOut";
    public static string GetBestBlockHash = "/getBestBlockHash";
    public static string GetBlock = "/getBlock";
    public static string GetBlockHash = "/getBlockHash";
    public static string GetBlockchainInfo = "/getBlockchainInfo";
}
