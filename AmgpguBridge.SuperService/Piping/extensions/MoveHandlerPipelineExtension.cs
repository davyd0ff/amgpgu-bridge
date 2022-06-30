using AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

namespace AmgpguBridge.SuperService.Piping;

public static class MoveHandlerPipelineExtension
{
  public static Pipeline Move(this Pipeline pipeline)
  {
    pipeline.AddHandler(
      new MoveHandler(
        pipeline.ServiceProvider.GetRequiredService<QueueMoveStrategyFactory>()
      )
    );

    return pipeline;
  }
}
