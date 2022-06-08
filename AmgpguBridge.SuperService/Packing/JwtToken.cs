using AmgpguBridge.SuperService.Serializing;

namespace AmgpguBridge.SuperService.Packing;

public class JwtToken : ISerializable
{
  private readonly JwtMessage _jwtMessage;

  public JwtToken(JwtMessage jwtMessage)
  {
    _jwtMessage = jwtMessage;
  }

  public string Serialize(ISerializer serializer)
  {
    return serializer.Serialize(new { token = this._jwtMessage.ToString() });
  }
}
