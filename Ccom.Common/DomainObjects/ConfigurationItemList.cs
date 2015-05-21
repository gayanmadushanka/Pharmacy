using System.Collections.Generic;

namespace Ccom.Common.DomainObjects
{
    public class ConfigurationItemList
    {
        private List<ConfigurationItem> _configurations = new List<ConfigurationItem>();
        public List<ConfigurationItem> Configurations
        {
            get { return _configurations; }
            set { _configurations = value; }
        }
    }
}
