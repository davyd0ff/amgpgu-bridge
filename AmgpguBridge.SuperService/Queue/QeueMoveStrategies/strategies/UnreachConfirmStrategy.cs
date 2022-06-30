using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class UnreachConfirmStrategy : IQueueMoveStrategy
{
  private readonly IResponse _response;
  private IQueueWriter _queueWriter;

  public UnreachConfirmStrategy(IResponse response, IQueueWriter queueWriter)
  {
    this._response = response;
    this._queueWriter = queueWriter;
  }

  public void MoveQueueMessage(QueueMessage queueMessage)
  {
    queueMessage.Status = QueueMessageStatus.Processing;
    queueMessage.Error = this._response.GetData();

    this._queueWriter.Write(QueueName.SuperServiceMessageConfirm, queueMessage);
  }
}
