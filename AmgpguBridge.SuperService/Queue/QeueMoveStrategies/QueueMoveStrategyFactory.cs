using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class QueueMoveStrategyFactory
{
  public IQueueMoveStrategy MakeStrategy(SuperServiceStage stage, IResponse response)
  {
    return (stage, response.GetResponseType()) switch
    {
      (SuperServiceStage.LoadEntity, ResponseType.Success) => new SuccessLoadEntityStrategy(response),
      (SuperServiceStage.LoadEntity, ResponseType.Error) => new FailLoadEntityStrategy(response),
      (SuperServiceStage.LoadEntity, ResponseType.Fail) => new FailLoadEntityStrategy(response),
      (SuperServiceStage.LoadEntity, ResponseType.Unreach) => new UnreachLoadEntityStrategy(response),

      (SuperServiceStage.GetInfo, ResponseType.Success) => new SuccessGetInfoStrategy(),
      (SuperServiceStage.GetInfo, ResponseType.Unreach) => new UnreachGetInfoStrategy(response),
      (SuperServiceStage.GetInfo, ResponseType.Error) => new FailGetInfoStrategy(response),
      (SuperServiceStage.GetInfo, ResponseType.Fail) => new FailGetInfoStrategy(response),

      (SuperServiceStage.Confirm, ResponseType.Success) => new SuccessConfirmStrategy(),
      (SuperServiceStage.Confirm, ResponseType.Unreach) => new UnreachConfirmStrategy(response),
      (SuperServiceStage.Confirm, ResponseType.Error) => new FailConfirmStrategy(response),
      (SuperServiceStage.Confirm, ResponseType.Fail) => new FailConfirmStrategy(response),
    };
  }
}
