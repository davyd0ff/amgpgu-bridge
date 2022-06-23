namespace AmgpguBridge.SuperService.Piping;

public abstract class PipeHandler
{
  private PipeHandler _next = null;

  public void SetNextHandler(PipeHandler next)
  {
    if (this._next == null)
    {
      this._next = next;
    }
    else
    {
      this._next.SetNextHandler(next);
    }
  }

  public virtual void Handle<TSEntity>(Context<TSEntity> context) 
    where TSEntity : Entities.SuperService.Entity
  {
    if (this._next != null)
    {
      this._next.Handle(context);
    }
  }
}
