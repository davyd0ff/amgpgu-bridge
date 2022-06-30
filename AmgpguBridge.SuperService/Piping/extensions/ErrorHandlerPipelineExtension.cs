using AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

namespace AmgpguBridge.SuperService.Piping;

public static class ErrorHandlerPipelineExtension
{
  public static Pipeline Error(this Pipeline pipeline)
  {
    var queueMoveStrategyFactory = pipeline.ServiceProvider.GetRequiredService<QueueMoveStrategyFactory>();

    pipeline.AddHandler(
      new ErrorHandler(queueMoveStrategyFactory)
    );

    return pipeline;
  }
}
