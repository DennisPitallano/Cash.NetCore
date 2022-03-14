namespace Cash.NetCore.Models.Response.BlockChain
{
    /// <summary>
    /// ChainTip
    /// </summary>
    public class ChainTip
    {
        /// <summary>
        /// Height
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; set; }

        /// <summary>
        /// Hash
        /// </summary>
        [JsonPropertyName("hash")]
        public string? Hash { get; set; }

        /// <summary>
        /// BranchLen
        /// </summary>
        [JsonPropertyName("branchlen")]
        public int BranchLen { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }
    }
}