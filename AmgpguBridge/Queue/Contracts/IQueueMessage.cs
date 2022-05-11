using AmgpguBridge.Queue.General;

namespace AmgpguBridge.Queue.Contracts;
public interface IQueueMessage
{
  string Body { get; }
  string UidMessage { get; }
  string UidEntity { get; }
  DateTime Date { get; }
  QueueName QueueName { get; }
  IQueueMessage ParentMessage { get; }
  QueueMessageStatus Status { get; set; }
  string Error { get; set; }
}