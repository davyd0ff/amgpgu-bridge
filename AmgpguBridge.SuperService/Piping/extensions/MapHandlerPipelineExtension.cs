using AmgpguBridge.SuperService.Mapping;

namespace AmgpguBridge.SuperService.Piping;

public static class MapHandlerPipelineExtension
{
  public static Pipeline<TSEntity> Map<TUEntity, TSEntity>(this Pipeline<TSEntity> pipeline)
    where TUEntity : Entities.University.Entity
    where TSEntity : Entities.SuperService.Entity
  {
    pipeline.AddHandler(
      new MapHandler<TUEntity, TSEntity>(pipeline.ServiceProvider.GetRequiredService<IMapper>())
    );

    return pipeline;
  }
}
