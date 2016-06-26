using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.Networking.EventHandlers
{
    public interface IMessageReceiveHandler
    {
        void HandleMessageReceived(String message, Socket socket); 
    }
}
