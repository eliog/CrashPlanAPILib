using System;

namespace CrashPlanAPILib.Models
{
    public class BackupHistory
    {
        public DateTime? Date { get; set; }
        public long BillableBytes { get; set; }
        public DateTime? LastActivity { get; set; }
        public DateTime? LastCompletedBackup { get; set; }
        public DateTime? LastConnected { get; set; }
        public int SelectedFiles { get; set; }
        public long SelectedBytes { get; set; }
        public int TodoFiles { get; set; }
        public long TodoBytes { get; set; }
        public long ArchiveBytes { get; set; }
        public int SendRateAverage { get; set; }
        public int CompletionRateAverage { get; set; }
        public DateTime? CreationDate { get; set; }

    }
}