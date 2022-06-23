using AmgpguBridge.SuperService.Packing;

namespace AmgpguBridge.SuperService.Piping;

public class PackHandler : PipeHandler
{
  private PackerFactory _packerFactory;

  public PackHandler(PackerFactory packerFactory)
  {
    this._packerFactory = packerFactory;
  }
  public override void Handle<TSEntity>(Context<TSEntity> context)
  {
    var package = this._packerFactory.MakePacker(context.Action, context.SuperServiceEntity);

    base.Handle(context);
  }
}
