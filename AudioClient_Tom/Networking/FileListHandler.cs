using AudioClient_Tom.EventAggregator.Event;
using AudioClient_Tom.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.Networking
{
    public class FileListHandler : IMessageReceiveHandlers
    {
        public void HandleMessageReceived(object sender, MessageHandlerArgs args)
        {
            if (args.Packet.Type == PacketType.FILELIST) 
            {
                {
                    int songSize = Marshal.SizeOf(typeof(Song));
                    //Convert down to new byte array of Length - 1.
                    var rest = args.Packet.Data;

                    List<Song> songLists = new List<Song>();
                    int left = args.Packet.Size;
                    int written = 0;
                    do
                    {
                        var objectData = rest.Skip(written).Take(songSize).ToArray();
                        Song song = Song.Deserialize(objectData);

                        if (song != null)
                        {
                            songLists.Add(song);
                        }
                        
                        written += songSize;
                    }
                    while (written < left);

                    FileListRetrievedEvent evt = new FileListRetrievedEvent(songLists);
                    EventAggregator.EventAggregator.Instance.RaiseEvent<FileListRetrievedEvent>(evt);
                }

            }
        }

    }
}
