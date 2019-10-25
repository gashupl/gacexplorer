using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                gacutilProcess.StartInfo.UseShellExecute = false;

                gacutilProcess.StartInfo.FileName = this.location;
                gacutilProcess.StartInfo.Arguments = "-l";
                gacutilProcess.StartInfo.CreateNoWindow = true;
                gacutilProcess.StartInfo.UseShellExecute = false;
                gacutilProcess.StartInfo.RedirectStandardOutput = true;
                var result = gacutilProcess.Start();

                StreamReader reader = gacutilProcess.StandardOutput;
                output = reader.ReadToEnd();

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
                gacutilProcess.StartInfo.UseShellExecute = false;

                gacutilProcess.StartInfo.FileName = this.location;
                gacutilProcess.StartInfo.Arguments = $"/i {path}";
                gacutilProcess.StartInfo.CreateNoWindow = true;
                gacutilProcess.StartInfo.UseShellExecute = false;
                gacutilProcess.StartInfo.RedirectStandardOutput = true;
                var result = gacutilProcess.Start();

                StreamReader reader = gacutilProcess.StandardOutput;
                output = reader.ReadToEnd();

                gacutilProcess.WaitForExit();
            }

            return output;
        }

        public string UnregisterAssembly(string name)
        {
            //Sample command for unregister:  .\gacutil.exe /u GacExplorer.TestLibrary
            throw new NotImplementedException();
        }
    }   
}
