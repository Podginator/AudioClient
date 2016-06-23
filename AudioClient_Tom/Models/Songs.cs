using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.Models
{
    public class Song
    {
        string mArtistName;
        string mSongTitle;
        int mSongLength;

        /// <summary>
        /// The artist name.
        /// </summary>
        public string ArtistName
        {
            get { return mArtistName; }
            set { mArtistName = value; }
        }

        /// <summary>
        /// The song title.
        /// </summary>
        public string SongTitle
        {
            get { return mSongTitle; }
            set { mSongTitle = value; }
        }

        /// <summary>
        /// The song Length.
        /// </summary>
        public int SongLength
        {
            get { return mSongLength; }
            set { mSongLength = value; }
        }
    }
}
