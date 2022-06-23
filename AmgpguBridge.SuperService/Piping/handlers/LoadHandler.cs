using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Piping;

public class LoadHandler : PipeHandler
{
  private ILoader _loader;
  private string _action;
  public LoadHandler(ILoader loader, string action)
  {
    this._loader = loader;
    this._action = action;
  }

  public override void Handle<TSEntity>(Context<TSEntity> context)
  {
    var response = this._loader.Load(this._action, context.JwtToken);
    context.SetResponse(response);

    base.Handle(context);
  }
}
