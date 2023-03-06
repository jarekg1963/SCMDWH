using Microsoft.AspNetCore.Components.Authorization;
using SCMDWH.Shared.Models;
using System.Net.Http.Json;
using System.Security.Claims;


namespace SCMDWH.Client.Tools
{
    public class RecordLog
    {
        private HttpClient _httpClient;

        public RecordLog(HttpClient httpClient)
        {
        _httpClient = httpClient;
        }

        public async void RecordLogForLogAppReportingActions(string logMessage, string userName)
        {
            LogAppUserActivity ilo = new LogAppUserActivity()
            {
                AppActivityType =  logMessage,
                AppActivityDetails = "Success",
                ActivityTime = DateTime.Now,
                ActivityTriggeredByUser = userName
            };
              await _httpClient.PostAsJsonAsync("/api/LogAppUserActivities", ilo);
        }

    }
}
