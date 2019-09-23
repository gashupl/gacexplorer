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
        public string PublicKeyToken { get; set; }
        public string ProcessorArchitecture { get; set; }
    }
}
