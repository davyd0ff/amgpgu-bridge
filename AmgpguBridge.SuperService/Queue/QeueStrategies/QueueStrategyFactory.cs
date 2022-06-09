using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueStrategies;

public class QueueStrategyFactory
{
  public IQueueStrategy MakeStrategy(SuperServiceStage stage, ResponseType responseType)
  {
    return (stage, responseType) switch
    {
      (SuperServiceStage.LoadEntity, ResponseType.Success) => new SuccessLoadEntityStrategy(),
      (SuperServiceStage.LoadEntity, ResponseType.Error) => new FailLoadEntityStrategy(),
      (SuperServiceStage.LoadEntity, ResponseType.Fail) => new FailLoadEntityStrategy(),
      (SuperServiceStage.LoadEntity, ResponseType.Unreach) => new UnreachLoadEntityStrategy(),

      (SuperServiceStage.GetInfo, ResponseType.Success) => new SuccessGetInfoStrategy(),
      (SuperServiceStage.GetInfo, ResponseType.Unreach) => new UnreachGetInfoStrategy(),
      (SuperServiceStage.GetInfo, ResponseType.Error) => new FailGetInfoStrategy(),
      (SuperServiceStage.GetInfo, ResponseType.Fail) => new FailGetInfoStrategy(),

      (SuperServiceStage.Confirm, ResponseType.Success) => new SuccessConfirmStrategy(),
      (SuperServiceStage.Confirm, ResponseType.Unreach) => new UnreachConfirmStrategy(),
      (SuperServiceStage.Confirm, ResponseType.Error) => new FailConfirmStrategy(),
      (SuperServiceStage.Confirm, ResponseType.Fail) => new FailConfirmStrategy(),
    };
  }
}
