using System.Collections.Generic;
using DocoptNet;

namespace CrashPlanAPICli
{
    public class MainArgs
    {
        public const string USAGE = @"CrashPlanAPICli Usage

Usage:
  CrashPlanAPICli GetComputer <ComputerGuid>  --user=<user> --pass=<pass> [ --baseUrl=<baseUrl> ]
  CrashPlanAPICli SearchComputers <SearchQuery>  --user=<user> --pass=<pass> [ --baseUrl=<baseUrl> ]
  CrashPlanAPICli GetSignedInUser  --user=<user> --pass=<pass> [ --baseUrl=<baseUrl> ]
  CrashPlanAPICli SearchBackupRegex <ComputerGuid> <regex> --user=<user> --pass=<pass> [ --baseUrl=<baseUrl> ]

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

        public IDictionary<string, ValueObject> Args => _args;

        public bool CmdGetcomputer => _args["GetComputer"].IsTrue;
        public bool CmdSearchComputers => _args["SearchComputers"].IsTrue;
        public bool CmdGetSignedInUser => _args["GetSignedInUser"].IsTrue;
        public bool CmdSearchBackupRegex => _args["SearchBackupRegex"].IsTrue;
        public string ArgComputerguid => _args["<ComputerGuid>"].ToString();
        public string ArgRegex => _args["<regex>"].ToString();
        public string OptUser => _args["--user"].ToString();
        public string OptPass => _args["--pass"].ToString();
        public string OptBaseurl => _args["--baseUrl"].ToString();
        public string ArgSearchquery => _args["<SearchQuery>"].ToString();
    }


}

