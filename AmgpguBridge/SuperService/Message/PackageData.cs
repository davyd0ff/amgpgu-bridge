using AmgpguBridge.SuperService.Contracts;
using AmgpguBridge.SuperService.Entities;

namespace AmgpguBridge.SuperService.Message;

public class PackageData<TSEntity> : ISerializable where TSEntity : SuperService.Entities.Entity {
  [JsonPropertyNameBasedOnClass] public TSEntity Entity { get; set; }

  public PackageData(TSEntity entity) {
    this.Entity = entity;
  }

  public string Serialize(ISerializer serializer) {
    if (this.Entity is EmptyEntity) return "";
    return serializer.Serialize(new { PackageData = this });
  }
}