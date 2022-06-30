using AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

namespace AmgpguBridge.SuperService.Piping;

public class ErrorHandler : PipeHandler
{
  private IQueueMoveStrategy _queueMoveStrategy;
  public ErrorHandler(IQueueMoveStrategy queueMoveStrategy)
  {
    this._queueMoveStrategy = queueMoveStrategy;
  }

  public override void Handle<TSEntity>(Context<TSEntity> context)
  {
    try
    {
      base.Handle(context);
    } catch (Exception exception)
    {
      context.QueueMessage.Error = exception.ToString();
      context.QueueMessage.Status = SuperService.Queue.QueueMessageStatus.Error;
      this._queueMoveStrategy.MoveQueueMessage(context.QueueMessage);
    }
  }
}
