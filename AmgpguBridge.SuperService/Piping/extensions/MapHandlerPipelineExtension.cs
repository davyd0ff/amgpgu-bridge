﻿using AmgpguBridge.SuperService.Mapping;
using AmgpguBridge.SuperService.Serializing;

namespace AmgpguBridge.SuperService.Piping;

public static class MapHandlerPipelineExtension
{
  public static Pipeline Map<TUEntity, TSEntity>(this Pipeline pipeline)
    where TUEntity : Entities.University.Entity
    where TSEntity : Entities.SuperService.Entity
  {
    pipeline.AddHandler(
      new MapHandler<TUEntity, TSEntity>(
        pipeline.ServiceProvider.GetRequiredService<IMapper>(),
        pipeline.ServiceProvider.GetRequiredService<JsonSerializer>()
      )
    );

    return pipeline;
  }
}
