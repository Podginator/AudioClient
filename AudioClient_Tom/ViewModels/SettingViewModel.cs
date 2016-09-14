using AudioClient_Tom.Models;
using AudioClient_Tom.Networking;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Xml.Serialization;

namespace AudioClient_Tom.ViewModels
{
    // The View Model for the Settings

    public class SettingsViewModel
    {

        // The Serializer.
        XmlSerializer mSerializer;

        String mPath; 


        //The Setting object this model represents.
        Settings mSettings;

        /// <summary>
        /// Constructor
        /// </summary>
        public SettingsViewModel() {
            mSerializer = new XmlSerializer(typeof(Settings));
            mPath = Path.Combine(Environment.CurrentDirectory, "settings.xml");
            mSettings = new Settings();
            if (Load())
            {
                EventAggregator.EventAggregator.Instance.RaiseEvent(
                   new Packet(PacketType.SETTINGS, Marshal.SizeOf(mSettings), Settings.Serialize(mSettings)));
            }
        }

        public String ShareName
        {
            get { return mSettings.ShareName; }
            set { mSettings.ShareName = value; }
        }

        public bool ShareActivity
        {
            get { return mSettings.ShareActivity; }
            set { mSettings.ShareActivity = value; }
        }

        public bool GetAlbumArt
        {
            get { return mSettings.GetAlbumArt; }
            set { mSettings.GetAlbumArt = value; }
        }

        // Save out the Settings.
        private bool Save()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(mPath))
                {
                    mSerializer.Serialize(writer, mSettings);
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Load the Settings saved out in the XML.
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            Settings xmlSettings;
            FileInfo xml = new FileInfo(mPath);

            if (!xml.Exists)
            {
                return false;
            }
            else
            {
                using (Stream s = xml.OpenRead())
                {
                    try
                    {
                        xmlSettings = (Settings)mSerializer.Deserialize(s);
                    }
                    catch (System.Xml.XmlException)
                    {
                        //Invalid XML, return false
                        return false;
                    }
                }
                mSettings = xmlSettings;
            }
            return true;
        }

        /// <summary>
        /// Push A Song Changed event onto the Event Aggregator. 
        /// </summary>
        /// <param name="view">The View model containing the song we want to listetn to.</param>
        private void ApplySettings()
        {
            // Apply the Settings.

            // First, save out the Settings. 
            if (Save())
            {
                // Then send out a packet. 
                EventAggregator.EventAggregator.Instance.RaiseEvent(
                    new Packet(PacketType.SETTINGS, Marshal.SizeOf(mSettings), Settings.Serialize(mSettings)));
            }



        }

        /// <summary>
        /// The event to send the song. Calls to the Event Aggregator.
        /// </summary>
        public ICommand ApplySettingCommand
        {
            get
            {
                return new RelayCommand(ApplySettings, () => { return true; });
            }
        }
    }
}