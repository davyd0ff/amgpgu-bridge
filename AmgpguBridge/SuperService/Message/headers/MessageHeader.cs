using AmgpguBridge.SuperService.Contracts;

namespace AmgpguBridge.SuperService.Message;
public abstract class MessageHeader : ISerializable
{
  public string Serialize(ISerializer serializer)
  {
    return serializer.Serialize(this);
  }
}
