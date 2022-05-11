using AmgpguBridge.SuperService.Message;

namespace AmgpguBridge.SuperService.Loading;

public class ResponseFactory {
  public string IdJwt { get; set; }
  public string ResponseToken { get; set; }
  public string Error { get; set; }
  public string Result { get; set; }
  public HttpRequestException Exception { get; set; }

  public ResponseFactory() { }

  public ResponseFactory(HttpRequestException exception) {
    this.Exception = exception;
  }

  public IResponse GetResponse() {
    if (IsNotEmpty(this.Error)) return new ErrorResponse(this.Error);
    if (IsNotEmpty(this.ResponseToken)) return new InfoResponse(new JwtMessage(this.ResponseToken));
    if (IsNotEmpty(this.Result)) return new SuccessResponse(this.IdJwt);
    if (IsNotEmpty(this.IdJwt)) return new SuccessResponse(this.IdJwt);
    if (IsNotEmpty(this.Exception)) return new ExceptionResponse(this.Exception);

    // todo develop: Добавь внятное исключение
    throw new Exception("Нет реализации для текущего ответа");
  }

  private bool IsNotEmpty(string property) {
    return !string.IsNullOrEmpty(property);
  }

  private bool IsNotEmpty(Exception exception) {
    return this.Exception != null;
  }
}