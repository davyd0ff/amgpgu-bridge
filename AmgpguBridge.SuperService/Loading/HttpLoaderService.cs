using AmgpguBridge.SuperService.Packing;
using AmgpguBridge.SuperService.Serializing;

namespace AmgpguBridge.SuperService.Loading;

public class HttpLoaderService : ILoader
{
  private readonly Uri _baseAddress;
  private readonly IHttpPostClient _postClient;
  private readonly ISerializer _serializer;

  public HttpLoaderService(Uri baseAddress, IHttpPostClient postClient, ISerializer serializer)
  {
    this._baseAddress = baseAddress;
    this._postClient = postClient;
    this._serializer = serializer;
  }

  public IResponse Load(string action, JwtToken jwtToken)
  {
    try
    {
      var response = this._postClient.Post(new Uri(this._baseAddress, action), jwtToken.Serialize(this._serializer)).GetAwaiter().GetResult();
      return this._serializer.Deserialize<ResponseFactory>(response).GetResponse();
    }
    catch (HttpRequestException exception)
    {
      return new ResponseFactory(exception).GetResponse();
    }
  }
}
