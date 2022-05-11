using System;
using System.Text;
using AmgpguBridge.Queue.Contracts;

namespace AmgpguBridge.FISGIA.Packing {
  public class Package {
    private string _endpoint;
    private string _payload;

    public Package(string endpoint, string payload) {
      this._endpoint = endpoint;
      this._payload = payload;
    }

    private string Serialize() {
      throw new NotImplementedException();
    }

    public byte[] GetBytes() {
      return Encoding.UTF8.GetBytes(this.Serialize());
    }

    public string GetJson() {
      throw new NotImplementedException();
    }
  }
}