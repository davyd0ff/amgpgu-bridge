using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class SuccessConfirmStrategy : IQueueMoveStrategy
{
  public void MoveQueueMessage(QueueMessage queueMessage, IQueueWriter queueWriter)
  {
    queueMessage.Status = QueueMessageStatus.Done;

    queueWriter.Write(QueueName.Database, queueMessage);
  }
}
