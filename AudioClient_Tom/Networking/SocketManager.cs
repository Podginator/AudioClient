using AudioClient_Tom.Networking.EventHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioClient_Tom.Networking
{
    /// <summary>
    /// Socket Manager, Handling the Incoming packets from the Socket.
    /// </summary>
    class SocketManager
    {
        // The Socket we're retrieving the incoming connections from.
        private Socket mSocket;

        //Event Handlers. 

        public delegate void ConnectedHandler(bool connected, Uri uri);

        /// <summary>
        /// Connect Event
        /// </summary>
        public event ConnectedHandler OnConnect;

        /// <summary>
        /// Disconnect Event
        /// </summary>
        public event ConnectedHandler OnDisconnect;

        /// <summary>
        /// The delegate for Handling a message
        /// </summary>
        /// <param name="message">
        ///  sThe Message
        /// </param>
        /// <param name="socket">
        /// The Socket being sent from
        /// </param>
        public delegate void MessageHandler(String message, Socket socket);

        /// <summary>
        /// Incoming Event
        /// </summary>
        public event MessageHandler OnMessageIncoming;

        /// <summary>
        /// Outgoing message Event.
        /// </summary>
        public event MessageHandler OnMessageOutgoing; 
 
        // The thread we'll listen on 
        private Thread mIncomingThread;

        //The port to listen on
        private int mPort;

        // The Address to listen to.
        private String mAddress;

        /// <summary>
        /// Constructor. 
        /// Takes a port and address to listen on.
        /// </summary>
        public SocketManager(String address, int ip)
        {
            //Create the Socket.
            mSocket = new Socket(AddressFamily.InterNetwork, 
                SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect()
        {
            IPHostEntry ipHostInfo = Dns.Resolve(mAddress);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, mPort);

            mSocket.BeginConnect(remoteEP, new AsyncCallback(Connected),
                mSocket);
        }

        private void Connected(IAsyncResult ar)
        {
            mSocket.EndConnect(ar);
            OnMessageIncoming("str", mSocket);

            //Then set up the listening threads. 
        } 

        private void Receive()
        {
            //Conn
        }

    }
}