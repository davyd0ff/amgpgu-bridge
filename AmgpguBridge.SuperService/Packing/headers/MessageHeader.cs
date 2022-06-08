using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using AmgpguBridge.SuperService.Serializing;

namespace AmgpguBridge.SuperService.Packing;

public abstract class MessageHeader : ISerializable
{
  [JsonConverter(typeof(StringEnumConverter))]
  public readonly SuperServiceAction Action;
  public readonly string Ogrn;
  public readonly string Kpp;

  protected MessageHeader(SuperServiceAction action, string ogrn, string kpp)
  {
    Action = action;
    Ogrn = ogrn;
    Kpp = kpp;
  }

  public string Serialize(ISerializer serializer)
  {
    return serializer.Serialize(this);
  }
}
