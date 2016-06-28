using AudioClient_Tom.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.PacketHandlers
{
    public class TestHandler
    {
        public static int i = 0;
        public void handleMessage(object obj, MessageHandlerArgs args)
        {
            TestEvent evt = new TestEvent();
            evt.message = "Hello" + i++;
            EventAggregator.EventAggregator.Instace.RaiseEvent<TestEvent>(evt);
        }

    }

    public class TestEvent
    {
        public String message { get; set; }
    }
}
