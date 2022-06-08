namespace AmgpguBridge.SuperService.Serializing;

public interface ISerializable
{
  string Serialize(ISerializer serializer);
}
