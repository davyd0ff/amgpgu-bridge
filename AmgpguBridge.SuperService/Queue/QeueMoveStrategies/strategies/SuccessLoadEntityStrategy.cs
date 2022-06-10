using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class SuccessLoadEntityStrategy : IQueueMoveStrategy
{
  private readonly IResponse _response;

  public SuccessLoadEntityStrategy(IResponse response)
  {
    this._response = response;
  }

  public void MoveQueueMessage(QueueMessage queueMessage, IQueueWriter queueWriter)
  {
    queueMessage.Status = QueueMessageStatus.Processing;
    queueMessage.IdJwt = this._response.GetData();

    queueWriter.Write(QueueName.SuperServiceGetMessageInfo, queueMessage);
  }
}
