using System;

namespace AmgpguBridge.Tests.Helpers {
  public static class DateConstructionExtensions {
    public static DateTime September(this int day, int year) => new DateTime(year, 9, day);
  }
}