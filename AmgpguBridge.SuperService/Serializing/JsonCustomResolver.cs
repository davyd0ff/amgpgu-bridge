using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AmgpguBridge.SuperService.Serializing;

public class JsonCustomResolver : DefaultContractResolver
{
  protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
  {
    var prop = base.CreateProperty(member, memberSerialization);
    if (this.PropSignedAsJsonPropertyNameBasedOnItemClassAttribute(member))
    {
      var typeName = prop.PropertyType.Name;
      prop.PropertyName = typeName;
    }

    return prop;
  }

  private bool PropSignedAsJsonPropertyNameBasedOnItemClassAttribute(MemberInfo member)
  {
    return member.GetCustomAttributes<JsonPropertyNameBasedOnClassAttribute>().Count() > 0;
  }
}
