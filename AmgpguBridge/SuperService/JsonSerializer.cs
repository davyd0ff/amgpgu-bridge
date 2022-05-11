using AmgpguBridge.SuperService.Contracts;
using Newtonsoft.Json;

namespace AmgpguBridge.SuperService;
public class JsonSerializer : ISerializer
{
  public string Serialize<T>(T data)
  {
    return JsonConvert.SerializeObject(data);
  }

  public T Deserialize<T>(string json)
  {
    return JsonConvert.DeserializeObject<T>(json);
  }
}
