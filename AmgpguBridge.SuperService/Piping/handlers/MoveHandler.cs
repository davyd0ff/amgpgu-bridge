using AmgpguBridge.SuperService.Queue;
using AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

namespace AmgpguBridge.SuperService.Piping;

public class MoveHandler : PipeHandler
{
  private QueueMoveStrategyFactory _strategyFactory;
  public MoveHandler(QueueMoveStrategyFactory strategyFactory)
  {
    this._strategyFactory = strategyFactory;
  }

  public override void Handle<TSEntity>(Context<TSEntity> context)
  {
    var stage = this.DetermineStage(context.Action);
    var strategy = this._strategyFactory.MakeStrategy(stage, context.Response);

    strategy.MoveQueueMessage(context.QueueMessage);

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
