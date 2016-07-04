using AudioClient_Tom.EventAggregator.Event;
using AudioClient_Tom.Models;
using AudioClient_Tom.Utilities;
using AudioClient_Tom.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

            EventAggregator.EventAggregator.Instace.RegisterListener<SongChangeEvent>((songEvt) =>
            {
                SongTitle = songEvt.Song.SongTitle;
                ArtistName = songEvt.Song.ArtistName;

                this.FirePropertyChanged("SongTitle");
                this.FirePropertyChanged("ArtistName");
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

        // Swap out the View
        private void RequestEvent(SongRequestEvent.REQUEST_TYPE type)
        {

            EventAggregator.EventAggregator.Instace.RaiseEvent<SongRequestEvent>(new SongRequestEvent(type));
        }

        // We can swap if our Menu Item Control is not nul.
        private Boolean canSwap(SongRequestEvent.REQUEST_TYPE typee)
        {
            return true;
        }

        // the Command to use to swap out a view model.
        public ICommand RequestSendCommand
        {
            get
            {
                return new RelayCommand<SongRequestEvent.REQUEST_TYPE>(RequestEvent, canSwap);
            }
        }


    }
}
