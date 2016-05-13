using CrashPlanAPILib.Models.Info;

namespace CrashPlanAPILib.Models.Responses
{
    
    public class GetComputersResponseData
    {
        public ComputerInfo[] Computers { get; set; }
    }
    
    public class GetUserResponse
    {
        public UserInfo Data { get; set; }
    }
}