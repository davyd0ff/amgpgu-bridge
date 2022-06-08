namespace AmgpguBridge.SuperService.Encoding;

public interface IEncoder
{
  string Encode(string payload);
  string Decode(string payload);
}
