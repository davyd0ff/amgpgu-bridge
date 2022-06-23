namespace AmgpguBridge.SuperService.Piping;

public class Pipeline<TSEntity> where TSEntity : Entities.SuperService.Entity
{
  private PipeHandler _handler = null;

  public readonly IServiceProvider ServiceProvider;
  public readonly Context<TSEntity> Context;



  public Pipeline(Context<TSEntity> context, IServiceProvider serviceProvider)
  {
    this.Context = context;
    this.ServiceProvider = serviceProvider;
  }


  public void AddHandler(PipeHandler handler)
  {
    this._handler.SetNextHandler(handler);
  }

  public void Handle()
  {
    this._handler.Handle(this.Context);
  }
}