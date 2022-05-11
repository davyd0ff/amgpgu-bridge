using System;
using System.Collections.Generic;
using NUnit.Framework;
using AmgpguBridge.SuperService;
using AmgpguBridge.SuperService.Message;
using AmgpguBridge.SuperService.Entities;
using AmgpguBridge.Tests.Helpers;

namespace AmgpguBridge.Tests.SuperService;


[TestFixture]
public class PackageDataTests
{
  [Test]
  public void Serialize_WithEmptyEntity()
  {
    var packageData = new PackageData<EmptyEntity>(Create.EmptyEntity().Please());

    var xml = packageData.Serialize(new XmlSerializer());

    Assert.That(xml, Is.EqualTo(""));
  }

  [Test]
  public void Serialize_WithNotEmptyEntity()
  {
    var packageData = new PackageData<Campaign>(Create.Campaign()
      .WithName("Test")
      .WithUid("TestUid")
      .WithIdAcademicYear(1)
      .WithIdCampaignStatus(1)
      .WithIdEducationForm(1)
      .WithIdOrderAdmissionProcedure(1)
      .WithNumberAgree(1)
      .WithCountDirections(1)
      .WithTotalMaxScoreAchievements(1)
      .WithEndDate(1.September(2022))
      .Please());

    var xml = packageData.Serialize(new XmlSerializer());

    Assert.IsTrue(xml.XmlEquals($@"<PackageData>
          <Campaign>
            <Name>Test</Name>
            <Uid>TestUid</Uid>
            <IdAcademicYear>1</IdAcademicYear>
            <IdCampaignStatus>1</IdCampaignStatus>
            <IdEducationForm>1</IdEducationForm>
            <IdOrderAdmissionProcedure>1</IdOrderAdmissionProcedure>
            <NumberAgree>1</NumberAgree>
            <CountDirections>1</CountDirections>
            <TotalMaxScoreAchievements>1</TotalMaxScoreAchievements>
            <EndDate>{1.September(2022)}</EndDate>
          </Campaign>
        </PackageData>"));
  }
}


internal static partial class Create
{
  public static CampaignBuilder Campaign()
  {
    return new CampaignBuilder();
  }

  public static EmptyEntityBuilder EmptyEntity()
  {
    return new EmptyEntityBuilder();
  }
}

internal class EmptyEntityBuilder
{
  public EmptyEntity Please()
  {
    return new EmptyEntity();
  }
}

internal class CampaignBuilder
{
  private Campaign _campaign;

  public CampaignBuilder()
  {
    _campaign = new Campaign();
    _campaign.EducationLevels = new List<EducationLevel>();
  }

  public CampaignBuilder WithName(string name)
  {
    this._campaign.Name = name;
    return this;
  }

  public CampaignBuilder WithUid(string value)
  {
    this._campaign.Uid = value;
    return this;
  }

  public CampaignBuilder WithIdAcademicYear(int value)
  {
    this._campaign.IdAcademicYear = value;
    return this;
  }

  public CampaignBuilder WithIdCampaignStatus(int value)
  {
    this._campaign.IdCampaignStatus = value;
    return this;
  }

  public CampaignBuilder WithIdEducationForm(int value)
  {
    this._campaign.IdEducationForm = value;
    return this;
  }

  public CampaignBuilder WithIdOrderAdmissionProcedure(int value)
  {
    this._campaign.IdOrderAdmissionProcedure = value;
    return this;
  }

  public CampaignBuilder WithNumberAgree(int value)
  {
    this._campaign.NumberAgree = value;
    return this;
  }

  public CampaignBuilder WithCountDirections(int value)
  {
    this._campaign.CountDirections = value;
    return this;
  }

  public CampaignBuilder WithTotalMaxScoreAchievements(int value)
  {
    this._campaign.TotalMaxScoreAchievements = value;
    return this;
  }

  public CampaignBuilder WithEndDate(DateTime value)
  {
    this._campaign.EndDate = value;
    return this;
  }

  public Campaign Please()
  {
    return this._campaign;
  }
}