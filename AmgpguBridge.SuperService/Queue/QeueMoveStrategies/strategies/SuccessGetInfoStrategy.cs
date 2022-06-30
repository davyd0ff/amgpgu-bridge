using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class SuccessGetInfoStrategy : IQueueMoveStrategy
{
  private IQueueWriter _queueWriter;

  public SuccessGetInfoStrategy(IQueueWriter queueWriter)
  {
    this._queueWriter = queueWriter;
  }

  public void MoveQueueMessage(QueueMessage queueMessage)
  {
    queueMessage.Status = QueueMessageStatus.Processing;

    this._queueWriter.Write(QueueName.SuperServiceMessageConfirm, queueMessage);
  }
}
