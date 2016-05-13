using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CrashPlanAPILib.Models
{
    public class WebRestoreSessionRequest
    {
        [JsonProperty("computerGuid")]
        public string ComputerGuid { get; set; }
        [JsonProperty("dataKeyToken")]
        public string DataKeyToken { get; set; }
    }
}
