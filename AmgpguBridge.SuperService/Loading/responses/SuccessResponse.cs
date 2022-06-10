namespace AmgpguBridge.SuperService.Loading;
public class SuccessResponse : IResponse
{
  private int _idJwt;

  public SuccessResponse(int idJwt)
  {
    this._idJwt = idJwt;
  }

  public string GetData()
  {
    return this._idJwt.ToString();
  }

  public ResponseType GetResponseType()
  {
    return ResponseType.Success;
  }
}
