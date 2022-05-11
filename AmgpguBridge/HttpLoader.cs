using AmgpguBridge.SuperService.Contracts;


namespace AmgpguBridge;

public class HttpLoader : IHttpPostClient, IDisposable
{
  private readonly HttpClient client = new HttpClient();

  public async Task<string> Get(Uri url, byte[] headers)
  {
    var response = await this.client.GetAsync(url);
    response.EnsureSuccessStatusCode();
    var responseBody = await response.Content.ReadAsStringAsync();
    return responseBody;
  }

  public async Task<string> Post(Uri url, Dictionary<string, string> headers, byte[] data)
  {
    using (var request = new HttpRequestMessage(HttpMethod.Post, url))
    {
      foreach (var header in headers)
      {
        request.Headers.Add(header.Key, header.Value);
      }

      request.Content = new ByteArrayContent(data);

      var response = await this.client.SendAsync(request);
      // response.EnsureSuccessStatusCode();
      var responseBody = await response.Content.ReadAsStringAsync();

      return responseBody;
    }
  }

  public void Dispose()
  {
    this.client.Dispose();
  }
}
