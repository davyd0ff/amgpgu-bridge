namespace AmgpguBridge.SuperService.Message;
public class JwtMessageHeader : MessageHeader
{
  public readonly string Ogrn;
  public readonly string Kpp;
  public readonly SuperServiceAction Action;
  public readonly string IdJwt;

  public JwtMessageHeader(SuperServiceAction action,
    string idJwt,
    string ogrn,
    string kpp)
  {
    this.Action = action;
    this.IdJwt = idJwt;
    this.Ogrn = ogrn;
    this.Kpp = kpp;
  }
}