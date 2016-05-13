using System.Threading.Tasks;
using CrashPlanAPILib.Models.Info;
using CrashPlanAPILib.Models.Requests;
using CrashPlanAPILib.Models.Responses;

namespace CrashPlanAPILib
{
    /// <summary>
    /// CrashPlan Server 
    /// 
    /// </summary>
    public class CrashPlanServer
    {
        /// <summary>
        /// Base Url to connect to the server.  Defaults to (https://www.crashplanpro.com/api/) which is what works for Crashplan Pro
        /// </summary>
        public string BaseUrl { get; set; } = "https://www.crashplanpro.com/api/";

        public CrashPlanServerInterface ServerInterface { get; } = new CrashPlanServerInterface();
        
        /// <summary>
        /// Login to the server
        /// </summary>
        /// <param name="username">Crashplan username</param>
        /// <param name="password">Crashplan password</param>
        /// <returns></returns>
        public async Task Login(string username, string password)
        {
            ServerInterface.ServerUrl = BaseUrl;
            await ServerInterface.Login(username, password);
        }

        /// <summary>
        /// Get computer info by the computer's Guid
        /// </summary>
        /// <param name="computerGuid">Computer's Guid</param>
        /// <param name="incBackupUsage">Include destinations and their backup stats</param>
        /// <param name="incActivity">Include backup history data for each destination</param>
        /// <param name="incHistory">Include live backup activity stats</param>
        /// <returns></returns>
        public async Task<CrashPlanDataResponse<ComputerInfo>> GetComputerInfoByGuid(string computerGuid,bool incBackupUsage = false, bool incActivity=false, bool incHistory = false)
        {
            return await ServerInterface.GetObject<CrashPlanDataResponse<ComputerInfo>>($"Computer/{computerGuid}?idType=guid&incBackupUsage={incBackupUsage}&incActivity={incActivity}&incHistory={incHistory}");
        }

        /// <summary>
        /// Get computers by their name or partial computer gid
        /// </summary>
        /// <param name="q">Query</param>
        /// <param name="incBackupUsage">Include destinations and their backup stats</param>
        /// <param name="incActivity">Include backup history data for each destination</param>
        /// <param name="incHistory">Include live backup activity stats</param>
        /// <returns></returns>
        public async Task<CrashPlanDataResponse<GetComputersResponseData>> SearchComputers(string q, bool incBackupUsage = false, bool incActivity = false, bool incHistory = false)
        {
            return await ServerInterface.GetObject<CrashPlanDataResponse<GetComputersResponseData>>($"Computer?q={q}&incBackupUsage={incBackupUsage}&incActivity={incActivity}&incHistory={incHistory}");
        }

        /// <summary>
        /// Returns the currently signed in user
        /// </summary>
        /// <returns></returns>
        public async Task<GetUserResponse> GetSignedInUser()
        {
            return await ServerInterface.GetObject<GetUserResponse>("User/my");
        }
        /// <summary>
        /// Get the datakeytoken for a computer
        /// </summary>
        /// <param name="computerGuid"></param>
        /// <returns></returns>
        public async Task<CrashPlanDataResponse<DataKeyTokenInfo>> GetDataKeyTokenForComputerByGuid(string computerGuid)
        {
            return await ServerInterface.PostObject<CrashPlanDataResponse<DataKeyTokenInfo>, DataKeyTokenRequest>("DataKeyToken", new DataKeyTokenRequest() {  ComputerGuid = computerGuid});
        }
        /// <summary>
        /// Get a login token for a backup server
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="sourceGuid">Source Computer Guid</param>
        /// <param name="destinationGuid">Backup Destination Guid</param>
        /// <returns></returns>
        public async Task<CrashPlanDataResponse<LoginTokenInfo>> GetLoginToken(int userId, string sourceGuid, string destinationGuid)
        {
            var req = new LoginTokenRequest()
            {
                UserId = userId,
                SourceGuid = sourceGuid,
                DestinationGuid = destinationGuid
            };
            return await ServerInterface.PostObject<CrashPlanDataResponse<LoginTokenInfo>, LoginTokenRequest>("LoginToken", req);

        }
        /// <summary>
        /// Begins a web restore session for a computer.  uses the 1st destination
        /// </summary>
        /// <param name="computerGuid">Computer Guid</param>
        /// <returns></returns>
        public async Task<CrashPlanWebRestoreSession> BeginWebRestoreSessionForComputerByGuid(string computerGuid)
        {
            // get signed in user so we can get the user's id, we also need the computers backup target guid so we get that as well.
            var userTask  = GetSignedInUser();
            var computerTask = GetComputerInfoByGuid(computerGuid, true);

            // We'll also need the datakeytoken later
            var dataKeyTokenTask = GetDataKeyTokenForComputerByGuid(computerGuid);

            await Task.WhenAll(userTask, computerTask);
            
            var userId = userTask.Result.Data.UserId;
            var sourceGuid = computerGuid;
            var destinationGuid = computerTask.Result.Data.BackupUsage[0].TargetComputerGuid;

            // get login token for the restore server and make sure we got the data key token

            var loginTokenTask = GetLoginToken(userId, sourceGuid, destinationGuid);
          
            await Task.WhenAll(loginTokenTask, dataKeyTokenTask);
            
            var restoreSession = new CrashPlanWebRestoreSession(loginTokenTask.Result.Data.ServerUrl + "/console/api/");
            await restoreSession.LoginWithToken(loginTokenTask.Result.Data.LoginToken);
            await restoreSession.BeginRestoreSession(computerGuid, dataKeyTokenTask.Result.Data.DataKeyToken);
            return restoreSession;
        }
    }
}
