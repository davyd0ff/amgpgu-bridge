namespace AmgpguBridge.SuperService.Queue;

public interface IQueueManager
{
  void AddQueueListener(QueueName queueName, Action<QueueMessage> listener);
}
