using System.Net.Http.Headers;
using System.Text.Json;

namespace CelleGames.Web.Utils;

public static class HttpClientExtensions
{
    private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");
    public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
            throw new ApplicationException($"Não foi possivel obter respostas da API: {response.ReasonPhrase}");

        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return JsonSerializer.Deserialize<T>(dataAsString,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient client, string url, T data)
    {
        var dataAsString = JsonSerializer.Serialize(data);
        var content = new StringContent(dataAsString);
        content.Headers.ContentType = contentType;

        return client.PostAsync(url, content);
    }

    public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient client, string url, T data)
    {
        var dataAsString = JsonSerializer.Serialize(data);
        var content = new StringContent(dataAsString);
        content.Headers.ContentType = contentType;

        return client.PutAsync(url, content);
    }
}
