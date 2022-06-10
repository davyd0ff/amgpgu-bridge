using AutoMapper;

namespace AmgpguBridge.SuperService.Mapping;

public class Mapper : IMapper
{
  private AutoMapper.Mapper _mapper;

  public Mapper()
  {
    var configuration = new MapperConfiguration(cfg =>
    {
      cfg.AddMaps("AmgpguBridge.SuperService.Mapping.Profiles");
    });

    this._mapper = new AutoMapper.Mapper(configuration);
  }

  public TSEntity Map<TUEntity, TSEntity>(TUEntity entity)
  {
    return this._mapper.Map<TUEntity, TSEntity>(entity);
  }
}
