using AmgpguBridge.Queue.General;

namespace AmgpguBridge.Queue.Contracts;
public interface IQueueMessageCreator
{
  IQueueMessageCreator SetBody(string body);
  IQueueMessageCreator SetStatus(QueueMessageStatus status);
  IQueueMessageCreator SetParentMessage(IQueueMessage queueMessage);
  IQueueMessageCreator SetError(string error);
  IQueueMessageCreator SetQueueName(QueueName queueName);

  IQueueMessage GetQueueMessage();
  //IQueueMessage make(string body, QueueMessageStatus status, IQueueMessage parentMessage);
}
