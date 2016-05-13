using Newtonsoft.Json;

namespace CrashPlanAPILib.Models
{
    public class LoginTokenRequest
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("sourceGuid")]
        public string SourceGuid { get; set; }

        [JsonProperty("destinationGuid")]
        public string DestinationGuid { get; set; }
    }

    public class LoginTokenInfo
    {
        public string LoginToken { get; set; }
        public string ServerUrl { get; set; }
    }

    public class GetLoginTokenResponse
    {
        public LoginTokenInfo Data { get; set; }
    }
}
