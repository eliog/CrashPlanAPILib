using Newtonsoft.Json;

namespace CrashPlanAPILib.Models.Requests
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
}
