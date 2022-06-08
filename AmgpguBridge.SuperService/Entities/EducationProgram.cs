namespace AmgpguBridge.SuperService.Entities;

public class EducationProgram : Entity {
  public string Uid { get; set; }
  public string Name { get; set; }
  public int IdEducationForm { get; set; }
  public int IdDirection { get; set; }

  public override string GetName() {
    return "EducationProgram";
  }
}