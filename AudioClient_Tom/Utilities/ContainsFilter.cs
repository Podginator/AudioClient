using AudioClient_Tom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.Utilities
{
    public class ContainsFilter : IFilterOrganiser<ViewModels.SongViewModel, String>
    {
        public int setFilterRank(SongViewModel filterable, string filter)
        {
            String songTitle = filterable.SongTitle;
            int indexOf = filterable.SongTitle.IndexOf(filter);
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
