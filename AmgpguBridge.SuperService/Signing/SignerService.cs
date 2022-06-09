using AmgpguBridge.SuperService.HttpClient;

namespace AmgpguBridge.SuperService.Signing;

public class SignerService : ISigner
{
  private readonly IHttpPostClient _httpClient;
  private readonly Uri _uri;

  public SignerService(Uri uri, IHttpPostClient httpClient)
  {
    this._uri = uri;
    this._httpClient = httpClient;
  }

  public string Sign(string message)
  {
    var response = this._httpClient.Post(this._uri, message).GetAwaiter().GetResult();
    return response;
  }
}
