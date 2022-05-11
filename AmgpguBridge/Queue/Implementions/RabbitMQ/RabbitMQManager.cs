using AmgpguBridge.Queue.Contracts;
using AmgpguBridge.Queue.General;

namespace AmgpguBridge.Queue.Implementions;
public class QueueManager : IQueueManager
{
  private IDictionary<QueueName, IEnumerable<Action<IQueueMessage>>> _listeners;

  public QueueManager()
  {
    foreach (QueueName queueName in Enum.GetValues(typeof(QueueName)))
    {
      this._listeners.Add(queueName, new List<Action<IQueueMessage>>());
    }
  }

  public void AddQueueListener(QueueName queueName, Action<IQueueMessage> callback)
  {
    //throw new NotImplementedException();
    this._listeners[queueName].Append(callback);
  }
}