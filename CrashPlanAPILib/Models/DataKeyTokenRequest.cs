using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CrashPlanAPILib.Models
{
    public class DataKeyTokenRequest
    {
        [JsonProperty("computerGuid")]
        public string ComputerGuid { get; set; }
    }

    public class DataKeyTokenInfo
    {
        public string DataKeyToken { get; set; }
    }

    public class GetDataKeyTokenResponse
    {
        public DataKeyTokenInfo Data { get; set; }
    }
}
