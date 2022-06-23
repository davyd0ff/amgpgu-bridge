namespace AmgpguBridge.SuperService.Piping;

public class ErrorHandler : PipeHandler
{
  public override void Handle<TSEntity>(Context<TSEntity> context)
  {
    try
    {
      base.Handle(context);
    } catch (Exception exception)
    {

    }

  }
}
