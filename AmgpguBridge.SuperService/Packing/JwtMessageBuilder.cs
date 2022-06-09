using AmgpguBridge.SuperService.Encoding;
using AmgpguBridge.SuperService.Signing;

namespace AmgpguBridge.SuperService.Packing;

public class JwtMessageBuilder
{
  private readonly JwtMessage _jwtMessage;
  private bool _signNeedly = true;

  public JwtMessageBuilder(ISigner signer, IEncoder encoder)
  {
    this._jwtMessage = new JwtMessage(signer, encoder);
  }

  public JwtMessageBuilder SetHeader(string header)
  {
    this._jwtMessage.SetHeader(header);
    this._signNeedly = true;
    return this;
  }

  public JwtMessageBuilder SetPayload(string payload)
  {
    this._jwtMessage.SetPayload(payload);
    this._signNeedly = true;
    return this;
  }

  public JwtMessageBuilder SetEncodedJwtMessage(string encodedJwtMessage)
  {
    this._jwtMessage.CreateByEncodedJwtMessage(encodedJwtMessage);
    this._signNeedly = false;
    return this;
  }

  public JwtMessage GetResult()
  {
    if (this._signNeedly)
    {
      this._jwtMessage.Sign();
    }

    return this._jwtMessage;
  }
}
