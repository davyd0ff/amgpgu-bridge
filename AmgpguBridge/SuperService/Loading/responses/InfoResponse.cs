using AmgpguBridge.SuperService.Message;

namespace AmgpguBridge.SuperService.Loading;
public class InfoResponse : IResponse
{
  private JwtMessage _jwt;

  public InfoResponse(JwtMessage jwt)
  {
    this._jwt = jwt;
  }

  public string GetData()
  {
    return this._jwt.Payload;
  }

  public ResponseType GetResponseType()
  {
    return IsJwtHeaderAsErrorResponse() ? ResponseType.Error : ResponseType.Success;
  }

  private bool IsJwtHeaderAsErrorResponse()
  {
    var jsonSerializer = new JsonSerializer();
    var header = jsonSerializer.Deserialize<ResponseHeader>(this._jwt.Header);
    return header.PayloadType.Equals("Error");
  }

  private class ResponseHeader
  {
    public string IdJwt { get; set; }
    public string PayloadType { get; set; }
    public string EntityType { get; set; }
    public string Action { get; set; }
  }
}