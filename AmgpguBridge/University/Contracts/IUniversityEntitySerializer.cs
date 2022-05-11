namespace AmgpguBridge.University.Contracts;
public interface IUniversityEntitySerializer
{
  TUEntity Deserialize<TUEntity>(string data) where TUEntity : Entities.Entity;
}
