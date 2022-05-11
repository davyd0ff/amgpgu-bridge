using AmgpguBridge.Queue.Contracts;
using AmgpguBridge.Queue.General;

namespace AmgpguBridge.Repository.Implementions;
public class MessageDbRepository : IQueueMessageRepository
{
  public IQueueMessage GetMessage(string uidMessage)
  {
    throw new System.NotImplementedException();
  }

  public QueueMessageStatus GetMessageStatus(string uidMessage)
  {
    throw new System.NotImplementedException();
  }

  public QueueMessageStatus GetMessageStatus(IQueueMessage queueMessage)
  {
    throw new System.NotImplementedException();
  }
}