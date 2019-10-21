using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacExplorer.Services.DTO
{
    public class AssemblyLineDto
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Culture { get; set; }
        public string PublicKeyToken { get; set; }
        public string ProcessorArchitecture { get; set; }

        public bool IsValid()
        {
            if(String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Version) || String.IsNullOrEmpty(Culture)
                || String.IsNullOrEmpty(PublicKeyToken) || String.IsNullOrEmpty(ProcessorArchitecture))
            {
                return false; 
            }
            else
            {
                return true; 
            }
        }
    }
}
