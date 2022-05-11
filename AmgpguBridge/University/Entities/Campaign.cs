namespace AmgpguBridge.University.Entities;
public class Campaign : Entity
{
  public string Code { get; set; }
  public string Uid { get; set; }
  public string Name { get; set; }
  public string Comment { get; set; }
  public int NumberAgreement { get; set; }
  public int TotalApplications { get; set; }
}