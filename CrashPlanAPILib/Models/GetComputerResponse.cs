namespace CrashPlanAPILib.Models
{
    public class GetComputerResponse
    {
        public ComputerInfo Data { get; set; }
    }

    public class GetComputersResponseData
    {
        public ComputerInfo[] Computers { get; set; }
    }
    public class GetComputersResponse
    {
        public GetComputersResponseData Data { get; set; }
    }

    public class GetUserResponse
    {
        public UserInfo Data { get; set; }
    }
}