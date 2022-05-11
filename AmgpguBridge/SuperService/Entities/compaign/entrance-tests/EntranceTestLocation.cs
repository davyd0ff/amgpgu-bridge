namespace AmgpguBridge.SuperService.Entities;

// Время и место проведения экзамена
public class EntranceTestLocation {
  public string Uid { get; set; }
  public string UidEntranceTest { get; set; }
  public DateTime TestDate { get; set; }
  public string TestLocation { get; set; }
  public int EntrantsCount { get; set; }
}