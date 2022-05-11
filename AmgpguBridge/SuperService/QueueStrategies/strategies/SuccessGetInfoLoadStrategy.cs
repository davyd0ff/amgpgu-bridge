using AmgpguBridge.Queue.Contracts;
using AmgpguBridge.Queue.General;
using AmgpguBridge.SuperService.Contracts;
using AmgpguBridge.SuperService.Loading;
using AmgpguBridge.SuperService.Message;

namespace AmgpguBridge.SuperService.QueueStrategies;
public class SuccessGetInfoLoadStrategy : IQueueStrategy
{
  public void MoveQueueMessage(
    string entity,
    JwtMessage jwtMessage,
    IResponse response,
    ISerializer serializer,
    IQueueMessageCreator queueMessageCreator,
    IQueueWriter queueWriter,
    IQueueMessage queueMessage
  )
  {
    queueMessage.Status = QueueMessageStatus.Processing;

    queueWriter.Write(QueueName.SuperServiceMessageConfirm, queueMessage);
  }
}