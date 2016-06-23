using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.Utilities
{
    public interface IFilterOrganiser<Filtering, Filterable>
    {
        int setFilterRank(Filtering filterable, Filterable filter); 
    }
}