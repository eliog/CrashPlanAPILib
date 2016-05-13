using Newtonsoft.Json;

namespace CrashPlanAPILib.Models.Requests
{
    public class DataKeyTokenRequest
    {
        [JsonProperty("computerGuid")]
        public string ComputerGuid { get; set; }
    }
}
