namespace AmgpguBridge.SuperService.Loading;
public class SuccessResponse : IResponse
{
  private string _idJwt;

  public SuccessResponse(string idJwt)
  {
    this._idJwt = idJwt;
  }

  public string GetData()
  {
    return this._idJwt;
  }

  public ResponseType GetResponseType()
  {
    return ResponseType.Success;
  }
}
