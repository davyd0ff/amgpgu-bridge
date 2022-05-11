using AmgpguBridge.SuperService.Contracts;
using AmgpguBridge.SuperService.Message;

namespace AmgpguBridge.SuperService;
public class Container : ISerializable
{
  public string Entity { get; }
  public string IdJwt { get; }
  public JwtMessage JwtMessage { get; }

  public Container() { }

  public Container(Container container, string entity = null, string idJwt = null, JwtMessage jwtMessage = null)
  {
    this.Entity = entity ?? container.Entity;
    this.IdJwt = idJwt ?? container.IdJwt;
    this.JwtMessage = jwtMessage ?? container.JwtMessage;
  }

  public string Serialize(ISerializer serializer)
  {
    return serializer.Serialize(this);
  }
}
