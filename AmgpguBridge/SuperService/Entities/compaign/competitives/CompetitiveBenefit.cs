namespace AmgpguBridge.SuperService.Entities;

public class CompetitiveBenefit : Entity {
  public string UidCompetitiveGroup { get; set; }
  public int IdBenefit { get; set; }
  public int IdOlympicDiplomaType { get; set; }
  public int EgeMinValue { get; set; }
  public int IdOlympicType { get; set; }
  public IEnumerable<OlympicLevel> IdOlympicLevels { get; set; }
  public IEnumerable<OlympicLevel> OlympicLevels { get; set; }

  public override string GetName() {
    return "CompetitiveBenefit";
  }
}

public class OlympicLevel {
  public int IdOlympicLevel { get; set; }
}

public class OlympicProfile {
  public int IdOlympicProfile { get; set; }
}