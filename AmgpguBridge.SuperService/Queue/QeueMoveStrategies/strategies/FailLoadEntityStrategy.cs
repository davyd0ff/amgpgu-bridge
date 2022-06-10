using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class FailLoadEntityStrategy : IQueueMoveStrategy
{
  private readonly IResponse _response;

  public FailLoadEntityStrategy(IResponse response)
  {
    this._response = response;
  }

  public void MoveQueueMessage(QueueMessage queueMessage, IQueueWriter queueWriter)
  {
    queueMessage.Status = QueueMessageStatus.Error;
    queueMessage.Error = this._response.GetData();

    queueWriter.Write(QueueName.Database, queueMessage);
  }
}
