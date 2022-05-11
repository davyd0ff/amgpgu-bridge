using System.Net;

namespace AmgpguBridge.SuperService.Loading;

public class ExceptionResponse : IResponse
{
  private readonly HttpStatusCode _statusCode;
  private readonly string _message;
  public ExceptionResponse(HttpRequestException exception)
  {
    this._statusCode = exception.StatusCode.Value;
  }

  public string GetData()
  {
    return this._message;
  }

  public ResponseType GetResponseType()
  {
    return IsStatusCodeAsUnreachedRequest() ? ResponseType.Unreach : ResponseType.Fail;
  }

  private bool IsStatusCodeAsUnreachedRequest()
  {
    var unreachedStatusCodes = new List<HttpStatusCode> {
      HttpStatusCode.BadGateway,
      HttpStatusCode.GatewayTimeout,
      HttpStatusCode.InsufficientStorage,
      HttpStatusCode.InternalServerError,
      HttpStatusCode.Locked,
      HttpStatusCode.NotFound,
      HttpStatusCode.RequestTimeout,
      HttpStatusCode.TooManyRequests,
      HttpStatusCode.ServiceUnavailable
    };

    return unreachedStatusCodes.Exists(code => code.Equals(this._statusCode));
  }
}
