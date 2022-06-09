using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueStrategies;

public class UnreachGetInfoStrategy : IQueueStrategy
{
  public void MoveQueueMessage(QueueMessage queueMessage, IQueueWriter queueWriter, IResponse response)
  {
    queueMessage.Status = QueueMessageStatus.Processing;
    queueMessage.Error = response.GetData();

    queueWriter.Write(QueueName.SuperServiceGetMessageInfo, queueMessage);
  }
}
