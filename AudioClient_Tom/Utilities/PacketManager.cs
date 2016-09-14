using AudioClient_Tom.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.Utilities
{
    /// <summary>
    /// Class to handle the sending, receiving and processing of Packets
    /// </summary>
    class PacketManager
    {

        /// <summary>
        ///  The return delegate
        /// </summary>
        /// <param name="responsePacket"></param>
        public delegate void ResponseDelegate(Packet responsePacket);

        /// <summary>
        /// A map from response ID to Delegate. We send out packets with an id
        /// and respond to them. 
        /// </summary>
        private IDictionary<int, ResponseDelegate> mResponseMap;

        /// <summary>
        /// If we want to respond to a specific type, without a response, then we use this map.
        /// This will activate for any with a response ID of 0.
        /// </summary>
        private IDictionary<int, List<ResponseDelegate>> mTypeMap;

        /// <summary>
        /// The Socket manager we are sending to.
        /// </summary>
        private IServer mServer;

        /// <summary>
        ///  Packet Counter
        /// </summary> 
        static int mPacketCounter = 0;

        /// <summary>
        /// Instance of your self.
        /// </summary>
        static PacketManager me;

        /// <summary>
        /// Private constructor to ensure that we can't instansiate otherwise
        /// </summary>
        /// <param name="socket">The Socketmanager to send on.</param>
        private PacketManager(IServer socket)
        {
            mServer = socket;
            mResponseMap = new Dictionary<int, ResponseDelegate>();
            mTypeMap = new Dictionary<int, List<ResponseDelegate>>();
            EventAggregator.EventAggregator.Instance.RegisterListener<Packet>((packet) => { 
                // Initially wait until we're connected.
                while (!mServer.isConnected()) { }

                //Then, if we are, send the packet.
                mServer.Send(Packet.Serialize(packet));
            });

            mServer.OnMessageIncoming += (sender, args) =>
            {
                Packet packet; 
                try
                {
                    packet = Packet.Deserialize(args.data);
                }
                catch (Exception e)
                {
                    // Do nothing
                    return;
                }

                if (mResponseMap.ContainsKey(packet.ID))
                {
                    ResponseDelegate del = mResponseMap[packet.ID];

                    if (del != null)
                    {
                        del(packet);
                    }

                    // Packet End is the packet we send when we've finished responding. We send it to the handler,
                    // Then we remove the listener from the map, as we are done with it.
                    if (packet.Type == PacketType.END)
                    {
                        mResponseMap.Remove(packet.ID);
                    }
                }
                
                if (mTypeMap.ContainsKey(packet.ID))
                {
                    List<ResponseDelegate> delegateList = mTypeMap[packet.ID];

                    foreach (var res in delegateList)
                    {
                        res(packet);
                    }
                } 

            };


        }

        /// <summary>
        /// Create an instance to this Packet Manager. 
        /// </summary>
        /// <param name="manager"> The Socket Manager we wish to write to.</param>
        /// <returns>The instance of the Packet Manager</returns>
        public static PacketManager createInstance(IServer manager)
        {
            me = new PacketManager(manager);

            return me;
        }

        /// <summary>
        /// Return an instance of ourself.
        /// </summary>
        /// <returns>Singleton of PacketManager</returns>
        /// <exception cref="InvalidOperationException"> Thrown when we haven't called Create Instance</exception>
        public static PacketManager sharedInstance()  
        {
            if (me != null)
            {
                return me;
            }
            else
            {
                throw new InvalidOperationException("Did not instantiate the Packet Manager. Call SocketManager first.");
            }
        }

        /// <summary>
        /// Send the Packet, wait for a response. 
        /// </summary>
        /// <param name="type">The type of the packet we wish to send</param>
        /// <param name="size">The size of the packet we wish to send</param>
        /// <param name="data"></param>
        public void SendPacket(int type, int size, byte[] data, ResponseDelegate del)
        {
            if (data.Length != size || size > Packet.MAX_PACKET_SIZE)
            {
                throw new ArgumentException("Size and data inconsistent");
            }

            Packet packet = new Packet();
            packet.Data = data;
            packet.Size = size;
            packet.Type = type;


            SendPacket(packet, del);

        }


        /// <summary>
        /// Send the packet and listen for responses.
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="del"></param>
        public void SendPacket(Packet packet, ResponseDelegate del)
        {
            if (packet.ID != 0)
            {
                throw new ArgumentException("Packet should not have response ID set");
            }

            packet.ID = ++mPacketCounter;
            mResponseMap.Add(mPacketCounter, del);
            mServer.Send(Packet.Serialize(packet));
        }



        /// <summary>
        /// Add a handler to the Type response
        /// </summary>
        /// <param name="packetType">The Packet type we wish to handle</param>
        /// <param name="del">The Response Delegate</param>
        public void addTypeHandler(int packetType, ResponseDelegate del)
        {
            if (!mTypeMap.ContainsKey(packetType))
            {
                mTypeMap[packetType] = new List<ResponseDelegate>();
            }

            mTypeMap[packetType].Add(del);

        }

        /// <summary>
        /// Remove a Type Handlers
        /// </summary>
        /// <param name="packetType">The Packet type of the handler</param>
        /// <param name="del">The Response Delegate</param>
        public void removeTypeHandler(int packetType, ResponseDelegate del)
        {
            List<ResponseDelegate> delList = mTypeMap[packetType];

            if (delList != null)
            {
                delList.Remove(del);
            }
        }

    }
}
