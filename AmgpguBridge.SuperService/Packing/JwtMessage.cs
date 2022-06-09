using AmgpguBridge.SuperService.Encoding;
using AmgpguBridge.SuperService.Signing;

namespace AmgpguBridge.SuperService.Packing;

public class JwtMessage
{
  public string Header { get; private set; }
  public string Payload { get; private set; }

  private string _encodedHeader;
  private string _encodedPayload;
  private string _encodedSignature;

  private ISigner _signer;
  private IEncoder _encoder;

  public JwtMessage(ISigner signer, IEncoder encoder)
  {
    this._signer = signer;
    this._encoder = encoder;
  }

  public void SetHeader(string header)
  {
    this.Header = header;
    this._encodedHeader = this.Encode(header);
  }
  public void SetPayload(string payload)
  {
    this.Payload = payload;
    this._encodedPayload = this.Encode(payload);
  }
    public void CreateByEncodedJwtMessage(string encodedJwtMessage)
  {
    var parts = encodedJwtMessage.Split('.');

    this._encodedHeader = parts[0];
    this._encodedPayload = parts[1];

    this.Header = this.Decode(parts[0]);
    this.Payload = this.Decode(parts[1]);
  }

  public void Sign()
  {
    this._encodedSignature = this._signer.Sign(this.MakeSignature());
  }


  public override string ToString()
  {
    return _encodedHeader + "." + _encodedPayload + "." + _encodedSignature;
  }


  private string MakeSignature()
  {
    return this._encodedHeader + "." + this._encodedPayload;
  }
  private string Decode(string data)
  {
    return _encoder.Decode(data);
  }
  private string Encode(string data)
  {
    return _encoder.Encode(data);
  }
}
