namespace AmgpguBridge.SuperService.Loading;
public class FailResponse : IResponse
{
  private readonly string _data;

  public FailResponse(string data)
  {
    this._data = data;
  }

  public string GetData()
  {
    return this._data;
  }

  public ResponseType GetResponseType()
  {
    return ResponseType.Fail;
  }
}
