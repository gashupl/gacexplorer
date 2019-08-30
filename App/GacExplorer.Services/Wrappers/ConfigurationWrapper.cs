using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacExplorer.Services.Wrappers
{
    public class ConfigurationWrapper : IConfiguration
    {
        private Configuration configuration; 
        public ConfigurationWrapper(Configuration configuration)
        {
            this.configuration = configuration; 
        }

        public ConfigurationSection GetSection(string sectionName)
        {
            return this.configuration.GetSection(sectionName); 
        }

        public void Save(ConfigurationSaveMode saveMode)
        {
            this.configuration.Save(saveMode); 
        }
    }
}
