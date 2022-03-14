
namespace Cash.NetCore.Services;

/// <summary>
/// Base Http Client
/// </summary>
public class BaseHttpClient
{
    /// <summary>
    /// HttpClient
    /// </summary>
    protected readonly HttpClient CashHttpClient;

    /// <summary>
    /// CashConfiguration 
    /// </summary>
    protected readonly CashConfiguration CashConfiguration;

    /// <summary>
    /// BaseHttpClient
    /// </summary>
    /// <param name="cashHttpClient"></param>
    /// <param name="cashConfiguration"></param>
    public BaseHttpClient(HttpClient cashHttpClient, CashConfiguration cashConfiguration)
    {
        CashHttpClient = cashHttpClient;
        CashConfiguration = cashConfiguration;
    }
}