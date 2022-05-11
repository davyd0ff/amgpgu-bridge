using AmgpguBridge.SuperService.Entities;
using AmgpguBridge.SuperService.Message;

namespace AmgpguBridge.SuperService.Packing;

public class PackerFactory
{
  private string _ogrn;
  private string _kpp;

  public PackerFactory(string ogrn, string kpp)
  {
    this._kpp = kpp;
    this._ogrn = ogrn;
  }

  private EntityHeader MakeEntityHeader(SuperServiceAction action, Entity entity)
  {
    return new EntityHeader(
      action,
      entity.GetName(),
      this._ogrn,
      this._kpp);
  }

  private JwtMessageHeader MakeJwtMessageHeader(SuperServiceAction action, string idJwt)
  {
    return new JwtMessageHeader(
      action,
      idJwt,
      this._ogrn,
      this._kpp);
  }

  public Packer<TSEntity> MakePacker<TSEntity>(SuperServiceAction action, TSEntity superserviceEntity)
    where TSEntity : SuperService.Entities.Entity
  {
    var header = this.MakeEntityHeader(action, superserviceEntity);
    return new Packer<TSEntity>(header, superserviceEntity);
  }

  public Packer<EmptyEntity> MakePacker(SuperServiceAction action, string idJwt)
  {
    var header = this.MakeJwtMessageHeader(action, idJwt);
    return new Packer<EmptyEntity>(header, new EmptyEntity());
  }
}
