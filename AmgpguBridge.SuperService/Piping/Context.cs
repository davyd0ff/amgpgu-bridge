using AmgpguBridge.SuperService.Loading;
using AmgpguBridge.SuperService.Packing;
using AmgpguBridge.SuperService.Queue;

namespace AmgpguBridge.SuperService.Piping;

public class Context<TSEntity> where TSEntity : Entities.SuperService.Entity
{
  public QueueMessage QueueMessage { get; set; }
  public readonly SuperServiceAction Action;
  public TSEntity SuperServiceEntity { get; private set; }
  public JwtToken JwtToken { get; private set; }
  public IResponse Response { get; private set; }


  public Context(QueueMessage queueMessage, SuperServiceAction action)
  {
    this.QueueMessage = queueMessage;
    this.Action = action;
  }

  public void SetEntity(TSEntity entity)
  {
    this.SuperServiceEntity = entity;
  }

  public void SetJwtToken(JwtToken jwtToken)
  {
    this.JwtToken = jwtToken;
  }

  public void SetResponse(IResponse response)
  {
    this.Response = response;
  }
}
