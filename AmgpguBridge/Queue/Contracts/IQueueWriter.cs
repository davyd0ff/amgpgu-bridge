using AmgpguBridge.Queue.General;

namespace AmgpguBridge.Queue.Contracts;
public interface IQueueWriter
{
  void Write(QueueName queueName, IQueueMessage queueMessage);
}