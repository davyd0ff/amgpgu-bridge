namespace AmgpguBridge.SuperService.Encoding;

public class Base64Encoder : IEncoder
{
  public string Decode(string payload)
  {
    var bytes = Convert.FromBase64String(payload);
    return System.Text.Encoding.UTF8.GetString(bytes);
  }

  public string Encode(string payload)
  {
    var bytes = System.Text.Encoding.UTF8.GetBytes(payload);
    return Convert.ToBase64String(bytes);
  }
}
