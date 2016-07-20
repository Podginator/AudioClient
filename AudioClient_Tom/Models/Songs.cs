using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.Models
{

    [StructLayout(LayoutKind.Sequential)]
    public class Song
    {

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        string mSongTitle;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        string mArtistName;

        Int32 mSongLength;


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
