using System;

namespace CrashPlanAPILib.Models.Info
{
    public class ComputerInfo
    {
        public string ComputerId { get; set; }
        public string Name { get; set; }
        public string Guid { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public bool Active { get; set; }
        public bool Blocked { get; set; }

        public int AlertState { get; set; }
        public string[] AlertStates { get; set; }

        public string UserId { get; set; }
        public string UserUid { get; set; }
        public string OrgId { get; set; }
        public string OrgUid { get; set; }

        public string ComputerExtRef { get; set; }
        public string Notes { get; set; }
        public string ParentComputerId { get; set; }
        public string ParentComputerGuid { get; set; }
        public DateTime? LastConnected { get; set; }
        public string OsName { get; set; }
        public string OsVersion { get; set; }
        public string OsArch { get; set;}
        public string Address { get; set; }
        public string RemoteAddress { get; set; }
        public string JavaVersion { get; set; }
        public string TimeZone { get; set; }
        public string Version { get; set; }
        public string ProductVersion { get; set;}
        public string BuildVersion { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? LoginDate { get; set; }

        public BackupUsageInfo[] BackupUsage { get; set; }

    }
}
