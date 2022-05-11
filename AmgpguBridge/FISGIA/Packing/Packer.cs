using AmgpguBridge.Queue.Contracts;
using AmgpguBridge.FISGIA.Packing.Strategies;

namespace AmgpguBridge.FISGIA.Packing {
  public class Packer {
    private IStrategy _strategy;

    public Packer(IStrategy strategy) {
      this._strategy = strategy;
    }

    public void Pack(IQueueWriter queueWriter, string payload) {
      this._strategy.Pack(queueWriter, payload);
    }
  }
}