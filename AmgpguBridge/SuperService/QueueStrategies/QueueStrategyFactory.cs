using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.QueueStrategies;
public class QueueStrategyFactory
{
  public IQueueStrategy MakeStrategy(SuperServiceStage stage, ResponseType responseType)
  {
    return (stage, responseType) switch
    {
      (SuperServiceStage.LoadEntity, ResponseType.Success) => new SuccessEntityLoadStrategy(),
      (SuperServiceStage.LoadEntity, ResponseType.Error) => new FailEntityLoadStrategy(),
      (SuperServiceStage.LoadEntity, ResponseType.Fail) => new FailEntityLoadStrategy(),
      (SuperServiceStage.LoadEntity, ResponseType.Unreach) => new UnreachEntityLoadStrategy(),

      (SuperServiceStage.GetInfo, ResponseType.Success) => new SuccessGetInfoLoadStrategy(),
      (SuperServiceStage.GetInfo, ResponseType.Unreach) => new UnreachGetInfoLoadStrategy(),
      (SuperServiceStage.GetInfo, ResponseType.Error) => new FailGetInfoLoadStrategy(),
      (SuperServiceStage.GetInfo, ResponseType.Fail) => new FailGetInfoLoadStrategy(),

      (SuperServiceStage.Confirm, ResponseType.Success) => new SuccessConfirmLoadStrategy(),
      (SuperServiceStage.Confirm, ResponseType.Unreach) => new UnreachConfirmLoadStrategy(),
      (SuperServiceStage.Confirm, ResponseType.Error) => new FailConfirmLoadStrategy(),
      (SuperServiceStage.Confirm, ResponseType.Fail) => new FailConfirmLoadStrategy(),
    };
  }
}