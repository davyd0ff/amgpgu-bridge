using AmgpguBridge.SuperService.Entities;

namespace AmgpguBridge.SuperService.Packing;

public class PackerFactory
{
  private readonly string _ogrn;
  private readonly string _kpp;

  public PackerFactory(string ogrn, string kpp)
  {
    this._kpp = kpp;
    this._ogrn = ogrn;
  }

  private EntityHeader MakeEntityHeader(SuperServiceAction action, Entity entity)
  {
    return new EntityHeader(action, entity.GetName(), this._ogrn, this._kpp);
  }

  private ServiceHeader MakeJwtMessageHeader(SuperServiceAction action, string idJwt)
  {
    return new ServiceHeader(action, idJwt, this._ogrn, this._kpp);
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
