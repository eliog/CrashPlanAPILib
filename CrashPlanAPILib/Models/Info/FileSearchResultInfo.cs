using System;

namespace CrashPlanAPILib.Models.Info
{
    public class FileSearchResultInfo
    {
        public string Filename { get; set; }
        public string Path { get; set; }
        public string Id { get; set; }
        public long LastModified { get; set; }
        public bool Deleted { get; set; }
        public bool Hidden { get; set; }
        public DateTime? Date { get; set; }
        public string Type { get; set; }

        public DateTime LastModifedAsDateTime()
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            epoch = epoch.AddMilliseconds(LastModified);
            return epoch;
        }
    }
}
