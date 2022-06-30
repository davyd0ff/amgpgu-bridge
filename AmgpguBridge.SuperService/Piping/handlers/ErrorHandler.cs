using AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

namespace AmgpguBridge.SuperService.Piping;

public class ErrorHandler : PipeHandler
{
  private QueueMoveStrategyFactory _queueMoveStrategyFactory;
  public ErrorHandler(QueueMoveStrategyFactory queueMoveStrategyFactory)
  {
    this._queueMoveStrategyFactory = queueMoveStrategyFactory;
  }

  public override void Handle<TSEntity>(Context<TSEntity> context)
  {
    try
    {
      base.Handle(context);
    }
    catch (Exception exception)
    {
      var queueMoveStrategy = this._queueMoveStrategyFactory.MakeExceptionStrategy(exception);
      queueMoveStrategy.MoveQueueMessage(context.QueueMessage);
    }
  }
}
