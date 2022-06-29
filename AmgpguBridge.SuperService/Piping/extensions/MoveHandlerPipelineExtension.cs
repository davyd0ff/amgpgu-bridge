using AmgpguBridge.SuperService.Queue;
using AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

namespace AmgpguBridge.SuperService.Piping;

public static class MoveHandlerPipelineExtension
{
  public static Pipeline Move<TSEntity>(this Pipeline pipeline)
    where TSEntity : Entities.SuperService.Entity
  {
    pipeline.AddHandler(
      new MoveHandler(
        pipeline.ServiceProvider.GetRequiredService<QueueMoveStrategyFactory>(),
        pipeline.ServiceProvider.GetRequiredService<IQueueWriter>()
      )
    );

    return pipeline;
  }
}
