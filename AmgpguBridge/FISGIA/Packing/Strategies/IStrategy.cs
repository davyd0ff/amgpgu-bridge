using AmgpguBridge.Queue.Contracts;

namespace AmgpguBridge.FISGIA.Packing.Strategies {
  public interface IStrategy {
    void Pack(IQueueWriter queueWriter, string payload);
  }
}