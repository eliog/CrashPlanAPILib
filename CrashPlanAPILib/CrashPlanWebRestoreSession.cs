using System.Threading.Tasks;
using CrashPlanAPILib.Models.Info;
using CrashPlanAPILib.Models.Requests;
using CrashPlanAPILib.Models.Responses;

namespace CrashPlanAPILib
{
    public class CrashPlanWebRestoreSession
    {

        private string _webRestoreSessionId;
        private string _computerGuid;
        private CrashPlanServerInterface ServerInterface { get; } = new CrashPlanServerInterface();
        
        internal CrashPlanWebRestoreSession(string serverUrl)
        {
            ServerInterface.ServerUrl = serverUrl;
        }

        public async Task LoginWithToken(string loginToken)
        {
            await ServerInterface.LoginWithToken(loginToken);
        }

        public async Task BeginRestoreSession(string computerGuid, string dataKeyToken)
        {
            var request = new WebRestoreSessionRequest() {ComputerGuid = computerGuid, DataKeyToken = dataKeyToken};
            var resp = await ServerInterface.PostObject<CrashPlanDataResponse<WebRestoreSessionInfo>, WebRestoreSessionRequest>("webRestoreSession", request);
            _webRestoreSessionId = resp.Data.WebRestoreSessionId;
            _computerGuid = computerGuid;
        }

        public async Task<CrashPlanDataResponse<FileSearchResultInfo[]>> SearchForFilesWithRegex(string searchRegex)
        {
            var resp = await ServerInterface.GetObject<CrashPlanDataResponse<FileSearchResultInfo[]>>($"webRestoreSearch?webRestoreSessionId={_webRestoreSessionId}&guid={_computerGuid}&regex={searchRegex}&timestamp=0");
            return resp;
        }
    }
}
