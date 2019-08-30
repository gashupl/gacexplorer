using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacExplorer.Services.Wrappers
{
    public interface IConfiguration
    {
        ConfigurationSection GetSection(string sectionName); 
        void Save(ConfigurationSaveMode saveMode); 
    }
}
