using AmgpguBridge.SuperService.Entities.SuperService;

namespace AmgpguBridge.SuperService.Entities.SuperService;

// хз я так понимаю это ИД
public class CmpAchievement : Entity {
  public string Uid { get; set; }
  public string UidCampaign { get; set; }
  public int IdCategory { get; set; }
  public int IdBenefit { get; set; }
  public int IdOlympicDiplomaType { get; set; }
  public string Name { get; set; }
  public int MaxValue { get; set; }
  public int EgeMinValue { get; set; }

  public override string GetName() {
    return "CmpAchievement";
  }
}