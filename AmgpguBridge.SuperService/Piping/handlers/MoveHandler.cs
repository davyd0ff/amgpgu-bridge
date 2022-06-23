using AmgpguBridge.SuperService.Queue;
using AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

namespace AmgpguBridge.SuperService.Piping;

public class MoveHandler : PipeHandler
{
  private QueueMoveStrategyFactory _strategyFactory;
  private IQueueWriter _queueWriter;

  public MoveHandler(QueueMoveStrategyFactory strategyFactory, IQueueWriter queueWriter)
  {
    this._strategyFactory = strategyFactory;
    this._queueWriter = queueWriter;
  }

  public override void Handle<TSEntity>(Context<TSEntity> context)
  {
    var stage = this.DetermineStage(context.Action);
    var strategy = this._strategyFactory.MakeStrategy(stage, context.Response);
    
    strategy.MoveQueueMessage(context.QueueMessage, this._queueWriter);

    base.Handle(context);
  }

  private SuperServiceStage DetermineStage(SuperServiceAction action)
  {
    return (action) switch
    {
      (SuperServiceAction.Add) => SuperServiceStage.LoadEntity,
      (SuperServiceAction.Edit) => SuperServiceStage.LoadEntity,
      (SuperServiceAction.Delete) => SuperServiceStage.LoadEntity,
      (SuperServiceAction.GetMessage) => SuperServiceStage.GetInfo,
      (SuperServiceAction.Confirm) => SuperServiceStage.Confirm
    };
  }
}
