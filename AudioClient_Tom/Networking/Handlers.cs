﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.Networking
{
    public class ConnectedHandlerArgs : EventArgs {
        public bool Connected { get; set; }

        public String Location { get; set; }
    
    };

    public class MessageHandlerArgs : EventArgs
    {
        public string Message { get; set; }

        public Object sender { get; set; }

    };

}