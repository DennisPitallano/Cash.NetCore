namespace Cash.NetCore.Models.Response.PsfSlp;

/// <summary>
///     IndexerStatus
/// </summary>
public class IndexerStatus
{
    /// <summary>
    ///     status
    /// </summary>
    [JsonPropertyName("status")]
    public Indexes? Status { get; set; }
}

/// <summary>
/// Indexes
/// </summary>
public class Indexes
{
    /// <summary>
    ///     startBlockHeight
    /// </summary>
    [JsonPropertyName("startBlockHeight")]
    public long StartBlockHeight { get; set; }

    /// <summary>
    ///     syncedBlockHeight
    /// </summary>
    [JsonPropertyName("syncedBlockHeight")]
    public long SyncedBlockHeight { get; set; }

    /// <summary>
    ///     chainBlockHeight
    /// </summary>
    [JsonPropertyName("chainBlockHeight")]
    public long ChainBlockHeight { get; set; }
}