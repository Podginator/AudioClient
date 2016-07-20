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
            if (args.Message.Length > 0)
            {
                //Check that it's the correct type. FileList is currently... 
                {
                    int songSize = Marshal.SizeOf(typeof(Song));
                    //Convert down to new byte array of Length - 1.
                    var rest = args.Message;

                    List<Song> songLists = new List<Song>();
                    int left = args.Size;
                    int written = 0;
                    do
                    {
                        var objectData = rest.Skip(written).Take(songSize).ToArray();
                        var handle = GCHandle.Alloc(objectData, GCHandleType.Pinned);
                        var structure = Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Song));
                        if (structure is Song) {  
                            songLists.Add((Song)structure);
                        }
                        handle.Free();
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
