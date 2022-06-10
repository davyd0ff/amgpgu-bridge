using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class SuccessGetInfoStrategy : IQueueMoveStrategy
{
  public void MoveQueueMessage(QueueMessage queueMessage, IQueueWriter queueWriter)
  {
    queueMessage.Status = QueueMessageStatus.Processing;

    queueWriter.Write(QueueName.SuperServiceMessageConfirm, queueMessage);
  }
}
