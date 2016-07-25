using AudioClient_Tom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.EventAggregator.Event
{
    class AudioReceivedEvent
    {
        public Song song
        {
            get; set; 
        }

        public byte[] data { get; set; }
    }
}
