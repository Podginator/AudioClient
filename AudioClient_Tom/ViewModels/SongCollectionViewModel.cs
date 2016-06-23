using AudioClient_Tom.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AudioClient_Tom.ViewModels
{
    class SongCollectionViewModel : AbstractObservable
    {

        // A collection of songs. 
        private ObservableCollection<SongViewModel> mSongs;

        // The String we'll filter by 
        private string mFilterString;


        // this is the Filter Organizer, by default this will use a fuzzy search. 
        // Thought it can be replaced by something that filters by name only.
        // or filtered by exact matches only. 
        // or contained strings. 
        // It's a very flexible system.
        private IFilterOrganiser<SongViewModel, string> mSorter;


        /// <summary>
        /// Tempory CTOR. Creates a lot of songs. 
        /// </summary>
        public SongCollectionViewModel()
        {
            mSorter = new ContainsFilter();
            mSongs = new ObservableCollection<SongViewModel>();
            mSongs.Add(new SongViewModel { Song = new Models.Song(), SongTitle = "ABC_Song", ArtistName = "Shaft", LengthSeconds = 150 });
            mSongs.Add(new SongViewModel { Song = new Models.Song(), SongTitle = "CDE_Song", ArtistName = "Shaft", LengthSeconds = 150 });
            mSongs.Add(new SongViewModel { Song = new Models.Song(), SongTitle = "FGH_Song", ArtistName = "Shaft", LengthSeconds = 150 });
            mSongs.Add(new SongViewModel { Song = new Models.Song(), SongTitle = "IJK_SONG", ArtistName = "Shaft", LengthSeconds = 150 });
            mSongs.Add(new SongViewModel { Song = new Models.Song(), SongTitle = "LMN_Song", ArtistName = "Shaft", LengthSeconds = 150 });
            mSongs.Add(new SongViewModel { Song = new Models.Song(), SongTitle = "SpaceJam", ArtistName = "Shaft", LengthSeconds = 150 });
        }



        //Get the filter. 
        private string FilteredSongs
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

        // Return the entire collection.
        public ObservableCollection<SongViewModel> SongCollection
        {
            get { return mSongs; }
        }

        // Filter the Collection using are Filter Organizer. 
        public List<SongViewModel> FilteredCollection
        {
            get
            {
                if (FilteredSongs == null || FilteredSongs.Equals(""))
                {
                    return new List<SongViewModel>(SongCollection);
                }
                else
                {
                    //first create a lookup table of Key -> Filter Rank. 
                    //This enables us to cull things and rank things without having to rerun the algorithm.
                    Dictionary<SongViewModel, int> songToRank = SongCollection.ToDictionary(k => k, v => mSorter.setFilterRank(v, mFilterString));
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
                    return retVal;
                }

            }
        }

        // Swap out the View
        private void changeFilter(string filter)
        {
            FilteredSongs = filter;
        }

        //We can always execute this command.
        private Boolean canSwap(string canFilter)
        {
            return true;
        }

        // the Command to use to swap out a Filter
        public ICommand swapFilter
        {
            get
            {
                return new RelayCommand<String>(changeFilter, canSwap);
            }
        }

    }
}
