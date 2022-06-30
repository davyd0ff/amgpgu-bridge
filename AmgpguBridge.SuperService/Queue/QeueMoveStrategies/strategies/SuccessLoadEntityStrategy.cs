using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class SuccessLoadEntityStrategy : IQueueMoveStrategy
{
  private readonly IResponse _response;
  private IQueueWriter _queueWriter;

  public SuccessLoadEntityStrategy(IResponse response, IQueueWriter queueWriter)
  {
    this._response = response;
    this._queueWriter = queueWriter;
  }

  public void MoveQueueMessage(QueueMessage queueMessage)
  {
    queueMessage.Status = QueueMessageStatus.Processing;
    queueMessage.IdJwt = this._response.GetData();

    this._queueWriter.Write(QueueName.SuperServiceGetMessageInfo, queueMessage);
  }
}
