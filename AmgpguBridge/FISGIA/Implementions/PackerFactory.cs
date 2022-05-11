using AmgpguBridge.FISGIA.Packing.Strategies;
using AmgpguBridge.FISGIA.Packing;

namespace AmgpguBridge.FISGIA.Implementions;
public class PackerFactory
{
  public Packer ApplicationNew()
  {
    return new Packer(new ApplicationNew());
  }

  public Packer ApplicationChange()
  {
    return new Packer(new ApplicationChange());
  }

  public Packer ApplicationReject()
  {
    return new Packer(new ApplicationReject());
  }

  public Packer OrderEnroll()
  {
    throw new NotImplementedException();
    // return new Packer(new OrderEnroll());
  }
}