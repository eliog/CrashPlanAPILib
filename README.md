# CrashPlanAPILib
Small library for accessing CrashPlan API with C#

Currently you can pull information about a computer (by guid):

``` c#
var server = new CrashPlanServer();
await server.Login("user","password");
var info = await server.GetComputerInfoByGuid("computerGuid",true,true,true);
Console.WriteLine($"Computer Name = {info.Data.Name}");
Console.WriteLine($"Computer Last Connected = {info.Data.LastConnected}");
```

You can search for computers 
``` c#
var o = await server.SearchComputers(args.ArgSearchquery, true, true, true);
foreach (var computer in o.Data.Computers)
{
    Console.WriteLine($"Computer Name = {computer.Name}");
    Console.WriteLine($"Computer Last Connected = {computer.LastConnected}");
}
```

You can search for files in a computers backup (by regex)
``` c#
var o = await server.BeginWebRestoreSessionForComputerByGuid(args.ArgComputerguid);
var r = await o.SearchForFilesWithRegex("RegexHere");
Console.WriteLine("Found {0} File(s)",r.Data.Length);
foreach (var f in r.Data)
{
    Console.WriteLine($"  {f.Filename} - {f.Path}");
}
```
