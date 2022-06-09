using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueStrategies;

public class FailConfirmStrategy : IQueueStrategy
{
  public void MoveQueueMessage(
    QueueMessage queueMessage, 
    IQueueWriter queueWriter,
    IResponse response
  )
  {
    queueMessage.Status = QueueMessageStatus.Unconfirmed;
    queueMessage.Error = response.GetData();

    queueWriter.Write(QueueName.Database, queueMessage);
  }
}
