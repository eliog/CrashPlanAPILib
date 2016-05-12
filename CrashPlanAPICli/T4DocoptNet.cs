
using System.Collections;
using System.Collections.Generic;
using DocoptNet;

namespace CrashPlanAPICli
{
    // Generated class for Main.usage.txt
	public class MainArgs
	{
		public const string USAGE = @"CrashPlanAPICli Usage

Usage:
  CrashPlanAPICli GetComputer <ComputerGuid>  --user=<user> --pass=<pass> [ --baseUrl=<baseUrl> ]
 

Options:
 --user=<user>          Username
 --pass=<pass>          Password
 --baseUrl=<baseUrl>    Base URL [default: https://www.crashplanpro.com/api/].

Explanation:
 This is an example usage file that needs to be customized.
 Every time you change this file, run the Custom Tool command
 on T4DocoptNet.tt to re-generate the MainArgs class
 (defined in T4DocoptNet.cs).
 You can then use the MainArgs classed as follows:

    class Program
    {

       static void DoStuff(string arg, bool flagO, string longValue)
       {
         // ...
       }

        static void Main(string[] argv)
        {
            // Automatically exit(1) if invalid arguments
            var args = new MainArgs(argv, exit: true);
            if (args.CmdCommand)
            {
                Console.WriteLine(""First command"");
                DoStuff(args.ArgArg, args.OptO, args.OptLong);
            }
        }
    }

";
	    private readonly IDictionary<string, ValueObject> _args;
		public MainArgs(ICollection<string> argv, bool help = true,
                                                      object version = null, bool optionsFirst = false, bool exit = false)
		{
			_args = new Docopt().Apply(USAGE, argv, help, version, optionsFirst, exit);
		}

        public IDictionary<string, ValueObject> Args
        {
            get { return _args; }
        }

		public bool CmdGetcomputer { get { return _args["GetComputer"].IsTrue; } }
		public string ArgComputerguid  { get { return _args["<ComputerGuid>"].ToString(); } }
		public string OptUser { get { return _args["--user"].ToString(); } }
		public string OptPass { get { return _args["--pass"].ToString(); } }
		public string OptBaseurl { get { return _args["--baseUrl"].ToString(); } }
	
	}

	
}

