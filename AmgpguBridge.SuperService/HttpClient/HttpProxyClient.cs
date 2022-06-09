using AmgpguBridge.SuperService.Serializing;

namespace AmgpguBridge.SuperService.HttpClient;

public class HttpProxyClient : IHttpPostClient
{
  private readonly Uri _proxyAddress;
  private readonly IHttpPostClient _httpClient;

  public HttpProxyClient(Uri proxyAddress, IHttpPostClient httpClient)
  {
    _proxyAddress = proxyAddress;
    _httpClient = httpClient;
  }

  public Task<string> Post(Uri uri, string serializedData)
  {
    return _httpClient.Post(_proxyAddress, MakeJsonRequestEntity(uri, serializedData));
  }

  private string MakeJsonRequestEntity(Uri address, string payload)
  {
    var serializer = new JsonSerializer();
    return serializer.Serialize(new
    {
      Address = address,
      Payload = payload,
      Method = "Post"
    });
  }
}
