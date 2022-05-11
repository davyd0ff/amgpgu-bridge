using AmgpguBridge.Queue.General;

namespace AmgpguBridge.Queue.Contracts;
public interface IQueueManager
{
  void AddQueueListener(QueueName queueName, Action<IQueueMessage> callback);
}