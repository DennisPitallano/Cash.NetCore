namespace Cash.NetCore.Extensions;

/// <summary>
/// 
/// </summary>
public static class ObjectExtensions
{
    private static IDictionary<string, object>? ToDictionary(this object request)
    {
        var jsonFormat = request.ToJsonFormat();
        return JsonSerializer.Deserialize<Dictionary<string, object>>(jsonFormat);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ToJsonFormat(this object? obj)
    {
        return JsonSerializer.Serialize(obj);
    }
}