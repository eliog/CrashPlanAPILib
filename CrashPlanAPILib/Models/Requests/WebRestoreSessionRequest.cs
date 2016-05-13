using Newtonsoft.Json;

namespace CrashPlanAPILib.Models.Requests
{
    public class WebRestoreSessionRequest
    {
        [JsonProperty("computerGuid")]
        public string ComputerGuid { get; set; }
        [JsonProperty("dataKeyToken")]
        public string DataKeyToken { get; set; }
    }

    
}
