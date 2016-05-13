using System;
 

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
                var o = server.GetComputerInfoByGuid(args.ArgComputerguid,true,true,true).Result;
                Console.WriteLine($"Computer Name = {o.Data.Name}");
                Console.WriteLine($"Computer Last Connected = {o.Data.LastConnected}");
            }
            if (args.CmdSearchComputers)
            {
                var o = server.SearchComputers(args.ArgSearchquery, true, true, true).Result;
                foreach (var computer in o.Data.Computers)
                {
                    Console.WriteLine($"Computer Name = {computer.Name}");
                    Console.WriteLine($"Computer Last Connected = {computer.LastConnected}");
                }
            }
             
            if (args.CmdSearchBackupRegex)
            {
                var o = server.BeginWebRestoreSessionForComputerByGuid(args.ArgComputerguid).Result;
                var r = o.SearchForFilesWithRegex(args.ArgRegex).Result;
                //@"(charm{0}\d*.bak|FUL-charm-\d*.bak)").Result;
                Console.WriteLine("Found {0} File(s)",r.Data.Length);
                foreach (var f in r.Data)
                {
                    Console.WriteLine($"  {f.Filename} - {f.Path}");
                }
            }


        }

    }
}
