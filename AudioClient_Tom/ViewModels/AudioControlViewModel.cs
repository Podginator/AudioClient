using AudioClient_Tom.EventAggregator.Event;
using AudioClient_Tom.Models;
using AudioClient_Tom.Networking;
using AudioClient_Tom.Utilities;
using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace AudioClient_Tom.ViewModels
{
    class AudioControlViewModel : AbstractObservable
    {

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

            ms = new ProducerConsumerStream();
 
            SongTitle = "";
            ArtistName = "";

            EventAggregator.EventAggregator.Instance.RegisterListener<SongChangeEvent>((songEvt) =>
            {
                SongTitle = songEvt.Song.SongTitle;
                ArtistName = songEvt.Song.ArtistName;
                this.FirePropertyChanged("SongTitle");
                this.FirePropertyChanged("ArtistName");

                //Request a packet with this song. 
                PacketManager.sharedInstance().SendPacket(
                    new Packet(PacketType.TRACK, Marshal.SizeOf(songEvt.Song), Song.Serialize(songEvt.Song)), GetSongData);

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


        public void GetSongData(Packet packet)
        {
            if (packet.Type == PacketType.AUDIO)
            {
                lock (BufferLock)
                {
                    ms.Write(packet.Data, 0, packet.Data.Length);
                }
            }
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
