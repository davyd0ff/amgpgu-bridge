using AmgpguBridge.Queue.Contracts;

namespace AmgpguBridge.Queue.Implementions;
public class RabbitMQJsonSerializer : IQueueMessageSerializer
{
  public string Serialize(IQueueMessage message)
  {
    throw new System.NotImplementedException();
  }

  public IQueueMessage Deserialize(byte[] message)
  {
    throw new System.NotImplementedException();
  }

  public IQueueMessage Deserialize(string message)
  {
    throw new System.NotImplementedException();
  }
}