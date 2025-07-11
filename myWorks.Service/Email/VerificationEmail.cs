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
                string url = $"https://mywork-emailsender:8081/api/Registration/SendVerificationEmail?email={email}";

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();

                _logger.LogInformation($"Email status: {data}");
                return data;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, $"Request to email sender failed: {ex.Message}");
                return $"Request failed: {ex.Message}";
            }
            catch (Exception ex) // Catch other potential exceptions
            {
                _logger.LogError(ex, $"An unexpected error occurred while sending email verification: {ex.Message}");
                return $"An unexpected error occurred: {ex.Message}";
            }

        }
    }
}
