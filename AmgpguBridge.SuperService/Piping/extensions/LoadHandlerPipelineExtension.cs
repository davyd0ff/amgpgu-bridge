using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Piping;

public static class LoadHandlerPipelineExtension
{
  public static Pipeline Load(this Pipeline pipeline, string action)
  {

    pipeline.AddHandler(
      new LoadHandler(pipeline.ServiceProvider.GetRequiredService<ILoader>(), action)
    );

    return pipeline;
  }
}
