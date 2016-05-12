using System;

namespace CrashPlanAPILib.Models
{
    public class BackupUsage
    {
        public string TargetComputerId { get; set; }
        public string TargetComputerParentId { get; set; }
        public string TargetComputerParentGuid { get; set; }
        public string TargetComputerGuid { get; set; }
        public string TargetComputerName { get; set; }
        public string TargetComputerOsName { get; set; }
        public string TargetComputerType { get; set; }
        public int SelectedFiles { get; set; }
        public long SelectedBytes { get; set; }
        public int TodoFiles { get; set; }
        public long TodoBytes { get; set; }
        public long ArchiveBytes { get; set; }
        public long BillableBytes { get; set; }
        public int SendRateAverage { get; set; }
        public int CompletionRateAverage { get; set; }
        public DateTime? LastBackup { get; set; }
        public DateTime? LastCompletedBackup { get; set; }
        public DateTime? LastConnected { get; set; }
        public DateTime? LastMaintenanceDate { get; set; }
        public DateTime? LastCompactDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool Using { get; set; }
        public int AlertState { get; set; }
        public string[] AlertStates { get; set; }
        public decimal PercentComplete { get; set; }
        public string StorePointId { get; set; }
        public string StorePointName { get; set; }
        public string ServerId { get; set; }
        public string ServerGuid { get; set; }
        public string ServerName { get; set; }
        public string ServerHostName { get; set; }
        public bool IsProvider { get; set; }
        public string ArchiveGuid { get; set; }
        public string ArchiveFormat { get; set; }
        public BackupHistory[] History { get; set; }
    }
}