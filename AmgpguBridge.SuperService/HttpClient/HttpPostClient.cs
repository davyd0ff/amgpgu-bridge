using System.Net.Http.Headers;

namespace AmgpguBridge.SuperService.HttpClient;

public class HttpPostClient : IHttpPostClient, IDisposable
{
  private readonly HttpClient _httpClient;

  public HttpPostClient()
  {
    _httpClient = new HttpClient();
    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
  }

  public async Task<string> Post(Uri uri, string serializedData)
  {
    using (var request = new HttpRequestMessage(HttpMethod.Post, uri))
    {
      request.Content = new StringContent(serializedData, System.Text.Encoding.UTF8, "application/json");
      var response = await _httpClient.SendAsync(request);
      var responseBody = await response.Content.ReadAsStringAsync();

      return responseBody;
    }
  }

  public void Dispose()
  {
    _httpClient.Dispose();
  }
}
