using AmgpguBridge.SuperService.Packing;

namespace AmgpguBridge.SuperService.Piping;

public static class PackHandlerPipelineExtension
{
  public static Pipeline<TSEntity> Pack<TSEntity>(this Pipeline<TSEntity> pipeline)
    where TSEntity : Entities.SuperService.Entity
  {
    pipeline.AddHandler(
      new PackHandler(pipeline.ServiceProvider.GetRequiredService<PackerFactory>())
    );

    return pipeline;
  }
}
