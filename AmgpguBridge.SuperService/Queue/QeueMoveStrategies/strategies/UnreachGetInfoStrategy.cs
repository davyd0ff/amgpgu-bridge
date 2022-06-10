using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class UnreachGetInfoStrategy : IQueueMoveStrategy
{
  private readonly IResponse _response;

  public UnreachGetInfoStrategy(IResponse response)
  {
    this._response = response;
  }

  public void MoveQueueMessage(QueueMessage queueMessage, IQueueWriter queueWriter)
  {
    queueMessage.Status = QueueMessageStatus.Processing;
    queueMessage.Error = this._response.GetData();

    queueWriter.Write(QueueName.SuperServiceGetMessageInfo, queueMessage);
  }
}
