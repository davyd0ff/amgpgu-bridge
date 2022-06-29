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
    var pipeline = new Pipeline(ServiceProvider)
      .Error()
      .ItIsInDatabase()
      .Pack()
      .Load("api/token/service/info")
      .Move();

    pipeline.Handle(new Context<EmptyEntity>(queueMessage, SuperServiceAction.GetMessage));
  }

  public async Task Confirm(QueueMessage queueMessage)
  {
    var pipeline = new Pipeline(ServiceProvider)
      .Error()
      .ItIsInDatabase()
      .Pack()
      .Load("api/token/service/confirm")
      .Move();

    pipeline.Handle(new Context<EmptyEntity>(queueMessage, SuperServiceAction.Confirm));
  }
}
