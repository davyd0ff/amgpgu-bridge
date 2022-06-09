using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueStrategies;

public class SuccessConfirmStrategy : IQueueStrategy
{
  public void MoveQueueMessage(QueueMessage queueMessage, IQueueWriter queueWriter, IResponse response)
  {
    queueMessage.Status = QueueMessageStatus.Done;

    queueWriter.Write(QueueName.Database, queueMessage);
  }
}
