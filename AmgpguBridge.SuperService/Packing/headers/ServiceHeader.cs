namespace AmgpguBridge.SuperService.Packing;

public class ServiceHeader : MessageHeader
{

  public readonly string IdJwt;


  public ServiceHeader(SuperServiceAction action, string idJwt, string ogrn, string kpp) : base(action, ogrn, kpp)
  {
    this.IdJwt = idJwt;
  }
}
