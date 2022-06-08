using AmgpguBridge.SuperService.Packing;

namespace AmgpguBridge.SuperService.Loading
{
  public interface ILoader
  {
    IResponse Load(string action, JwtToken jwtToken);
  }
}
