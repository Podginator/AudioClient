using AudioClient_Tom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.ViewModels
{
    // The View Model for an individual song. 
    // Simple, does not listen. Just a way to display songs. 
    public class SongViewModel
    {
        //The song object this model represents.
        Song mSong;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="song">Construct the View Model from the song</param>
        public SongViewModel(Song song)
        {
            Song = song;
        }

        /// <summary>
        /// Returns the string object
        /// </summary>
        public Song Song
        {
            get
            {
                return mSong;
            }
            set
            {
                mSong = value;
            }
        }

        /// <summary>
        /// Returns the Artist name
        /// </summary>
        public string ArtistName
        {
            get { return Song.ArtistName; }
            set { Song.ArtistName = value; }
        }

        /// <summary>
        /// Returns the length in seconds
        /// </summary>
        public int LengthSeconds
        {
            get
            {
                return mSong.SongLength;
            }

            set
            {
                mSong.SongLength = value;
            }
        }

        /// <summary>
        /// Returns the Length in a Minute/Second format. 
        /// </summary>
        public string Length
        {
            get
            {
                TimeSpan seconds = TimeSpan.FromSeconds(LengthSeconds);
                return seconds.ToString(@"mm\:ss");
            }
        }

        /// <summary>
        /// Returns the Songs Title
        /// </summary>
        public string SongTitle
        {
            get { return Song.SongTitle; }
            set { Song.SongTitle = value; }
        }
    }
}
