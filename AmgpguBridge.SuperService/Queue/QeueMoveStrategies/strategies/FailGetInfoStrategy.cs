using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class FailGetInfoStrategy : IQueueMoveStrategy
{
  private readonly IResponse _response;

  public FailGetInfoStrategy(IResponse response)
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
