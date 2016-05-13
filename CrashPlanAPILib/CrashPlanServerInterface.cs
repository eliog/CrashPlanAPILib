using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CrashPlanAPILib.Models;
using Newtonsoft.Json.Linq;

namespace CrashPlanAPILib
{
    public class CrashPlanServerInterface
    {
        public string ServerUrl
        {
            get { return _serverUrl; }
            set
            {
                _serverUrl = value;
                if (_serverUrl != null && !_serverUrl.EndsWith("/")) _serverUrl += "/";
            }
        }

        private AuthTokenResponse _authToken;
        private string _serverUrl = "https://www.crashplanpro.com/api/";

        private HttpClient HttpClient
        {
            get
            {
                if (_authToken == null)
                {
                    throw new InvalidOperationException("Auth Token Not Set (not logged in?)");
                }
                var client = new HttpClient { BaseAddress = new Uri(ServerUrl) };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", $"{_authToken.Data[0]}-{_authToken.Data[1]}");
                return client;
            }
        }

        public async Task<T> GetObject<T>(string path)
        {
            using (var client = HttpClient)
            {
                var response = await client.GetAsync(path);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(JObject.Parse(json).ToString());
                return await response.Content.ReadAsAsync<T>();

            }
        }

        public async Task<TReturnType> PostObject<TReturnType, TPostType>(string path, TPostType obj)
        {
            using (var client = HttpClient)
            {
                var response = await client.PostAsJsonAsync(path, obj);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(JObject.Parse(json).ToString());
                return await response.Content.ReadAsAsync<TReturnType>();
            }
        }
        /// <summary>
        /// Login to the server with username and password
        /// </summary>
        /// <param name="username">Crashplan username</param>
        /// <param name="password">Crashplan password</param>
        /// <returns></returns>
        public async Task Login(string username, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await client.PostAsync("authToken", null);
                response.EnsureSuccessStatusCode();
                _authToken = await response.Content.ReadAsAsync<AuthTokenResponse>();
            }
        }

        public async Task LoginWithToken(string loginToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("login_token", loginToken);
                var response = await client.PostAsync("authToken", null);
                response.EnsureSuccessStatusCode();
                _authToken = await response.Content.ReadAsAsync<AuthTokenResponse>();
            }
        }
    }
}
