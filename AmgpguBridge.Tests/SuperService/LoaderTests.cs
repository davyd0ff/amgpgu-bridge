using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AmgpguBridge.SuperService.Contracts;
using AmgpguBridge.SuperService.Loading;
using AmgpguBridge.SuperService.Message;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AmgpguBridge.Tests.SuperService;

[TestFixture]
public class LoaderTests {
  [Test]
  public async Task Load_GetSuccessResponse() {
    var postClient = Create.HttpPostClient()
      .WithResponse("{\"IdJwt\":\"testIdJwt\"}")
      .Please();
    var jwtMessage = Create.JwtMessage().Please();

    var loader = new Loader(new Uri("https://some-address.com"), postClient);
    var response = await loader.Load("some/action", jwtMessage);

    Assert.That(response.GetResponseType(), Is.EqualTo(ResponseType.Success));
    Assert.That(response.GetData(), Is.EqualTo("testIdJwt"));
  }

  [Test]
  public async Task Load_GetErrorResponse() {
    var postClient = Create.HttpPostClient()
      .WithResponse("{\"Error\":\"Error test message\"}")
      .Please();
    var jwtMessage = Create.JwtMessage().Please();

    var loader = new Loader(new Uri("https://some-address.com"), postClient);
    var response = await loader.Load("some/action", jwtMessage);

    Assert.That(response.GetResponseType(), Is.EqualTo(ResponseType.Error));
    Assert.That(response.GetData(), Is.EqualTo("Error test message"));
  }

  [Test]
  public async Task Load_GetErrorResponseViaInfoResponse() {
    var postClient = Create.HttpPostClient()
      .WithResponse(
        Create.JwtMessage()
          .WithHeader("{\"PayloadType\":\"Error\"}")
          .WithPayload("<PackageData>Test</PackageData>"))
      .Please();
    var anyJwtMessage = Create.JwtMessage().Please();

    var loader = new Loader(new Uri("https://some-address.com"), postClient);
    var response = await loader.Load("some/action", anyJwtMessage);

    Assert.That(response.GetResponseType(), Is.EqualTo(ResponseType.Error));
    Assert.That(response.GetData(), Is.EqualTo("<PackageData>Test</PackageData>"));
  }

  [Test]
  public async Task Load_GetSuccessResponseViaInfoResponse() {
    var postClient = Create.HttpPostClient()
      .WithResponse(
        Create.JwtMessage()
          .WithHeader("{\"PayloadType\":\"Success\"}"))
      .Please();
    var anyJwtMessage = Create.JwtMessage().Please();

    var loader = new Loader(new Uri("https://some-address.com"), postClient);
    var response = await loader.Load("some/action", anyJwtMessage);

    Assert.That(response.GetResponseType(), Is.EqualTo(ResponseType.Success));
  }

  [Test]
  public async Task Load_GetFailResponse() {
    var postClient = Create.HttpPostClient()
      .WithException(Create.HttpRequestException().Code(HttpStatusCode.Forbidden))
      .Please();
    var jwtMessage = Create.JwtMessage().Please();

    var loader = new Loader(new Uri("https://some-address.com"), postClient);
    var response = await loader.Load("some/action", jwtMessage);

    Assert.That(response.GetResponseType(), Is.EqualTo(ResponseType.Fail));
  }

  [Test]
  public async Task Load_GetUnreachResponse() {
    var postClient = Create.HttpPostClient()
      .WithException(Create.HttpRequestException().Code(HttpStatusCode.GatewayTimeout))
      .Please();
    var jwtMessage = Create.JwtMessage().Please();

    var loader = new Loader(new Uri("https://some-address.com"), postClient);
    var response = await loader.Load("some/action", jwtMessage);

    Assert.That(response.GetResponseType(), Is.EqualTo(ResponseType.Unreach));
  }
}

internal static partial class Create {
  public static HttpPostClientBuilder HttpPostClient() {
    return new HttpPostClientBuilder();
  }

  public static JwtMessageBuilder JwtMessage() {
    return new JwtMessageBuilder();
  }

  public static HttpRequestExceptionBuilder HttpRequestException() {
    return new HttpRequestExceptionBuilder();
  }
}

internal partial class HttpPostClientBuilder {
  private readonly Mock<IHttpPostClient> _mock;

  public HttpPostClientBuilder() {
    this._mock = new Mock<IHttpPostClient>();
  }

  public HttpPostClientBuilder WithResponse(JwtMessage jwtMessage) {
    this._mock
      .Setup(
        client => client.Post(
          It.IsAny<Uri>(),
          It.IsAny<Dictionary<string, string>>(),
          It.IsAny<byte[]>()
        )
      )
      .ReturnsAsync(JsonConvert.SerializeObject(new { ResponseToken = jwtMessage.ToString() }));

    return this;
  }

  public HttpPostClientBuilder WithResponse(string response) {
    this._mock.Setup(
        client => client.Post(
          It.IsAny<Uri>(),
          It.IsAny<Dictionary<string, string>>(),
          It.IsAny<byte[]>()))
      .ReturnsAsync(response);
    return this;
  }

  public HttpPostClientBuilder WithException(HttpRequestException exception) {
    this._mock
      .Setup(
        client => client.Post(
          It.IsAny<Uri>(),
          It.IsAny<Dictionary<string, string>>(),
          It.IsAny<byte[]>())
      )
      .Throws(exception);

    return this;
  }

  public IHttpPostClient Please() {
    return this._mock.Object;
  }
}

internal partial class JwtMessageBuilder {
  private string _header;
  private string _payload;

  public JwtMessageBuilder() {
    this._header = "Test";
    this._payload = "Test";
  }

  public JwtMessageBuilder WithHeader(string header) {
    this._header = header;
    return this;
  }

  public JwtMessageBuilder WithPayload(string payload) {
    this._payload = payload;
    return this;
  }

  public JwtMessage Please() {
    return new JwtMessage(this._header, this._payload);
  }

  public static implicit operator JwtMessage(JwtMessageBuilder builder) {
    return builder.Please();
  }
}

internal partial class HttpRequestExceptionBuilder {
  private HttpStatusCode? _code;
  private string _message;

  public HttpRequestExceptionBuilder() {
    this._code = null;
    this._message = "";
  }

  public HttpRequestExceptionBuilder Code(HttpStatusCode code) {
    this._code = code;
    return this;
  }

  public HttpRequestException Message(string message) {
    this._message = message;
    return this;
  }

  public static implicit operator HttpRequestException(HttpRequestExceptionBuilder builder) {
    return new HttpRequestException(builder._message, null, builder._code);
  }
}