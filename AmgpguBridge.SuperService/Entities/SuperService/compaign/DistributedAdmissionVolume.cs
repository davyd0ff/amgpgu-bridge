namespace AmgpguBridge.SuperService.Entities.SuperService;

public class DistributedAdmissionVolume : Entity {
  public string Uid { get; set; }
  public string UidAdmissionVolume { get; set; }
  public int IdDirection { get; set; }
  public int IdLevelBudget { get; set; }
  public int Budget_o { get; set; }
  public int Budget_oz { get; set; }
  public int Budget_z { get; set; }
  public int Quota_o { get; set; }
  public int Quota_oz { get; set; }
  public int Quota_z { get; set; }
  public int Paid_o { get; set; }
  public int Paid_oz { get; set; }
  public int Paid_z { get; set; }
  public int Target_o { get; set; }
  public int Target_oz { get; set; }
  public int Target_z { get; set; }

  public override string GetName() {
    return "DistributedAdmissionVolume";
  }
}