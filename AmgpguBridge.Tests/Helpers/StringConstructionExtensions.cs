using System;
using System.Linq;
using System.Xml.Linq;

namespace AmgpguBridge.Tests.Helpers {
  public static class StringConstructionExtensions {
    private static bool xmlDiff(XElement first, XElement second) {
      if (first == null || second == null) return false;
      if (first.Name != second.Name) return false;
      // if (first.HasElements ^ second.HasElements) return false;
      if (first.Elements().Count() != second.Elements().Count()) return false;
      if (!first.HasElements && first.Value != second.Value) return false;

      foreach (var childOfFirst in first.Elements()) {
        var childOfSecond = second.Elements()
          .Where(child => child.Name.Equals(childOfFirst.Name))
          .FirstOrDefault();
        return xmlDiff(childOfFirst, childOfSecond);
      }

      return true;
    }

    public static bool XmlEquals(this string firstXml, string secondXml) {
      var rootOfFirstXml = XElement.Parse(firstXml);
      var rootOfSecondXml = XElement.Parse(secondXml);

      return xmlDiff(rootOfFirstXml, rootOfSecondXml);
    }

    public static bool JsonEquals(this string firstJson, string secondJson) {
      throw new NotImplementedException();
    }
  }
}