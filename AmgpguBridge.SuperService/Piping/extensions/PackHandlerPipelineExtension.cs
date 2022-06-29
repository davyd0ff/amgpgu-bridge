using AmgpguBridge.SuperService.Packing;

namespace AmgpguBridge.SuperService.Piping;

public static class PackHandlerPipelineExtension
{
  public static Pipeline Pack<TSEntity>(this Pipeline pipeline)
    where TSEntity : Entities.SuperService.Entity
  {
    pipeline.AddHandler(
      new PackHandler(pipeline.ServiceProvider.GetRequiredService<PackerFactory>())
    );

    return pipeline;
  }
}
