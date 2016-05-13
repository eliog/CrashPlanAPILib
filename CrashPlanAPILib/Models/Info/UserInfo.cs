using System;
using System.Collections.Generic;

namespace CrashPlanAPILib.Models.Info
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string UserUid { get; set; }
        public string Status { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long QuotaInBytes { get; set; }
        public int OrgId { get; set; }
        public string OrgUid { get; set; }
        public string OrgName { get; set; }
        public string UserExtRef { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }
        public bool Blocked { get; set; }
        public bool EmailPromo { get; set; }
        public bool Invited { get; set; }
        public string OrgType { get; set; }
        public bool UsernameIsAnEmail { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool PasswordReset { get; set; }
        public IList<object> Licenses { get; set; }
    }

}
 
