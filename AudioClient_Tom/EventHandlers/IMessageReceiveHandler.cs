using AudioClient_Tom.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.EventHandlers
{
    public interface IMessageReceiveHandler
    {
        void HandleMessageReceived(MessageHandlerArgs args); 
    }
}
