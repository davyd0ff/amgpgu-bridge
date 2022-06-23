namespace AmgpguBridge.SuperService.Entities.SuperService;

public class Competitive : Entity {
  public string Uid { get; set; }
  public string UidCampaign { get; set; }
  public string Name { get; set; }
  public int IdLevelBudget { get; set; }
  public int IdEducationLevel { get; set; }
  public int IdEducationSource { get; set; }
  public int IdEducationForm { get; set; }
  public int IdDirection { get; set; }
  public int AdmissionNumber { get; set; }
  public string Comment { get; set; }

  public override string GetName() {
    return "Competitive";
  }
}