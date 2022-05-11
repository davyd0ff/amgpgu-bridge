using System.Text;

namespace AmgpguBridge.SuperService.Message;

public class JwtMessage {
  // todo development: add Sign message
  public readonly string Header;
  public readonly string Payload;
  private readonly string _encodedHeader;
  private readonly string _encodedPayload;

  public JwtMessage(string header, string payload) {
    this.Header = header;
    this.Payload = payload;
    this._encodedHeader = this.EncodeDataToBase64(this.Header);
    this._encodedPayload = this.EncodeDataToBase64(this.Payload);
  }

  public JwtMessage(string jwt) {
    var parts = jwt.Split('.');
    this._encodedHeader = parts[0];
    this._encodedPayload = parts[1];
    this.Header = this.DecodeDataFromBase64(this._encodedHeader);
    this.Payload = this.DecodeDataFromBase64(this._encodedPayload);
  }

  private string EncodeDataToBase64(string data) {
    return Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
  }

  private string DecodeDataFromBase64(string data) {
    return Encoding.UTF8.GetString(Convert.FromBase64String(data));
  }

  public byte[] ToByte() {
    return Encoding.UTF8.GetBytes(this.ToString());
  }

  public override string ToString() {
    var builder = new StringBuilder();
    builder.Append(this._encodedHeader + ".");
    builder.Append(this._encodedPayload + ".");
    // builder.Append(this.Signature);

    return builder.ToString();
  }
}