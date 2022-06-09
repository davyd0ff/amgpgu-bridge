using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueStrategies;

public interface IQueueStrategy
{
  void MoveQueueMessage(
    QueueMessage queueMessage,
    IQueueWriter queueWriter,
    IResponse response
  );
}
