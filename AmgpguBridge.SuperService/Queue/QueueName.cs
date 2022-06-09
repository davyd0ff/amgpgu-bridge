namespace AmgpguBridge.SuperService.Queue;

public enum QueueName
{
  Database,

  UniversityApplicationNew,
  UniversityApplicationChange,
  UniversityApplicationReject,

  UniversityPlanNew,
  UniversityPlanChange,

  UniversityOrderEnroll,
  UniversityOrderUnenroll,

  SuperServiceApplicationNew,
  SuperServiceApplicationChange,
  SuperServiceApplicationReject,
  SuperServiceGetMessageInfo,
  SuperServiceMessageConfirm,
}
