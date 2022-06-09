namespace AmgpguBridge.SuperService.HttpClient;

public interface IHttpPostClient
{
  Task<string> Post(Uri uri, string serializedData);
}
