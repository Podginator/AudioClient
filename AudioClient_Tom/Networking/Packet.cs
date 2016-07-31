using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.Networking
{
    public static class PacketType
    {
        public const int NO_OPP = 0;
        public const int ACKNOWLEDGE = 1 << 1;
        public const int TRACK = 1 << 2;
        public const int AUDIO = 1 << 3;
        public const int HEADER = 1 << 4;
        public const int FILELIST = 1 << 5;
        public const int FRIEND_REQ = 1 << 6;
        public const int USER_UPDATE = 1 << 7;
        public const int EXIT = 1 << 8;
    };


    // Interoperable Packet from C++ 
    [StructLayout(LayoutKind.Sequential)]
    public class Packet
    {

        public const int MAX_PACKET_SIZE = 1024;

        private Int32 mSize;

        private Int32 mType;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        private byte[] packetData;

        public Packet(int type, int size, byte[] data)
        {
            mType = type;
            mSize = size;
            packetData = data; 
        }

        public Packet()
        {
            mType = 0;
            mSize = 0;
            packetData = null;
        }

        public Packet(int type, int size, String data)
        {
            mType = type;
            mSize = size;
            setDataAsString(data);
        }

        public Int32 Type
        {
            get
            {
                return mType;
            }

            set
            {
                mType = value;
            }
        }

        public Int32 Size
        {
            get
            {
                return mSize;
            }

            set
            {
                mSize = value;
            }
        }

        public byte[] Data
        {
            get
            {
                return packetData;
            }

            set
            {
                if (value.Length < 1024)
                {
                    packetData = value;
                }
                else
                {
                    throw new ArgumentException("Packet too large");
                }
            }
        }


        public void setDataAsString(String data) {
            byte[] byteData = Encoding.UTF8.GetBytes(data);

            if (byteData.Length > 1024)
            {
                //This is too long, throw an Exception.
                throw new ArgumentException(
                    "Data in a packet may not exceed 1024 Bytes. Try chunking this packet.");
            }

            packetData = byteData;
        }

        public static Packet Deserialize(byte[] data)
        {
            Packet res = null;
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            var structure = Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Packet));
            if (structure is Packet)
            {
                res = (Packet)structure;
            }
            handle.Free();

            return res;
        }

        // Todo - This is a very dumb way of serializing this data. 
        public static byte[] Serialize(Packet packet)
        { 
            byte[] typeBytes = BitConverter.GetBytes(packet.mType);
            byte[] sizeBytes = BitConverter.GetBytes(packet.mSize);
            int arrSize = typeBytes.Length + sizeBytes.Length + Packet.MAX_PACKET_SIZE;
            byte[] byteArray = new byte[arrSize];

            int written = 0;

            for (int i = 0; i < sizeBytes.Length; i++)
            {
                byteArray[written++] = sizeBytes[i];
            }

            for (int i = 0; i < typeBytes.Length; i++)
            {
                byteArray[written++] = typeBytes[i];
            }

            for (int i = 0; i < packet.packetData.Length; i++)
            {
                byteArray[written++] = packet.packetData[i];
            }

            return byteArray;
        } 

    }
}
