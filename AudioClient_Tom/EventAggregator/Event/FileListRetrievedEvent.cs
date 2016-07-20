using AudioClient_Tom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.EventAggregator.Event
{
    class FileListRetrievedEvent
    {
        public List<Song> SongCollection
        {
            get; set;
        }

        public FileListRetrievedEvent(List<Song> songs)
        {
            SongCollection = songs;
        }
    }
}
