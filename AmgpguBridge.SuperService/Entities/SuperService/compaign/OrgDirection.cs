using AmgpguBridge.SuperService.Entities.SuperService;

namespace AmgpguBridge.SuperService.Entities;

public class OrgDirection : Entity {
  public string Uid { get; set; }
  public int IdDirection { get; set; }
  public IEnumerable<DirectionParamsValue> DirectionParamsValues { get; set; }

  public override string GetName() {
    return "OrgDirection";
  }
}