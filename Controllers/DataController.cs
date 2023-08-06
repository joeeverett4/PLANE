using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json; // Import the namespace for System.Text.Json

[Route("api/[controller]")]
[ApiController]
public class DataController : ControllerBase
{
    private readonly HttpClient httpClient;

    public DataController(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient();
    }

    [HttpGet]
    public async Task<IActionResult> GetData()
    {
        // External API URL
        string apiUrl = "https://jsonplaceholder.typicode.com/todos/1";

        // Make the HTTP call to the external API
        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string contentString = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to your desired data structure
            var responseData = JsonSerializer.Deserialize<object>(contentString);

            return Ok(responseData);
        }

        // If the request was not successful, handle the error (optional)
        // For example, you can return a specific error message or HTTP status code.
        return BadRequest("Failed to fetch data from the external API.");
    }
}



