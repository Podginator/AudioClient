using AudioClient_Tom.EventAggregator.Event;
using AudioClient_Tom.Models;
using AudioClient_Tom.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace AudioClient_Tom.ViewModels
{
    class SongCollectionViewModel : AbstractObservable
    {

        // Converter to SongViewModel String.
        public delegate String SongConvert(SongViewModel model);

        // A collection of songs. 
        private ObservableCollection<SongViewModel> mSongs;

        // The currently selected song.
        private SongViewModel mSelectedSong; 

        // Converters.
        private IDictionary<String, SongConvert> mConverters;

        // Filters.
        private IDictionary<String, IFilterOrganiser<string, string>> mFilters;

        // The String we'll filter by 
        private string mFilterString;

        //The Key for The Delegate for the Converter.
        private string mConverterKey;

        // The Current Filter Organiser 
        private IFilterOrganiser<string, string> mFilter;

        // current index
        private int mCurrentIndex; 


        /// <summary>
        /// Tempory CTOR. Creates a lot of songs. 
        /// </summary>
        public SongCollectionViewModel()
        {
            mSongs = new ObservableCollection<SongViewModel>();

            mConverters = new Dictionary<String, SongConvert>();
            mConverters.Add("Song Title", e => e.SongTitle);
            mConverters.Add("Artist Name", e => e.ArtistName);
            mFilters = new Dictionary<String, IFilterOrganiser<string, string>>();
            mFilters.Add("Exact Match", new ContainsFilter());
            mFilters.Add("Fuzzy Match", new ContainsFilter());

            CurrentFilter = mFilters["Exact Match"];
            ConverterKey = "Song Title";
            SelectedIndex = -1;

            EventAggregator.EventAggregator.Instance.RegisterListener<SongRequestEvent>((songEvt) =>
            {
                if (songEvt.Type == SongRequestEvent.REQUEST_TYPE.Next)
                {
                    SelectedIndex++;
                }
                else if (songEvt.Type == SongRequestEvent.REQUEST_TYPE.Previous)
                {
                    SelectedIndex--;
                }
                
                if (mCurrentIndex < 0)
                {
                    SelectedIndex = FilteredCollection.Count - 1;
                }
                else if (mCurrentIndex >= FilteredCollection.Count)
                {
                    SelectedIndex = 0;
                }

                //Get the Current Model.
                SongViewModel model = mSongs[SelectedIndex];
                
                //Then fire an event to the listeners to indicate that the Currently selected song has changed.
                if (model != null)
                {
                    SendEvent(model);
                }

            });


            EventAggregator.EventAggregator.Instance.RegisterListener<FileListRetrievedEvent>((fileEvt) =>
            {
                Application.Current.Dispatcher.Invoke((Action)(() =>
                {
                    foreach (Song song in fileEvt.SongCollection)
                    {
                        SongCollection.Add(new SongViewModel(song));
                    }
                    FirePropertyChanged("FilteredCollection");
                }));

                
                
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public String ConverterKey
        {
            get
            {
                return mConverterKey;
            }
            set
            {
                mConverterKey = value;
                FirePropertyChanged("FilteredCollection");
            }
        }


        /// <summary>
        /// Returns the current filter to compare against. 
        /// </summary>
        public IFilterOrganiser<string, string> CurrentFilter
        {
            get
            {
                return mFilter;
            }

            set
            {
                mFilter = value;
                FirePropertyChanged("FilteredCollection");
            }
        }


        /// <summary>
        /// The String we're filtering the songs upon
        /// </summary>
        public string FilteredString
        {
            get
            {
                return mFilterString;
            }
            set
            {
                mFilterString = value;
                FirePropertyChanged("FilteredCollection");
            }
        }

        /// <summary>
        /// The full Song Collection.
        /// </summary>
        public ObservableCollection<SongViewModel> SongCollection
        {
            get { return mSongs; }
        }

        /// <summary>
        /// Dictionary of String Converters
        /// </summary>
        public IDictionary<String, SongConvert> SongConverters
        {
            get
            {
                return mConverters;
            }
        }

        /// <summary>
        /// A collection of String, and Filter Organiser.
        /// </summary>
        public IDictionary<String, IFilterOrganiser<string, string>> SongRankers
        {
            get
            {
                return mFilters;
            }
        }

        public int SelectedIndex
        {
            get
            {
                return mCurrentIndex;
            } 
            set
            {
                mCurrentIndex = value;
                FirePropertyChanged("SelectedIndex");
            }
        }

        /// <summary>
        /// The Filtered Collection based on the Filtered String and Organisers etc.
        /// </summary>
        public ICollection<SongViewModel> FilteredCollection
        {
            get
            {
                if (FilteredString == null || FilteredString.Equals(""))
                {
                    return SongCollection;
                }
                else
                {
                    //first create a lookup table of Key -> Filter Rank. 
                    //This enables us to cull things and rank things without having to rerun the algorithm.
                    Dictionary<SongViewModel, int> songToRank = SongCollection.ToDictionary(k => k, v => CurrentFilter.setFilterRank(mConverters[mConverterKey](v), mFilterString));
                    //Then use the lookup table to elimate any 0-ranked Keys. 
                    List<SongViewModel> retVal = new List<SongViewModel>(SongCollection.Where(key => (songToRank[key] != 0)));

                    // Create a lambda Comparator.
                    Comparison<SongViewModel> comp = (a, b) =>
                    {
                        // Compare by The Comparator rank
                        int res = songToRank[b].CompareTo(songToRank[a]);

                        //If this is the same then compare by artist.
                        if (res == 0)
                        {
                            res = a.ArtistName.CompareTo(b.ArtistName);
                        }

                        return res;
                    };

                    retVal.Sort(comp);

                    //Then set the adjusted index.
                    SelectedIndex = retVal.IndexOf(mSelectedSong);

                    return retVal;
                }
            }
        }

        // Swap out the View
        private void SendEvent(SongViewModel view)
        {
            //First get where this lies in our filtered collection. 
            mSelectedSong = view;
            SelectedIndex = mSongs.IndexOf(view);

            EventAggregator.EventAggregator.Instance.RaiseEvent<SongChangeEvent>(new SongChangeEvent(view.Song));
        }

        // We can swap if our Menu Item Control is not nul.
        private Boolean canSwap(SongViewModel swappable)
        {
            return true;
        }

        // the Command to use to swap out a view model.
        public ICommand SendSongEvent
        {
            get
            {
                return new RelayCommand<SongViewModel>(SendEvent, canSwap);
            }
        }


    }
}
