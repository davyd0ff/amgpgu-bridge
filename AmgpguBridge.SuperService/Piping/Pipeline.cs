namespace AmgpguBridge.SuperService.Piping;

public class Pipeline
{
  private PipeHandler _handler = null;

  public readonly IServiceProvider ServiceProvider;
  //public readonly Context<TSEntity> Context;



  public Pipeline(IServiceProvider serviceProvider)
  {
    //this.Context = context;
    this.ServiceProvider = serviceProvider;
  }


  public void AddHandler(PipeHandler handler)
  {
    this._handler.SetNextHandler(handler);
  }

  public void Handle<TSEntity>(Context<TSEntity> context)
    where TSEntity : Entities.SuperService.Entity
  {
    this._handler.Handle(context);
  }
}