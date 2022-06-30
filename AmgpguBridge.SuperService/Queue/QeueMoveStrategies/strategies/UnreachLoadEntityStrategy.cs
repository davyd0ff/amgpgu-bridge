using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class UnreachLoadEntityStrategy : IQueueMoveStrategy
{
  private readonly IResponse _response;
  private IQueueWriter _queueWriter;

  public UnreachLoadEntityStrategy(IResponse response, IQueueWriter queueWriter)
  {
    this._response = response;
    this._queueWriter = queueWriter;
  }

  public void MoveQueueMessage(QueueMessage queueMessage)
  {
    // todo develop: подумать про количество попыток, которые сообщение уже отправляется повторно
    queueMessage.Status = QueueMessageStatus.Processing;
    queueMessage.Error = this._response.GetData();

    // todo develop: подумать над тем, как будет вести себя программа, если из одной UniversityEntity должно будет создано несколько SuperserviceEntities (напримере План набора)
    this._queueWriter.Write(queueMessage.QueueName, queueMessage);
  }
}
