namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class ExceptionStrategy : IQueueMoveStrategy
{
  private IQueueWriter _queueWriter;
  private readonly Exception _exception;

  public ExceptionStrategy(IQueueWriter queueWriter, Exception exception)
  {
    this._queueWriter = queueWriter;
    this._exception = exception;
  }

  public void MoveQueueMessage(QueueMessage queueMessage)
  {
    queueMessage.Status = QueueMessageStatus.Error;
    queueMessage.Error = this._exception.ToString();

    this._queueWriter.Write(QueueName.Database, queueMessage);
  }
}
