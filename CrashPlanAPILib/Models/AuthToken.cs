using System;

namespace CrashPlanAPILib.Models
{
    public class AuthTokenMetadata
    {
        //public object[] Params { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
    public class AuthToken
    {
        public string[] Data { get; set; }
        public AuthTokenMetadata Metadata { get; set; }
    }
}
