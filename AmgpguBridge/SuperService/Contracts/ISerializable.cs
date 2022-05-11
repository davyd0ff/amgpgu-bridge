namespace AmgpguBridge.SuperService.Contracts;
public interface ISerializable
{
  string Serialize(ISerializer serializer);
}