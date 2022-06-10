using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class UnreachLoadEntityStrategy : IQueueMoveStrategy
{
  private readonly IResponse _response;

  public UnreachLoadEntityStrategy(IResponse response)
  {
    this._response = response;
  }

  public void MoveQueueMessage(QueueMessage queueMessage, IQueueWriter queueWriter)
  {
    // todo develop: подумать про количество попыток, которые сообщение уже отправляется повторно
    queueMessage.Status = QueueMessageStatus.Processing;
    queueMessage.Error = this._response.GetData();

    // todo develop: подумать над тем, как будет вести себя программа, если из одной UniversityEntity должно будет создано несколько SuperserviceEntities (напримере План набора)
    queueWriter.Write(queueMessage.QueueName, queueMessage);
  }
}
