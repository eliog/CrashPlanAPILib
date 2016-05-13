using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CrashPlanAPILib.Models.Responses
{
    public class CrashPlanDataResponseMetaData
    {
        [JsonProperty("timestamp")]
        public DateTime TimeStamp { get; set; }
        [JsonProperty("params")]
        public Dictionary<string, string> Params { get; set; }
    }

    public class CrashPlanDataResponse<TDataType>
    {
        [JsonProperty("metadata")]
        public CrashPlanDataResponseMetaData MetaData { get; set; }    

        [JsonProperty("data")]
        public TDataType Data { get; set; }

    }
}
