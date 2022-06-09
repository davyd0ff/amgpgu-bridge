namespace AmgpguBridge.SuperService.Queue;

public interface IQueueWriter
{
  void Write(QueueName queueName, QueueMessage message);
}
