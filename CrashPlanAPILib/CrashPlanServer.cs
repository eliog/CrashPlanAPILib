using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CrashPlanAPILib.Models;

namespace CrashPlanAPILib
{
    /// <summary>
    /// CrashPlan Server 
    /// 
    /// </summary>
    public class CrashPlanServer
    {
        /// <summary>
        /// Base Url to connect to the server.  Defaults to (https://www.crashplanpro.com/api/) which is what works for Crashplan Pro
        /// </summary>
        public string BaseUrl { get; set; } = "https://www.crashplanpro.com/api/";

        private AuthToken _authToken;

        private HttpClient HttpClient
        {
            get
            {
                if (_authToken == null)
                {
                    throw new InvalidOperationException("Auth Token Not Set (not logged in?)");
                }
                var client = new HttpClient { BaseAddress = new Uri(BaseUrl) };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", $"{_authToken.Data[0]}-{_authToken.Data[1]}");
                return client;
            }
        }

        private async Task<T> GetObject<T>(string path)
        {
            using (var client = HttpClient)
            {
                var response = await client.GetAsync(path);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<T>();

            }
        }

        /// <summary>
        /// Login to the server
        /// </summary>
        /// <param name="username">Crashplan username</param>
        /// <param name="password">Crashplan password</param>
        /// <returns></returns>
        public async Task Login(string username, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await client.PostAsync("authToken",null);
                response.EnsureSuccessStatusCode();
                _authToken = await response.Content.ReadAsAsync<AuthToken>();
            }
        }

        /// <summary>
        /// Get computer info by the computer's Guid
        /// </summary>
        /// <param name="computerGuid">Computer's Guid</param>
        /// <param name="incBackupUsage">Include destinations and their backup stats</param>
        /// <param name="incActivity">Include backup history data for each destination</param>
        /// <param name="incHistory">Include live backup activity stats</param>
        /// <returns></returns>
        public async Task<GetComputerResponse> GetComputerInfoByGuid(string computerGuid,bool incBackupUsage = false, bool incActivity=false, bool incHistory = false)
        {
            return await GetObject<GetComputerResponse>($"Computer/{computerGuid}?idType=guid&incBackupUsage={incBackupUsage}&incActivity={incActivity}&incHistory={incHistory}");
        }
    }
}
