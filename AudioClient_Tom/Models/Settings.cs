using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AudioClient_Tom.Models
{
    // Small class to represent settings.
    [StructLayout(LayoutKind.Sequential)]
    public class Settings
    {
        // Constructor
        public Settings() { }

        // The name we are sharing as. This will be set once and saved out. 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        String mShareName;

        // Share (Publish) The Activity 
        [MarshalAs(UnmanagedType.U1)]
        bool mShareActivity;

        // Should we also request album art?
        [MarshalAs(UnmanagedType.U1)]
        bool mAlbumnArt;


        public String ShareName
        {
            get { return mShareName; }
            set { mShareName = value; }
        }

        public bool ShareActivity
        {
            get { return mShareActivity; }
            set { mShareActivity = value; }
        }

        public bool GetAlbumArt
        {
            get { return mAlbumnArt; }
            set { mAlbumnArt = value; }
        }

        public static byte[] Serialize(Settings settings)
        {
            int rawsize = Marshal.SizeOf(settings);
            byte[] rawdatas = new byte[rawsize];
            GCHandle handle = GCHandle.Alloc(rawdatas, GCHandleType.Pinned);

            IntPtr buffer = handle.AddrOfPinnedObject();
            Marshal.StructureToPtr(settings, buffer, false);
            handle.Free();

            return rawdatas;
        }

    }
}
