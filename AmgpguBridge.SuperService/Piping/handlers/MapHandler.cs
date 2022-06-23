using AmgpguBridge.SuperService.Mapping;
using AmgpguBridge.SuperService.Serializing;

namespace AmgpguBridge.SuperService.Piping;

internal class MapHandler<TUEntity, TSEntity> : PipeHandler 
  where TUEntity : Entities.University.Entity
  where TSEntity : Entities.SuperService.Entity
{
  private IMapper _mapper;

  public MapHandler(IMapper mapper)
  {
    this._mapper = mapper;
  }

  public override void Handle<TSEntity>(Context<TSEntity> context)
  {
    // todo think: how pass ISerializer 
    TUEntity universityEntity = new JsonSerializer().Deserialize<TUEntity>(context.QueueMessage.Body);
    context.SetEntity(this._mapper.Map<TUEntity, TSEntity>(universityEntity));

    base.Handle(context);
  }
}
