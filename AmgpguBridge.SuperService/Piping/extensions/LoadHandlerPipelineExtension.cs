using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Piping;

public static class LoadHandlerPipelineExtension
{
  public static Pipeline Load<TSEntity>(this Pipeline pipeline, string action)
    where TSEntity : Entities.SuperService.Entity
  {

    pipeline.AddHandler(
      new LoadHandler(pipeline.ServiceProvider.GetRequiredService<ILoader>(), action)
    );

    return pipeline;
  }
}
