using CommandLine;

namespace PSInvoker
{
    public sealed class Options
    {
        [Value(0, Required = true, HelpText = "Input full path to PowerShell script file.")]
        public string FilePath { get; set; }

        [Option('e', "ExecutionPolicy", Required = false, HelpText = "Input PowerShell process execution policy.")]
        public string ExecutionPolicy { get; set; }
    }
}
