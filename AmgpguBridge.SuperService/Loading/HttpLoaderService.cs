using AmgpguBridge.SuperService.HttpClient;
using AmgpguBridge.SuperService.Packing;
using AmgpguBridge.SuperService.Serializing;

namespace AmgpguBridge.SuperService.Loading;

public class HttpLoaderService : ILoader
{
  private readonly Uri _baseAddress;
  private readonly IHttpPostClient _postClient;
  private readonly ISerializer _serializer;
  private readonly ResponseFactory _responseFactory;

  public HttpLoaderService(Uri baseAddress, IHttpPostClient postClient, ISerializer serializer, ResponseFactory responseFactory)
  {
    this._baseAddress = baseAddress;
    this._postClient = postClient;
    this._serializer = serializer;
    this._responseFactory = responseFactory;
  }

  public IResponse Load(string action, JwtToken jwtToken)
  {
    SuperserviceResponse superserviceResponse;
    try
    {
      var response = this._postClient.Post(new Uri(this._baseAddress, action), jwtToken.Serialize(this._serializer)).GetAwaiter().GetResult();
      superserviceResponse = this._serializer.Deserialize<SuperserviceResponse>(response);
    }
    catch (HttpRequestException exception)
    {
      superserviceResponse = new SuperserviceResponse(exception);
    }
    return this._responseFactory.GetConcreteResponse(superserviceResponse);
  }
}
