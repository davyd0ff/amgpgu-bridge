namespace AmgpguBridge.SuperService.Message;
public class EntityHeader : MessageHeader
{
  public readonly SuperServiceAction Action;
  public readonly string Ogrn;
  public readonly string EntityType;
  public readonly string Kpp;

  public EntityHeader(
    SuperServiceAction action,
    string entityType,
    string ogrn,
    string kpp)
  {
    this.Action = action;
    this.EntityType = entityType;
    this.Ogrn = ogrn;
    this.Kpp = kpp;
  }

  public string GetJson()
  {
    throw new NotImplementedException();
  }
}