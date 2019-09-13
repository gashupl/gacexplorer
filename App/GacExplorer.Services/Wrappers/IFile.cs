using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacExplorer.Services.Wrappers
{
    public interface IFile
    {
        bool FileExists(string location); 
    }
}
