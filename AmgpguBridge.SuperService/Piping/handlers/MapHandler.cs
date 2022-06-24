using AmgpguBridge.SuperService.Mapping;
using AmgpguBridge.SuperService.Serializing;

namespace AmgpguBridge.SuperService.Piping;

internal class MapHandler<TUEntity, TSEntity> : PipeHandler
  where TUEntity : Entities.University.Entity
  where TSEntity : Entities.SuperService.Entity
{
  private IMapper _mapper;
  private ISerializer _serializer;

  public MapHandler(IMapper mapper, ISerializer serializer)
  {
    this._mapper = mapper;
    this._serializer = serializer;
  }

  public override void Handle<TSEntity>(Context<TSEntity> context)
  {
    TUEntity universityEntity = this._serializer.Deserialize<TUEntity>(context.QueueMessage.Body);
    context.SetEntity(this._mapper.Map<TUEntity, TSEntity>(universityEntity));

    base.Handle(context);
  }
}
