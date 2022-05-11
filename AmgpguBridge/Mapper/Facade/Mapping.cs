using AutoMapper;

namespace AmgpguBridge.Mapper.Facade;
public static class Mapping
{
  public static AutoMapper.Mapper Mapper { get; private set; }
  public static void init()
  {
    var configuration = new MapperConfiguration(cfg =>
    {
      cfg.AddMaps("AmgpguBridge.Mapper.Profiles.FISGIA");
      cfg.AddMaps("AmgpguBridge.Mapper.Profiles.SuperService");
    });
    Mapper = new AutoMapper.Mapper(configuration);
  }
}