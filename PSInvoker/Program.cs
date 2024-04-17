using CommandLine;
using PSInvoker;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace Invoker
{
    internal class Program
    {
        private readonly static string processName = "powershell.exe";

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(options =>
                {
                    Logger.WriteLogFile($"File path argument: {options.FilePath}");
                    RunProcess(options);
                })
                .WithNotParsed(errors =>
                {
                    Logger.WriteLogFile("Provided command line arguments could not be parsed");
                });
        }

        private static void RunProcess(Options commandLine)
        {
            // Retrieve file path for PowerShell script file passed as argument
            string filePath = commandLine.FilePath;

            // Determine execution policy from arguments are valid, if not, fall back to Bypass
            string executionPolicy;
            string[] exePolicies = new string[] { "AllSigned", "Bypass", "RemoteSigned", "Restricted", "Unrestricted" };
            if (exePolicies.Any(policy => policy == commandLine.ExecutionPolicy))
            {
                executionPolicy = commandLine.ExecutionPolicy;
            }
            else
            {
                executionPolicy = "Bypass";
            }

            // Verify that the file exists
            if (File.Exists(filePath))
            {
                Logger.WriteLogFile($"Found script file: {filePath}");

                // Build arguments based on command line arguments
                string arguments = $"-NoProfile -ExecutionPolicy {executionPolicy}" + " -File \"" + filePath + "\"";
                Logger.WriteLogFile($"Invoking process command: {processName} {arguments}");

                // Construct new powershell.exe process for the PowerShell script file
                Process process = new Process();
                process.StartInfo.FileName = processName;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                Logger.WriteLogFile("Invoked process successfully");

                if (commandLine.Wait == true)
                {
                    process.WaitForExit();
                    Logger.WriteLogFile($"PowerShell process completed with exit code: {process.ExitCode}");
                }
            }
            else
            {
                Logger.WriteLogFile($"Invalid file path: {filePath}");
            }
        }
    }
}