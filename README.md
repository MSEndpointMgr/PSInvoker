# PSInvoker

PSInvoker serves as a small utility application to allow for silently running PowerShell scripts without having a flashing window appearing. This comes in handy when administrators would like make use of PowerShell scripts running as scheduled tasks, without dealing a devastating blow to the end-user with annoying windows flashing by.

# Usage

PSInvoker is very simple to use. First of all, either clone this repository and build the executable yourself through e.g. Visual Studio, or download the compiled executable from the Releases section.
For any command line, e.g. in a scheduled task usage scenario, simply call PSInvoker.exe with the proper arguments.

## Command line arguments

PSInvoker supports two command line arguments.
- 

## Examples
```powershell
> PSInvoker.exe <PATH_TO_PS1>
> PSInvoker.exe <PATH_TO_PS1> -e RemoteSigned
> PSInvoker.exe <PATH_TO_PS1> -ExecutionPolicy RemoteSigned
```
