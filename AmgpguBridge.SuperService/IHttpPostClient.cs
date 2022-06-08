namespace AmgpguBridge.SuperService;

public interface IHttpPostClient
{
  Task<string> Post(Uri uri, string serializedData);
}
