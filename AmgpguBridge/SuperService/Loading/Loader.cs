using AmgpguBridge.SuperService.Contracts;
using AmgpguBridge.SuperService.Message;

namespace AmgpguBridge.SuperService.Loading;
public class Loader
{
  private readonly Uri _baseAddress;
  private readonly IHttpPostClient _postClient;

  public Loader(Uri baseAddress, IHttpPostClient postClient)
  {
    this._baseAddress = baseAddress;
    this._postClient = postClient;
  }

  public async Task<IResponse> Load(string action, JwtMessage message)
  {
    try
    {
      var response = await this._postClient.Post(new Uri(this._baseAddress, action), new Dictionary<string, string>
      {
        ["Accept"] = "application/json",
        ["Content-Type"] = "application/json"
      }, message.ToByte());
      return new JsonSerializer().Deserialize<ResponseFactory>(response).GetResponse();
    }
    catch (HttpRequestException exception)
    {
      return new ResponseFactory(exception).GetResponse();
    }
    // var response = await this._postClient.Post(new Uri(this._baseAddress, action), new Dictionary<string, string> {
    //     ["Accept"] = "application/json",
    //     ["Content-Type"] = "application/json"
    //   }, message.ToByte())
    //   .ContinueWith(
    //     success => new JsonSerializer().Deserialize<ResponseFactory>(success.Result).GetResponse(),
    //     TaskContinuationOptions.OnlyOnRanToCompletion)
    //   .ContinueWith(
    //     error => new ResponseFactory(error.Exception).GetResponse(),
    //     TaskContinuationOptions.OnlyOnFaulted);
    // return response;
  }
}