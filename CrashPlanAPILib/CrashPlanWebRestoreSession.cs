using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CrashPlanAPILib.Models;
using Newtonsoft.Json.Linq;

namespace CrashPlanAPILib
{
    public class CrashPlanWebRestoreSession
    {
        public string ServerUrl { get; set; }
        public string WebRestoreSessionId { get; set; }
        public string ComputerGuid { get; set; }
        public string DataKeyToken { get; set; }
      
        private CrashPlanServerInterface ServerInterface { get; set; } = new CrashPlanServerInterface();
        
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
            var o = await ServerInterface.PostObject<object, WebRestoreSessionRequest>("webRestoreSession", request);

        }
    }
}
