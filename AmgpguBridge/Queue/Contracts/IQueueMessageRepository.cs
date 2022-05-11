using AmgpguBridge.Queue.General;

namespace AmgpguBridge.Queue.Contracts;
public interface IQueueMessageRepository
{
  IQueueMessage GetMessage(string uidMessage);
  QueueMessageStatus GetMessageStatus(string uidMessage);
  QueueMessageStatus GetMessageStatus(IQueueMessage message);
}
