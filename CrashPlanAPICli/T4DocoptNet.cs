
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
  CrashPlanAPICli SearchComputers <SearchQuery>  --user=<user> --pass=<pass> [ --baseUrl=<baseUrl> ]

Options:
 --user=<user>          Username
 --pass=<pass>          Password
 --baseUrl=<baseUrl>    Base URL [default: https://www.crashplanpro.com/api/].

Explanation:
  

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
		public bool CmdSearchComputers { get { return _args["SearchComputers"].IsTrue; } }
		public string ArgSearchquery  { get { return _args["<SearchQuery>"].ToString(); } }
		 
	}

	
}

