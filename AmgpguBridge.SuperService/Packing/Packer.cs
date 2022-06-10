using AmgpguBridge.SuperService.Entities.SuperService;
using AmgpguBridge.SuperService.Serializing;

namespace AmgpguBridge.SuperService.Packing;

public class Packer<TSEntity> where TSEntity : Entity
{
  private readonly MessageHeader _header;
  private readonly TSEntity _entity;
  private readonly JwtMessageBuilder _jwtMessageBuilder;

  public Packer(MessageHeader header, TSEntity entity, JwtMessageBuilder jwtMessageBuilder)
  {
    this._header = header;
    this._entity = entity;
    this._jwtMessageBuilder = jwtMessageBuilder;
  }

  private string MakeHeader()
  {
    return this._header.Serialize(new JsonSerializer());
  }

  private string MakePayload()
  {
    return (new PackageData<TSEntity>(this._entity)).Serialize(new XmlSerializer());
  }

  private JwtMessage MakeJwtMessage()
  {
    return this._jwtMessageBuilder
      .SetHeader(this.MakeHeader())
      .SetPayload(this.MakePayload())
      .GetResult();
  }

  public JwtToken Pack()
  {
    return new JwtToken(this.MakeJwtMessage());
  }
}
