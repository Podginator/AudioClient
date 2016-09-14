using AudioClient_Tom.EventAggregator.Event;
using AudioClient_Tom.Models;
using System;

namespace AudioClient_Tom.Networking.Handlers
{
    public class IncomingAudioHandler : IMessageReceiveHandlers
    {

        public Song song
        {
            get; set;
        }

        public IncomingAudioHandler()
        {
            EventAggregator.EventAggregator.Instance.RegisterListener<SongChangeEvent>((evt) =>
            {
                //Set the song. 
                song = evt.Song;
            });
        }

        public void HandleMessageReceived(object sender, MessageHandlerArgs args)
        {
           // if (args.Packet.Type == PacketType.AUDIO)
            {
                //If we're an audio packet then just package me up and send me on my way. 
                AudioReceivedEvent evt = new AudioReceivedEvent();
                evt.song = song;
             //   evt.data = new byte[args.Packet.Size];
               // Array.Copy(args.Packet.Data, 0, evt.data, 0, args.Packet.Size);
                EventAggregator.EventAggregator.Instance.RaiseEvent<AudioReceivedEvent>(evt);
            }
        }

    }
}


