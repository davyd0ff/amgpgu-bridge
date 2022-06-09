using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueStrategies;

public class UnreachLoadEntityStrategy : IQueueStrategy
{
  public void MoveQueueMessage(QueueMessage queueMessage, IQueueWriter queueWriter, IResponse response)
  {
    // todo develop: подумать про количество попыток, которые сообщение уже отправляется повторно
    queueMessage.Status = QueueMessageStatus.Processing;
    queueMessage.Error = response.GetData();

    // todo develop: подумать над тем, как будет вести себя программа, если из одной UniversityEntity должно будет создано несколько SuperserviceEntities (напримере План набора)
    queueWriter.Write(queueMessage.QueueName, queueMessage);
  }
}
