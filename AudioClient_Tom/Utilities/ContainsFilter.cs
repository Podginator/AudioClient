using AudioClient_Tom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.Utilities
{
    public class ContainsFilter : IFilterOrganiser<String, String>
    {
        public int setFilterRank(String filterable, string filter)
        {
            int indexOf = filterable.IndexOf(filter);
            if (indexOf > -1)
            {
                return 100 - indexOf;
            } 
            else
            {
                return 0;
            }

        }
    }
}
