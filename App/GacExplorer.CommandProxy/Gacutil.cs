using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacExplorer.CommandProxy
{
    public class Gacutil : IGacutil
    {
        private string location; 
        public Gacutil(string location)
        {
            this.location = location; 
        }
    }
}
