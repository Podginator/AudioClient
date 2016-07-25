using AudioClient_Tom.EventAggregator.Event;
using AudioClient_Tom.Models;
using AudioClient_Tom.Networking;
using AudioClient_Tom.Utilities;
using AudioClient_Tom.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.Concurrent;
using System.Windows.Input;

namespace AudioClient_Tom.ViewModels
{
    class AudioControlViewModel : AbstractObservable
    {


        /// <summary>
        /// The Bytes of the List. Concurrent as we push this on from threads and
        /// wish to avoid synchronicity issues. 
        /// </summary>
        private ConcurrentQueue<byte> byteList;

        /// <summary>
        /// The Memory stream we wish 
        /// </summary>
        private ProducerConsumerStream ms;

        /// <summary>
        /// The sound player we wish to use.
        /// </summary>
        private SoundPlayer soundPlayer;

        private object BufferLock = new object();


        /// <summary>
        /// Default the Songs as Nill;
        /// </summary>
        public AudioControlViewModel()
        {

            byteList = new ConcurrentQueue<byte>();
            ms = new ProducerConsumerStream();
 
            SongTitle = "";
            ArtistName = "";

            EventAggregator.EventAggregator.Instance.RegisterListener<SongChangeEvent>((songEvt) =>
            {
                byteList = new ConcurrentQueue<byte>();
                SongTitle = songEvt.Song.SongTitle;
                ArtistName = songEvt.Song.ArtistName;
                this.FirePropertyChanged("SongTitle");
                this.FirePropertyChanged("ArtistName");

                //Request a packet with this song. 
                EventAggregator.EventAggregator.Instance.RaiseEvent(
                    new Packet(PacketType.TRACK, Marshal.SizeOf(songEvt.Song), Song.Serialize(songEvt.Song)));


            });

            

            EventAggregator.EventAggregator.Instance.RegisterListener<AudioReceivedEvent>((audioEvt) =>
            {
                lock (BufferLock)
                {
                    ms.Write(audioEvt.data, 0, audioEvt.data.Length);
                }
                foreach (byte data in audioEvt.data)
                {
                    byteList.Enqueue(data);
  
                } 
            });
        }


        /// <summary>
        /// Song Title
        /// </summary>
        public String SongTitle {
            get; set;
        }  

        /// <summary>
        /// The Aritst Name
        /// </summary>
        public String ArtistName
        {
            get; set;
        }

        /// <summary>
        /// Send a Song Request change event
        /// </summary>
        /// <param name="type">The Request type we are sending</param>
        private void RequestEvent(SongRequestEvent.REQUEST_TYPE type)
        {
            EventAggregator.EventAggregator.Instance.RaiseEvent<SongRequestEvent>(new SongRequestEvent(type));
        }

        /// <summary>
        /// The command to swap songs. 
        /// </summary>
        public ICommand RequestSendCommand
        {
            get
            {
                return new RelayCommand<SongRequestEvent.REQUEST_TYPE>(RequestEvent, (type) => { return true; });
            }
        }





        /// <summary>
        /// The event to send the song. Calls to the Event Aggregator.
        /// </summary>
        public ICommand PlaySongEvent
        {
            get
            {
                return new RelayCommand(() =>
                {
                    ms.ReadPosition = 0;
                    soundPlayer = new SoundPlayer(ms);
                    soundPlayer.Play();
                }, () => { return true; });
            }
        }


    }
}
