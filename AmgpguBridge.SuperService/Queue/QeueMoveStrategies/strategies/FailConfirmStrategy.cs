using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class FailConfirmStrategy : IQueueMoveStrategy
{
  private readonly IResponse _response;

  public FailConfirmStrategy(IResponse response)
  {
    this._response = response;
  }

  public void MoveQueueMessage(QueueMessage queueMessage, IQueueWriter queueWriter)
  {
    queueMessage.Status = QueueMessageStatus.Unconfirmed;
    queueMessage.Error = this._response.GetData();

    queueWriter.Write(QueueName.Database, queueMessage);
  }
}
