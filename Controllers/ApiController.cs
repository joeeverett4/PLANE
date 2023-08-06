using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace chessAI.Controllers
{
    public class ApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MakeApiCall()
        {
            // Your access token from the Duffel API
            string accessToken = "duffel_test_ymnhCGBYCd8K0h23yJnuzRM3cZ45QZ3zVAMp1IgUqMk"; // Replace with your actual access token

            // Log a message to the console to indicate that the method is running
            Console.WriteLine("MakeApiCall method is running.");


            // API endpoint URL
            string apiUrl = "https://api.duffel.com/air/orders";

            // API request payload
            string requestBody = @"
            {
                ""data"": {
                    ""type"": ""instant"",
                    ""services"": [
                        {
                            ""quantity"": 1,
                            ""id"": ""ase_00009hj8USM7Ncg31cB123""
                        }
                    ],
                    ""selected_offers"": [
                        ""off_00009htyDGjIfajdNBZRlw""
                    ],
                    ""payments"": [
                        {
                            ""type"": ""balance"",
                            ""currency"": ""GBP"",
                            ""amount"": ""30.20""
                        }
                    ],
                    ""passengers"": [
                        {
                            ""title"": ""mrs"",
                            ""phone_number"": ""+442080160509"",
                            ""infant_passenger_id"": ""pas_00009hj8USM8Ncg32aTGHL"",
                            ""identity_documents"": [
                                {
                                    ""unique_identifier"": ""19KL56147"",
                                    ""type"": ""passport"",
                                    ""issuing_country_code"": ""GB"",
                                    ""expires_on"": ""2025-04-25""
                                }
                            ],
                            ""id"": ""pas_00009hj8USM7Ncg31cBCLL"",
                            ""given_name"": ""Amelia"",
                            ""gender"": ""f"",
                            ""family_name"": ""Earhart"",
                            ""email"": ""amelia@duffel.com"",
                            ""born_on"": ""1987-07-24""
                        }
                    ],
                    ""metadata"": {
                        ""payment_intent_id"": ""pit_00009htYpSCXrwaB9DnUm2""
                    }
                }
            }";

            // Create the HttpContent from the request body
            HttpContent httpContent = new StringContent(requestBody, Encoding.UTF8, "application/json");

            // Set request headers
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            httpClient.DefaultRequestHeaders.Add("Duffel-Version", "v1");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            // Send the POST request and get the response
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, httpContent);

            // Check if the response was successful
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                return View("Success", apiResponse);
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                return View("Error", errorMessage);
            }
        }

        [HttpPost]
public async Task<IActionResult> TriggerApiCall()
{
    // Call the MakeApiCall method to make the API call
    var result = await MakeApiCall();

    // Return the result (success or error message) to the frontend
    return Ok(result);
}
    }
}

