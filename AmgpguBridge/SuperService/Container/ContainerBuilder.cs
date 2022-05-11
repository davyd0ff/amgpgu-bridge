using AmgpguBridge.SuperService.Message;

namespace AmgpguBridge.SuperService;
public class ContainerBuilder
{
  private SuperService.Container _container;

  public ContainerBuilder()
  {
    this._container = new Container();
  }

  public ContainerBuilder SetEntity(string entity)
  {
    this._container = new Container(this._container, entity);
    return this;
  }

  public ContainerBuilder SetJwtMessage(JwtMessage jwtMessage)
  {
    this._container = new Container(this._container, null, null, jwtMessage);
    return this;
  }

  public ContainerBuilder SetIdJwt(string idJwt)
  {
    this._container = new Container(this._container, null, idJwt);
    return this;
  }

  public SuperService.Container GetContainer()
  {
    return this._container;
  }
}
