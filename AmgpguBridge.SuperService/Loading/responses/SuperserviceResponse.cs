namespace AmgpguBridge.SuperService.Loading;

public class SuperserviceResponse
{
  public int IdJwt { get; set; }
  public string ResponseToken { get; set; }
  public string Error { get; set; }
  public string Result { get; set; }
  public HttpRequestException Exception { get; set; }

  public SuperserviceResponse() { }
  public SuperserviceResponse(HttpRequestException exception) { 
    this.Exception = exception;
  }
}
