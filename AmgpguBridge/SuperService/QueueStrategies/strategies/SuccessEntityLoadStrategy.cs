using AmgpguBridge.Queue.Contracts;
using AmgpguBridge.Queue.General;
using AmgpguBridge.SuperService.Contracts;
using AmgpguBridge.SuperService.Loading;
using AmgpguBridge.SuperService.Message;

namespace AmgpguBridge.SuperService.QueueStrategies;
public class SuccessEntityLoadStrategy : IQueueStrategy
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
    var container = new ContainerBuilder()
      .SetEntity(entity)
      .SetJwtMessage(jwtMessage)
      .SetIdJwt(response.GetData())
      .GetContainer();

    var bodyQueueMessage = container.Serialize(serializer);

    var newQueueMessage = queueMessageCreator
      .SetBody(bodyQueueMessage)
      .SetStatus(QueueMessageStatus.Processing)
      .SetParentMessage(queueMessage)
      .GetQueueMessage();

    queueWriter.Write(QueueName.SuperServiceGetMessageInfo, newQueueMessage);
  }
}