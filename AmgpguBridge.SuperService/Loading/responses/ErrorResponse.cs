namespace AmgpguBridge.SuperService.Loading;
public class ErrorResponse : IResponse
{
  private string _data;

  public ErrorResponse(string error)
  {
    this._data = error;
  }

  public string GetData()
  {
    return this._data;
  }

  public ResponseType GetResponseType()
  {
    return ResponseType.Error;
  }
}