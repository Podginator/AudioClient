using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.EventAggregator.Event
{
    class FriendUpdateEvent
    {
        public String mName;

        public String mEvt; 

        public FriendUpdateEvent(String name, String evt)
        {
            mName = name;
            mEvt = evt;
        }

    }
}
