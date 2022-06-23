using AmgpguBridge.SuperService.Entities.SuperService;
using AmgpguBridge.SuperService.Piping;
using AmgpguBridge.SuperService.Queue;

namespace AmgpguBridge.SuperService.Controllers;

public class LoadEntityController
{
  private readonly IServiceProvider ServiceProvider;
  public LoadEntityController(IServiceProvider serviceProvider)
  {
    ServiceProvider = serviceProvider;
  }

  public async Task NewEntity<TUEntity, TSEntity>(QueueMessage queueMessage)
    where TUEntity : Entities.University.Entity
    where TSEntity : Entity
  {
    new Pipeline<TSEntity>(new Context<TSEntity>(queueMessage, SuperServiceAction.Add), ServiceProvider)
      .Error()
      .Map()
      .ItIsNotInDatabase()
      .Pack()
      .Load("api/token/new")
      .Move();
  }

  public async Task ChangeEntity<TUEntity, TSEntity>(QueueMessage queueMessage)
    where TUEntity : Entities.University.Entity
    where TSEntity : Entity
  {
    new Pipeline<TSEntity>(new Context<TSEntity>(queueMessage, SuperServiceAction.Edit), ServiceProvider)
      .Error()
      .Map<TUEntity, TSEntity>()
      .ItIsInDatabase()
      .Pack()
      .Load("api/token/new")
      .Move();
  }

  public async Task DeleteEntity<TUEntity, TSEntity>(QueueMessage queueMessage)
    where TUEntity : Entities.University.Entity
    where TSEntity : Entity
  {
    new Pipeline<TSEntity>(new Context<TSEntity>(queueMessage, SuperServiceAction.Delete), ServiceProvider)
      .Error()
      .Map()
      .ItIsInDatabase()
      .Pack()
      .Load("api/token/new")
      .Move();
  }

  public async Task Confirm(QueueMessage queueMessage)
  {
    .ItIsInDatabase()
    .Pack()
    .Load("api/token/service/confirm")
    .Move()
    .Catch();
  }

  public async Task GetInfo(QueueMessage queueMessage)
  {
    .ItIsInDatabase()
    .Pack()
    .Load("api/token/service/info")
    .Move()
    .Catch();
  }
}
