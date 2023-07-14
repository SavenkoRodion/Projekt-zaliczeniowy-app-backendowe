using System.Net.Http.Headers;

namespace Wsei.Matches.Infrastructure.Services;
public static class HttpClientUtil
{
    public static HttpClient GetHttpClient()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7206");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        return client;
    }
}
