using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueStrategies;

public class UnreachConfirmStrategy : IQueueStrategy
{
  public void MoveQueueMessage(QueueMessage queueMessage, IQueueWriter queueWriter, IResponse response)
  {
    queueMessage.Status = QueueMessageStatus.Processing;
    queueMessage.Error = response.GetData();

    queueWriter.Write(QueueName.SuperServiceMessageConfirm, queueMessage);
  }
}
