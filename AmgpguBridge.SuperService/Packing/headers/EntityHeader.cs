namespace AmgpguBridge.SuperService.Packing;

public class EntityHeader : MessageHeader
{
  public readonly string EntityType;

  public EntityHeader(SuperServiceAction action, string entityType, string ogrn, string kpp) : base(action, ogrn, kpp)
  {
    this.EntityType = entityType;
  }
}
