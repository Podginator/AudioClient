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

    // State object for reading client data asynchronously
    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    /// <summary>
    /// Socket Manager, Handling the Incoming packets from the Socket.
    /// </summary>
    class SocketManager : IServer
    {
        // The Socket we're retrieving the incoming connections from.
        private Socket mSocket;

        /// <summary>
        /// Connect Event
        /// </summary>
        public event EventHandler<ConnectedHandlerArgs> OnConnect;

        /// <summary>
        /// Disconnect Event
        /// </summary>
        public event EventHandler<ConnectedHandlerArgs> OnDisconnect;

        /// <summary>
        /// Incoming Event
        /// </summary>
        public event EventHandler<MessageHandlerArgs> OnMessageIncoming;

        /// <summary>
        /// Outgoing message Event.
        /// </summary>
        public event EventHandler<MessageHandlerArgs> OnMessageOutgoing;

        /// <summary>
        /// Constructor. 
        /// Takes a port and address to listen on.
        /// </summary>
        public SocketManager()
        {
            //Create the Socket.
            mSocket = new Socket(AddressFamily.InterNetwork, 
                SocketType.Stream, ProtocolType.Tcp);
            OnConnect += (e, b) => { Thread.Sleep(1404040); };
            OnDisconnect += (e, b) => { };
            OnMessageIncoming += (e, b) => { };
            OnMessageOutgoing += (e, b) => { };

        }

        /// <summary>
        /// Connect To the Server
        /// </summary>
        /// <param name="address"> the address </param>
        /// <param name="port">the port to connect to</param>
        public void Connect(String address, int port)
        {
            try {
                // Retrieve the Host Information
                IPHostEntry ipHostInfo = Dns.Resolve(address);
                // The IP Address.
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                // The End Point.
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Begin Connecting to the Socket. 
                mSocket.BeginConnect(remoteEP, new AsyncCallback(Connected),
                    mSocket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Disconnect from the server
        /// </summary>
        public void Disconnect()
        {
            //not implemented yet.
        }

        private void Connected(IAsyncResult ar)
        {
            mSocket.EndConnect(ar);
            ConnectedHandlerArgs connectedHandlerArgs = new ConnectedHandlerArgs();
            connectedHandlerArgs.Connected = true;

            OnConnect.Invoke(this, connectedHandlerArgs);
        
            //When we've connected it's time to start retrieving data.
            Receive();
        } 



        private void Receive()
        {
            try
            {
                StateObject state = new StateObject();
                state.workSocket = mSocket;
                mSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);

            }
            catch (Exception e)
            {
                //Do nothing
            }
        }

        /// <summary>
        /// The Callback From the Receive. 
        /// </summary>
        /// <param name="res"> The Async Result </param>
        private void ReceiveCallback(IAsyncResult res)
        {
            try
            {
                StateObject state = (StateObject)res.AsyncState;
                int bytesRead = mSocket.EndReceive(res);

                if (bytesRead > 0)
                {
                    Console.WriteLine(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                }

                Receive();
            }
            catch (Exception e)
            {
                //donothing
            }
        }

        /// <summary>
        /// Send to the server
        /// </summary>
        /// <param name="sendedString"> Send to the Server</param>
        public void Send(String sendData)
        {
            byte[] data = Encoding.ASCII.GetBytes(sendData);

            mSocket.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback), mSocket);
        }

        /// <summary>
        /// The callback from the send event 
        /// </summary>
        /// <param name="ar">The Async result </param>
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                int bytesSent = mSocket.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}