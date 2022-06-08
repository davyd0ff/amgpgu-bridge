using System.Xml;
using Newtonsoft.Json;

namespace AmgpguBridge.SuperService.Serializing;

public class XmlSerializer : ISerializer
{
  public string Serialize<T>(T data)
  {
    var json = JsonConvert.SerializeObject(data, new JsonSerializerSettings
    {
      ContractResolver = new JsonCustomResolver()
    });
    var xmlDocument = (XmlDocument)JsonConvert.DeserializeXmlNode(json);

    return xmlDocument == null ? "" : xmlDocument.OuterXml;
  }

  public T Deserialize<T>(string xml)
  {
    var xmlDocument = new XmlDocument();
    xmlDocument.LoadXml(xml);

    var json = JsonConvert.SerializeXmlNode(xmlDocument);
    return JsonConvert.DeserializeObject<T>(json);
  }
}
