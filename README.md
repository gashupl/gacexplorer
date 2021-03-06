GAC EXPLORER is a tool for managing Global Assembly Cache memory. It is visual frontend for gacutil.exe tool so it requires gacutil.exe tool’s availability on the local operating system. 

Release build may be downloaded from:
http://piotrgaszewski.pl/release/gacexplorer/GacExplorer-1.1.1.0.zip

Prerequisites:

GAC EXPLORER was created .NET on .NET Framework 4.7.2. so, it requires its runtime on local machine to be working correctly. Because it uses gacutil.exe tool internally – you need to have it also installed. The easiest way to obtain gacutil.exe tool is to install Windows SDK (the one mentioned below or other specific to your operating system).  

Links:
1.	.NET Framework runtime 4.7.2 (https://dotnet.microsoft.com/download/dotnet-framework/net472) or higher version.
2.	Windows 10 SDK (https://developer.microsoft.com/en-us/windows/downloads/windows-10-sdk) 

First-time run:
 
1.	Unpack GacExplorer-version_number.zip. 
2.	Run GacExplorer.exe file
3.	When opened first time, you will need to select gacutil.exe file location

![](http://piotrgaszewski.pl/img/gacexplorer/1.png)

After installing Windows 10 SDK gacutil.exe should be available in by default:
“C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools” folder. 

4.	Have fun using GAC EXPLORER 😊. 

![](http://piotrgaszewski.pl/img/gacexplorer/2.png)

Application was tested on the following operating systems:
- Windows 10 PRO
- Windows 2019 Datacenter
- Windows 2016 Datacenter

Older versions:
- 1.1.0.0: http://piotrgaszewski.pl/release/gacexplorer/GacExplorer-1.1.0.0.zip
- 1.0.0.0: http://piotrgaszewski.pl/release/gacexplorer/GacExplorer-1.0.0.0.zip
