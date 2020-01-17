using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GacExplorer.UI.Commands.Base;

namespace GacExplorer.UI.Commands
{
    public class ApplicationExitCommand : ICommand
    {
        public void Execute()
        {
            Application.Exit();
        }
    }
}
