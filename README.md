# PSInvoker

PSInvoker serves as a small utility application to allow for silently running PowerShell scripts without having a flashing window appearing. This comes in handy when administrators would like make use of PowerShell scripts running as scheduled tasks, without dealing a devastating blow to the end-user with annoying windows flashing by. To overcome this behavior, in the past it's been widely known to wrap the invocation of a PowerShell script in a VBScript, however Microsoft is not deprecating VBScript in Windows, leaving us without any non-intrusive way of automating tasks on our endpoints.

# Usage

PSInvoker is very simple to use. First of all, either clone this repository and build the executable yourself through e.g. Visual Studio, or download the compiled executable from the Releases section.
For any command line, e.g. in a scheduled task usage scenario, simply call PSInvoker.exe with the proper arguments.

## Command line arguments

PSInvoker supports two command line arguments. The first argument is the full path of the PowerShell script file, e.g. C:\Scripts\Script.ps1. By default, PSInvoker is set to invoke the PowerShell script file using 'Bypass' as the execution policy. This can be overridden by using the -e (--ExecutionPolicy) command line argument, and pass in any of the supported values: AllSigned, Bypass, RemoteSigned, Restricted, Unrestricted.

## Examples
```cmd
> PSInvoker.exe <PATH_TO_PS1>
> PSInvoker.exe <PATH_TO_PS1> -e RemoteSigned
> PSInvoker.exe <PATH_TO_PS1> --ExecutionPolicy RemoteSigned
```

## Logging

PSInvoker writes to a log file placed in the %TEMP% folder called PSInvoker.log.
