using AmgpguBridge.SuperService.Loading;

namespace AmgpguBridge.SuperService.Queue.QeueMoveStrategies;

public interface IQueueMoveStrategy
{
  void MoveQueueMessage(QueueMessage queueMessage, IQueueWriter queueWriter);
}
