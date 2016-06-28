using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.Networking
{
    /// <summary>
    /// An interface reresenting a Server. 
    /// </summary>
    interface IServer
    {

        /// <summary>
        /// Connect Event
        /// </summary>
        event EventHandler<ConnectedHandlerArgs> OnConnect;

        /// <summary>
        /// Disconnect Event
        /// </summary>
        event EventHandler<ConnectedHandlerArgs> OnDisconnect;

        /// <summary>
        /// Incoming Event
        /// </summary>
        event EventHandler<MessageHandlerArgs> OnMessageIncoming;

        /// <summary>
        /// Outgoing message Event.
        /// </summary>
        event EventHandler<MessageHandlerArgs> OnMessageOutgoing;


        /// <summary>
        /// Connect To the Server
        /// </summary>
        /// <param name="address"> the address </param>
        /// <param name="port">the port to connect to</param>
        void Connect(string address, int port);

        /// <summary>
        /// Disconnect from the server
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Send to the server
        /// </summary>
        /// <param name="sendedString"> Send to the Server</param>
        void Send(string sendedString);

        
    }
}
