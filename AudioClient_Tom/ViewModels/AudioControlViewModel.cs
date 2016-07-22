using AudioClient_Tom.EventAggregator.Event;
using AudioClient_Tom.Models;
using AudioClient_Tom.Networking;
using AudioClient_Tom.Utilities;
using AudioClient_Tom.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace AudioClient_Tom.ViewModels
{
    class AudioControlViewModel : AbstractObservable
    {

        /// <summary>
        /// Default the Songs as Nill;
        /// </summary>
        public AudioControlViewModel()
        {
            SongTitle = "";
            ArtistName = "";

            EventAggregator.EventAggregator.Instance.RegisterListener<SongChangeEvent>((songEvt) =>
            {
                SongTitle = songEvt.Song.SongTitle;
                ArtistName = songEvt.Song.ArtistName;

                this.FirePropertyChanged("SongTitle");
                this.FirePropertyChanged("ArtistName");

                //Request a packet with this song. 
                EventAggregator.EventAggregator.Instance.RaiseEvent<Packet>(new Packet(PacketType.TRACK, 260, Song.Serialize(songEvt.Song)));

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


    }
}
