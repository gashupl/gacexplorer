using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GacExplorer.UI.Commands.Base;

namespace GacExplorer.UI.Commands
{
    public class ShowAboutFormCommand : ICommand
    {
        public void Execute()
        {
            new AboutForm().ShowDialog();
        }
    }
}
