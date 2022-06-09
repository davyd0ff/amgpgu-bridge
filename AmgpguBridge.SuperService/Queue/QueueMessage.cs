namespace AmgpguBridge.SuperService.Queue;

public class QueueMessage
{
  public string Body { get; }
  public string UidMessage { get; }
  public string UidEntity { get; }
  public DateTime Date { get; }
  public QueueName QueueName { get; }
  public QueueMessage ParentMessage { get; set; }
  public QueueMessageStatus Status { get; set; }
  public string Error { get; set; }
}
