using AmgpguBridge.Queue.Contracts;
using AmgpguBridge.Queue.General;

namespace AmgpguBridge.Queue.Implementions;
public class QueueWriter : IQueueWriter
{
  public void Write(QueueName queueName, IQueueMessage message)
  {
    throw new NotImplementedException();
  }
}
