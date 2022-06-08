using AmgpguBridge.SuperService.Encoding;
using AmgpguBridge.SuperService.Signing;

namespace AmgpguBridge.SuperService.Packing;

public class JwtMessage
{
  public readonly string Header;
  public readonly string Payload;

  private readonly string _encodedHeader;
  private readonly string _encodedPayload;
  private readonly string _encodedSignature;

  // DI ??
  private ISigner _signer;
  private IEncoder _encoder;

  // todo development: Делай Bilder 

  public JwtMessage(string header, string payload)
  {
    this.Header = header;
    this.Payload = payload;

    this._encodedHeader = Encode(this.Header);
    this._encodedPayload = Encode(this.Payload);
    this._encodedSignature = Sign(MakeSignature());
  }

  public JwtMessage(string jwtMessage)
  {
    var parts = jwtMessage.Split('.');

    this._encodedHeader = parts[0];
    this._encodedPayload = parts[1];
    this._encodedSignature = parts[2];

    this.Header = Decode(_encodedHeader);
    this.Payload = Decode(_encodedPayload);
  }

  public override string ToString()
  {
    return _encodedHeader + "." + _encodedPayload + "." + _encodedSignature;
  }

  private string MakeSignature()
  {
    return _encodedHeader + "." + _encodedPayload;
  }
  private string Decode(string data)
  {
    return _encoder.Decode(data);
  }
  private string Encode(string data)
  {
    return _encoder.Encode(data);
  }

  private string Sign(string data)
  {
    return _signer.Sign(data);
  }
}
