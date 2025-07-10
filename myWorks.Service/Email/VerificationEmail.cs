using Microsoft.Extensions.Logging;
using myWorks.Application.Interface.Service;
using System.Net.Http;

namespace myWorks.Service.Email
{
    public class VerificationEmail : IVerificationEmail
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<VerificationEmail> _logger;
        public VerificationEmail(HttpClient httpClient, ILogger<VerificationEmail> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<string> Send(string email)
        {
            await Task.Delay(1000);

            try
            {
                var response = await _httpClient.GetAsync($"http://host.docker.internal:5227/api/Registration/SendVerificationEmail?email={email}");
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Email status: {data}");
                _logger.LogInformation($"Email status: {data}");
                return data;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
                return $"Request failed: {ex.Message}";
            }

        }
    }
}
