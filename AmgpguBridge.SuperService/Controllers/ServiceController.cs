using AmgpguBridge.SuperService.Entities.SuperService;
using AmgpguBridge.SuperService.Piping;
using AmgpguBridge.SuperService.Queue;

namespace AmgpguBridge.SuperService.Controllers;

public class ServiceController
{
  private readonly IServiceProvider ServiceProvider;
  public ServiceController(IServiceProvider serviceProvider)
  {
    ServiceProvider = serviceProvider;
  }

  public async Task GetInfo(QueueMessage queueMessage)
  {
    new Pipeline<EmptyEntity>(new Context<EmptyEntity>(queueMessage, SuperServiceAction.GetMessage), ServiceProvider)
      .Error()
      .ItIsInDatabase()
      .Pack()
      .Load("api/token/service/info")
      .Move();
  }

  public async Task Confirm(QueueMessage queueMessage)
  {
    new Pipeline<EmptyEntity>(new Context<EmptyEntity>(queueMessage, SuperServiceAction.Confirm), ServiceProvider)
      .Error()
      .ItIsInDatabase()
      .Pack()
      .Load("api/token/service/confirm")
      .Move();
  }
}
