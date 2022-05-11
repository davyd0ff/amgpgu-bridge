using System.Security.Cryptography;
using System.Text;

namespace AmgpguBridge.SuperService.Signing;
public class Signer
{
  private HMACSHA256 _hash;
  public Signer(string secretKey)
  {
    this._hash = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
  }
  public string Sign(string data)
  {
    var signature = this._hash.ComputeHash(Encoding.UTF8.GetBytes(data));
    return Convert.ToBase64String(signature);
  }
}