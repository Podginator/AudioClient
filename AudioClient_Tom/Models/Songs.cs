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

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        string mSongTitle;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
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


        public static Song Deserialize(byte[] songArray)
        {
            Song res = null;
            var handle = GCHandle.Alloc(songArray, GCHandleType.Pinned);
            var structure = Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Song));
            if (structure is Song)
            {
                res = (Song)structure;
            }
            handle.Free();

            return res;
        }  
    }
}
