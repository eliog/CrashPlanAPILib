namespace CrashPlanAPILib.Models.Info
{
    public class FileSearchResultInfo
    {
        public string Filename { get; set; }
        public string Path { get; set; }
        public string Id { get; set; }
        public string LastModified { get; set; }
        public bool Deleted { get; set; }
        public bool Hidden { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
    }
}
