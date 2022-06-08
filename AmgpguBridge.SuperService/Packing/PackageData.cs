using AmgpguBridge.SuperService.Entities;
using AmgpguBridge.SuperService.Serializing;

namespace AmgpguBridge.SuperService.Packing;

public class PackageData<TSEntity> : ISerializable where TSEntity : Entity
{
  [JsonPropertyNameBasedOnClass] public TSEntity Entity { get; set; }

  public PackageData(TSEntity entity)
  {
    this.Entity = entity;
  }

  public string Serialize(ISerializer serializer)
  {
    if (this.Entity is EmptyEntity) return "";
    return serializer.Serialize(new { PackageData = this });
  }
}