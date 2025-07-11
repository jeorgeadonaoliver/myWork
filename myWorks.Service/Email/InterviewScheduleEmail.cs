using Microsoft.Extensions.Logging;
using myWorks.Application.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myWorks.Service.Email
{
    public class InterviewScheduleEmail : IInterviewScheduleEmail
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<VerificationEmail> _logger;

        public InterviewScheduleEmail(HttpClient httpClient, ILogger<VerificationEmail> logger, )
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<string> Send(string email, DateTime interviewDate, string notes)
        {
            await Task.Delay(1000);

            try
            {
                string url = $"https://mywork-emailsender:8081/api/Interview/SendInterviewSchedule?email={email}";

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();

                return data;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, $"Request to set interview email sender failed: {ex.Message}");
                return $"Request failed: {ex.Message}";
            }
            catch (Exception ex) // Catch other potential exceptions
            {
                _logger.LogError(ex, $"An unexpected error occurred while sending email interview schedule: {ex.Message}");
                return $"An unexpected error occurred: {ex.Message}";
            }
        }
    }
}
