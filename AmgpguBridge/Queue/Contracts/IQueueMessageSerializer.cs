namespace AmgpguBridge.Queue.Contracts;
public interface IQueueMessageSerializer
{
  string Serialize(IQueueMessage message);
  IQueueMessage Deserialize(string message);
  IQueueMessage Deserialize(byte[] message);
}
