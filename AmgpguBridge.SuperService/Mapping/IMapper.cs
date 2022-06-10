namespace AmgpguBridge.SuperService.Mapping;

public interface IMapper
{
  TSEntity Map<TUEntity, TSEntity>(TUEntity entity);
}
