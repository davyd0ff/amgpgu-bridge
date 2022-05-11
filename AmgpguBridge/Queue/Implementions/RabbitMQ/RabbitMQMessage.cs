using AmgpguBridge.Queue.Contracts;
using AmgpguBridge.Queue.General;

namespace AmgpguBridge.Queue.Implementions;
public class RabbitMQMessage : IQueueMessage
{
  public string Body { get; }
  public string UidMessage { get; }
  public string UidEntity { get; }
  public DateTime Date { get; }
  public QueueName QueueName { get; }
  public IQueueMessage ParentMessage { get; private set; }
  public QueueMessageStatus Status { get; set; }
  public string Error { get; set; }

  public void SetParent(IQueueMessage parentMessage)
  {
    this.ParentMessage = ParentMessage;
  }
}