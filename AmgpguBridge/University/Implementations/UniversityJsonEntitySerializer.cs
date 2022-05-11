using AmgpguBridge.University.Contracts;
using AmgpguBridge.University.Entities;

namespace AmgpguBridge.University.Implementations;
public class UniversityJsonEntitySerializer : IUniversityEntitySerializer
{
  public TUEntity Deserialize<TUEntity>(string data) where TUEntity : Entity
  {
    throw new System.NotImplementedException();
  }
}
