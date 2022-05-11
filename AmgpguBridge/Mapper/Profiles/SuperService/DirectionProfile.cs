using AmgpguBridge.SuperService.Entities;
using AmgpguBridge.University.Entities;
using AutoMapper;

namespace AmgpguBridge.Mapper.Profiles.FISGIA;
public class DirectionProfile : Profile
{
  public DirectionProfile()
  {
    CreateMap<Direction, OrgDirection>();
  }
}
