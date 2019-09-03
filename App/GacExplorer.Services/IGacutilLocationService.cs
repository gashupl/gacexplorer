using GacExplorer.Services.OperationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacExplorer.Services
{
    public interface IGacutilLocationService
    {
        ServiceOperationResult Save(string fileLocation);

        ServiceOperationResult Read();

        bool FileExists(string location); 
    }
}
