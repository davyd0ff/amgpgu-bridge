using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueStrategies;

public class SuccessGetInfoStrategy : IQueueStrategy
{
  public void MoveQueueMessage(QueueMessage queueMessage, IQueueWriter queueWriter, IResponse response)
  {
    queueMessage.Status = QueueMessageStatus.Processing;

    queueWriter.Write(QueueName.SuperServiceMessageConfirm, queueMessage);
  }
}
