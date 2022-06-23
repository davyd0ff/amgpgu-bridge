namespace AmgpguBridge.SuperService.Entities.SuperService;

// Вступительные испытания
public class EntranceTest {
  public string Uid { get; set; }
  public string UidCompetitiveGroup { get; set; }
  public int IdEntranceTestType { get; set; }
  public string TestName { get; set; }
  public bool IsEge { get; set; }
  public int MinScore { get; set; }
  public int Priority { get; set; }

  public int IdSubject { get; set; }

  // todo ask: а если несколько замещаемых предметов?
  public string UidReplaceEntranceTest { get; set; }
}