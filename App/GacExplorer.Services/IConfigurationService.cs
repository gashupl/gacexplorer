using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacExplorer.Services
{
    public interface IConfigurationService
    {
        ServiceOperationResult SaveGacutilLocation(string fileLocation);

        ServiceOperationResult ReadGacutilLocation(); 
    }
}
