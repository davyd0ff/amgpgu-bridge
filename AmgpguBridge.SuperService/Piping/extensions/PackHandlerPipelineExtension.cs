using AmgpguBridge.SuperService.Packing;

namespace AmgpguBridge.SuperService.Piping;

public static class PackHandlerPipelineExtension
{
  public static Pipeline Pack(this Pipeline pipeline)
  {
    pipeline.AddHandler(
      new PackHandler(pipeline.ServiceProvider.GetRequiredService<PackerFactory>())
    );

    return pipeline;
  }
}
