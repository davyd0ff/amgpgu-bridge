using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueStrategies;

public class FailGetInfoStrategy : IQueueStrategy
{
  public void MoveQueueMessage(
    QueueMessage queueMessage,
    IQueueWriter queueWriter,
    IResponse response
  )
  {
    queueMessage.Status = QueueMessageStatus.Error;
    queueMessage.Error = response.GetData();

    queueWriter.Write(QueueName.Database, queueMessage);
  }
}
