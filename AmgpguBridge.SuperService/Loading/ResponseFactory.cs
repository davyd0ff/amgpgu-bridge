using AmgpguBridge.SuperService.Packing;

namespace AmgpguBridge.SuperService.Loading;

public class ResponseFactory
{
  private JwtMessageBuilder _jwtMessageBuilder;
  public ResponseFactory(JwtMessageBuilder jwtMessageBuilder)
  {
    this._jwtMessageBuilder = jwtMessageBuilder;
  }

  public IResponse GetConcreteResponse(SuperserviceResponse response)
  {
    if (IsNotEmpty(response.Error)) return new ErrorResponse(response.Error);
    if (IsNotEmpty(response.ResponseToken)) return new InfoResponse(this._jwtMessageBuilder.SetEncodedJwtMessage(response.ResponseToken).GetResult());
    if (IsNotEmpty(response.Result)) return new SuccessResponse(response.IdJwt);
    if (IsNotEmpty(response.IdJwt)) return new SuccessResponse(response.IdJwt);
    if (IsNotEmpty(response.Exception)) return new ExceptionResponse(response.Exception);

    // todo develop: Добавь внятное исключение
    throw new Exception("Нет реализации для текущего ответа");
  }

  private bool IsNotEmpty(string property)
  {
    return !string.IsNullOrEmpty(property);
  }

  private bool IsNotEmpty(Exception exception)
  {
    return exception != null;
  }
}
