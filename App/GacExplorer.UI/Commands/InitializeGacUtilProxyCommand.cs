using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GacExplorer.CommandProxy;
using GacExplorer.Services;
using GacExplorer.Services.OperationResults;
using GacExplorer.UI.Commands.Base;

namespace GacExplorer.UI.Commands
{
    public class InitializeGacUtilProxyCommand : Command, ICommand
    {
        private ICommand showGacFileDialogCommand;
        private IGacutilLocationService gacutilLocationService;
        private IGacutil gacUtilProxy;
        public InitializeGacUtilProxyCommand(ICommand showGacFileDialogCommand, IGacutilLocationService gacutilLocationService, IGacutil gacUtilProxy)
        {
            this.showGacFileDialogCommand = showGacFileDialogCommand;
            this.gacutilLocationService = gacutilLocationService;
            this.gacUtilProxy = gacUtilProxy;
        }

        public void Execute()
        {
            var result = this.gacutilLocationService.Read();
            if (result.Result == OperationResult.Success)
            {
                var location = result.Location;
                if (this.gacutilLocationService.FileExists(location))
                {
                    this.gacUtilProxy = new Gacutil(location);
                }
                else
                {
                    Invoke(showGacFileDialogCommand);
                }
            }
        }
    }
}
