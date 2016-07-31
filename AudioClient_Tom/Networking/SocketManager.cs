using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public StateObject(int size)
        {
            this.size = size;
            buffer = new byte[size];
        }

        public int size = 0;

        // Client  socket.
        public Socket workSocket = null;

        // Receive buffer.
        public byte[] buffer;
    }

    /// <summary>
    /// Socket Manager, Handling the Incoming packets from the Socket.
    /// </summary>
    class SocketManager : IServer
    {
        // The Socket we're retrieving the incoming connections from.
        private Socket mSocket;

        // Can continue listening.
        private bool mCanRetrieve = false;

        // Flag to determine whether we're connected to the server. 
        private bool mConnected = false; 

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

            // Set up socket.
            mSocket.ExclusiveAddressUse = true;
            mSocket.LingerState = new LingerOption(true, 10);
            mSocket.NoDelay = true;
            mSocket.ReceiveBufferSize = 8192;
            mSocket.ReceiveTimeout = 1000;
            mSocket.SendBufferSize = 8192;
            mSocket.SendTimeout = 1000;


            // Instantiate the handlers. 
            OnConnect += (e, b) => { };
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
                    remoteEP);
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
            //Attempt to disconnect from the Client. 
            if (mConnected)
            {
                StateObject state = new StateObject(4);
                state.workSocket = mSocket;
                mSocket.BeginDisconnect(false, Disconnected, state);
            }
        }

        private void Connected(IAsyncResult ar)
        {
            try {
                mSocket.EndConnect(ar);
                ConnectedHandlerArgs connectedHandlerArgs = new ConnectedHandlerArgs();
                connectedHandlerArgs.Connected = true;

                OnConnect.Invoke(this, connectedHandlerArgs);
                mCanRetrieve = true;

                //When we've connected it's time to start retrieving data.
                Receive();
            } catch (Exception e)
            {
                IPEndPoint remoteEP = (IPEndPoint) ar.AsyncState;
                //Unable to connect, wait and try again. 
                Thread.Sleep(1000);
                Connect(remoteEP.Address.ToString(), remoteEP.Port);
            }
        } 

        /// <summary>
        /// Disconnected handler.
        /// </summary>
        /// <param name="ar"></param>
        private void Disconnected(IAsyncResult ar)
        {
            StateObject state = (StateObject) ar.AsyncState;
            if (!state.workSocket.Connected)
            {
                mCanRetrieve = false;
                mConnected = false;
            }
        }


        /// <summary>
        /// Start receiving 
        /// </summary>
        private void Receive()
        {
            try
            {
                // Initially get the size.
                StateObject state = new StateObject(4);
                state.workSocket = mSocket;
                mSocket.BeginReceive(state.buffer, 0, state.size, 0,
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
                int size = BitConverter.ToInt32(state.buffer, 0);

                byte[] buffer = new byte[size + sizeof(int)];
                //Continue to read. 
                int received = mSocket.Receive(buffer, size + sizeof(int), SocketFlags.None);


                if (received > 0)
                {
                    byte[] packetBuffer = new byte[received + state.size];
                    Array.Copy(state.buffer, packetBuffer, state.size);
                    Array.Copy(buffer, 0, packetBuffer, 4, received);

                    MessageHandlerArgs args = new MessageHandlerArgs();
                    args.Packet = Packet.Deserialize(packetBuffer);
                    args.Sender = this;

                    OnMessageIncoming.Invoke(this, args);
                }

                if (mCanRetrieve)
                {
                    Receive();
                }
            
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
        public void Send(byte[] sendData)
        {
            try {
                mSocket.BeginSend(sendData, 0, sendData.Length, 0, new AsyncCallback(SendCallback), mSocket);
            } catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
            }
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

                if (bytesSent > 0)
                {
                    OnMessageOutgoing.Invoke(this, new MessageHandlerArgs());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public bool isConnected()
        {
            return mSocket.Connected;
        }

    }
}