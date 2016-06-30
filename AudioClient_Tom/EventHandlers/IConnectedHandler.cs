using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.EventHandlers
{
    interface IConnectedHandler
    {
        /// <summary>
        /// Handle a server connecting.
        /// </summary>
        /// <param name="connected"> Are we connected </param>
        /// <param name="uri">the URI of where we are connected to </param>
        void HandleServerConnected(bool connected, Uri uri);
    }
}
