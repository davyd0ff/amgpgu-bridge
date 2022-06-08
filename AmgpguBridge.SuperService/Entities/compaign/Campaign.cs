namespace AmgpguBridge.SuperService.Entities;

public class Campaign : Entity
{
  public int IdAcademicYear { get; set; }
  public int IdCampaignStatus { get; set; }
  public int IdEducationForm { get; set; }
  public int IdOrderAdmissionProcedure { get; set; }
  public string Uid { get; set; }
  public string Name { get; set; }
  public int NumberAgree { get; set; }
  public int CountDirections { get; set; }
  public int TotalMaxScoreAchievements { get; set; }
  public DateTime EndDate { get; set; }
  public IEnumerable<EducationLevel> EducationLevels { get; set; }

  public override string GetName()
  {
    return "Campaign";
  }
}