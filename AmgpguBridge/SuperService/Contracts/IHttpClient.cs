namespace AmgpguBridge.SuperService.Contracts;

public interface IHttpPostClient
{
  Task<string> Post(Uri uri, Dictionary<string, string> headers, byte[] data);
}
