using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashPlanAPICli
{
    class Program
    {
        static void Main(string[] argv)
        {

            // Automatically exit(1) if invalid arguments
            var args = new MainArgs(argv, exit: true);

            var server = new CrashPlanAPILib.CrashPlanServer()
            {
                BaseUrl = args.OptBaseurl,
            };
            server.Login(args.OptUser, args.OptPass).Wait();

            if (args.CmdGetcomputer)
            {
                Console.WriteLine("First command");
                
                var o = server.GetComputerInfoByGuid(args.ArgComputerguid,true,true,true).Result;
            }
        }

    }
}
