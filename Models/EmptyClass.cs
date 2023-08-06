using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Net.Http.Headers;
using chessAI.Models;

public class BasicModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BasicModel(IHttpClientFactory httpClientFactory) =>
        _httpClientFactory = httpClientFactory;

    public async Task<IEnumerable<GitHubBranch>> GetGitHubBranchesAsync()
    {
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            "https://api.github.com/repos/dotnet/AspNetCore.Docs/branches")
        {
            Headers =
            {
                { HeaderNames.Accept, "application/vnd.github.v3+json" },
                { HeaderNames.UserAgent, "HttpRequestsSample" }
            }
        };

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<GitHubBranch>>(contentStream);
        }

        // Handle error scenario (return empty list or throw an exception)
        return Enumerable.Empty<GitHubBranch>();
    }
}


