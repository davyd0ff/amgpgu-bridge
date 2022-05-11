using AmgpguBridge.SuperService.Message;

namespace AmgpguBridge.SuperService.Packing;

public class Packer<TSEntity> where TSEntity : SuperService.Entities.Entity
{
  private MessageHeader _header;
  private TSEntity _entity;

  public Packer(MessageHeader header, TSEntity entity)
  {
    this._header = header;
    this._entity = entity;
  }

  private string MakeHeader()
  {
    return this._header.Serialize(new JsonSerializer());
  }

  private string MakeBody()
  {
    return (new PackageData<TSEntity>(this._entity)).Serialize(new XmlSerializer());
  }

  protected JwtMessage MakeJwtMessage()
  {
    return new JwtMessage(this.MakeHeader(), this.MakeBody());
  }

  public JwtMessage Pack()
  {
    return this.MakeJwtMessage();
  }
}
