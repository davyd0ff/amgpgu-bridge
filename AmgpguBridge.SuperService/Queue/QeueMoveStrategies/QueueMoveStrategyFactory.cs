using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public class QueueMoveStrategyFactory
{
  private IQueueWriter _queueWriter;

  public QueueMoveStrategyFactory(IQueueWriter queueWriter)
  {
    this._queueWriter = queueWriter;
  }

  public IQueueMoveStrategy MakeStrategy(SuperServiceStage stage, IResponse response)
  {
    return (stage, response.GetResponseType()) switch
    {
      (SuperServiceStage.LoadEntity, ResponseType.Success) => new SuccessLoadEntityStrategy(response, this._queueWriter),
      (SuperServiceStage.LoadEntity, ResponseType.Error) => new FailLoadEntityStrategy(response, this._queueWriter),
      (SuperServiceStage.LoadEntity, ResponseType.Fail) => new FailLoadEntityStrategy(response, this._queueWriter),
      (SuperServiceStage.LoadEntity, ResponseType.Unreach) => new UnreachLoadEntityStrategy(response, this._queueWriter),

      (SuperServiceStage.GetInfo, ResponseType.Success) => new SuccessGetInfoStrategy(this._queueWriter),
      (SuperServiceStage.GetInfo, ResponseType.Unreach) => new UnreachGetInfoStrategy(response, this._queueWriter),
      (SuperServiceStage.GetInfo, ResponseType.Error) => new FailGetInfoStrategy(response, this._queueWriter),
      (SuperServiceStage.GetInfo, ResponseType.Fail) => new FailGetInfoStrategy(response, this._queueWriter),

      (SuperServiceStage.Confirm, ResponseType.Success) => new SuccessConfirmStrategy(this._queueWriter),
      (SuperServiceStage.Confirm, ResponseType.Unreach) => new UnreachConfirmStrategy(response, this._queueWriter),
      (SuperServiceStage.Confirm, ResponseType.Error) => new FailConfirmStrategy(response, this._queueWriter),
      (SuperServiceStage.Confirm, ResponseType.Fail) => new FailConfirmStrategy(response, this._queueWriter),
    };
  }
}
