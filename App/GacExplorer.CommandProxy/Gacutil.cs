using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace GacExplorer.CommandProxy
{
    [ExcludeFromCodeCoverage]
    public sealed class Gacutil : IGacutil
    {

        public string Location { get ; set; }

        public Gacutil()
        {
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
                string args = "/i \"" + path + "\"";
                output = StartProcess(gacutilProcess, args, true); 
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
            gacutilProcess.StartInfo.FileName = this.Location;
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
