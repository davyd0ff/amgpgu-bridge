namespace AmgpguBridge.SuperService.Entities.SuperService;

// Сроки приема
public class TermsAdmission : Entity {
  public string Uid { get; set; }
  public string UidCompaign { get; set; }
  public string EventOrg { get; set; }
  public int IdTermsAdmissionMatch { get; set; }
  public int IdStage { get; set; }
  public DateTime StartEvent { get; set; }
  public DateTime EndEvent { get; set; }

  public override string GetName() {
    return "TermsAdmission";
  }
}