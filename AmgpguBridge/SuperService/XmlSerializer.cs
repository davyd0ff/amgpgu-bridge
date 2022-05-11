using System.Xml;
using AmgpguBridge.SuperService.Contracts;
using Newtonsoft.Json;

namespace AmgpguBridge.SuperService;
public class XmlSerializer : ISerializer
{
  public string Serialize<T>(T data)
  {
    var json = JsonConvert.SerializeObject(data, new JsonSerializerSettings
    {
      ContractResolver = new CustomResolver()
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
