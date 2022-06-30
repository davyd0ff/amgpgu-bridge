using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class SuccessConfirmStrategy : IQueueMoveStrategy
{
  private IQueueWriter _queueWriter;

  public SuccessConfirmStrategy(IQueueWriter queueWriter)
  {
    this._queueWriter = queueWriter;
  }

  public void MoveQueueMessage(QueueMessage queueMessage)
  {
    queueMessage.Status = QueueMessageStatus.Done;

    this._queueWriter.Write(QueueName.Database, queueMessage);
  }
}
