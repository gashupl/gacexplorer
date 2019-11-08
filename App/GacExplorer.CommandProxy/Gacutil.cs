using System.Diagnostics;
using System.IO;

namespace GacExplorer.CommandProxy
{
    public sealed class Gacutil : IGacutil
    {
        private string location;

        public Gacutil(string location)
        {
            this.location = location; 
        }

        public string ListAssemblies()
        {
            string output;
            using (Process gacutilProcess = new Process())
            {
                output = StartProcess(gacutilProcess, "-l");
                gacutilProcess.WaitForExit();
            }

            return output;
        }

        public string RegisterAssembly(string path)
        {
            //Sample command for registering:  .\gacutil.exe /i C:\Users\piog\Source\GitHub\gacexplorer\Assets\GacExplorer.TestLibrary\bin\Debug\GacExplorer.TestLibrary.dll
            string output;
            using (Process gacutilProcess = new Process())
            {
                output = StartProcess(gacutilProcess, $"/i {path}", true); 
                gacutilProcess.WaitForExit();
            }

            return output;
        }

        public string UnregisterAssembly(string name)
        {
            //Sample command for unregister:  .\gacutil.exe /u GacExplorer.TestLibrary
            string output;
            using (Process gacutilProcess = new Process())
            {
                output = StartProcess(gacutilProcess, $"/u {name}", true);
                gacutilProcess.WaitForExit();
            }

            return output;
        }

        private string StartProcess(Process gacutilProcess, string arguments, bool runas = false)
        {
            gacutilProcess.StartInfo.UseShellExecute = false;
            gacutilProcess.StartInfo.FileName = this.location;
            gacutilProcess.StartInfo.Arguments = arguments;
            gacutilProcess.StartInfo.CreateNoWindow = true;
            gacutilProcess.StartInfo.UseShellExecute = false;
            gacutilProcess.StartInfo.RedirectStandardOutput = true;

            if (runas)
            {
                gacutilProcess.StartInfo.Verb = "runas";
            }

            var result = gacutilProcess.Start();
            StreamReader reader = gacutilProcess.StandardOutput;
            return reader.ReadToEnd();
        }


    }   
}
