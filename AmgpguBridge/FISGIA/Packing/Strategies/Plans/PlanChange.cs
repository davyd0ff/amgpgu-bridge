using System;
using AmgpguBridge.Queue.Contracts;

namespace AmgpguBridge.FISGIA.Packing.Strategies {
  public class PlanChange : IStrategy {
    public void Pack(IQueueWriter queueWriter, string payload) {
      throw new NotImplementedException();
    }
  }
}