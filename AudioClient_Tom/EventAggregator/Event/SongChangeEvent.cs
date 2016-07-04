using AudioClient_Tom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.EventAggregator.Event
{
    public class SongChangeEvent
    {
        public Song Song
        {
            get; set;
        }

        public SongChangeEvent(Song  song)
        {
            Song = song;
        }

    }
}
