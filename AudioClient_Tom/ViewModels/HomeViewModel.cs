using AudioClient_Tom.Models;
using AudioClient_Tom.Networking;
using AudioClient_Tom.Networking.Handlers;
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
    class HomeViewModel : AbstractObservable
    {

        // The Control that we wish to swap out.
        private Control mControl;

        // List of Menu Items
        private List<MenuItemModel> mItems;

        // The currently selected model.
        private String mCurrentSelected;

        //Ctor:
        // The collection of Menu Items we wish to use is built
        public HomeViewModel()
        {

            IServer manager = new SocketManager();
            manager.Connect("localhost", 29054);
            FileListHandler listHander = new FileListHandler();
            IncomingAudioHandler audioHandler = new IncomingAudioHandler();

            manager.OnMessageIncoming += listHander.HandleMessageReceived;
            manager.OnMessageIncoming += audioHandler.HandleMessageReceived;


            EventAggregator.EventAggregator.Instance.RegisterListener<Packet>((packet) => {
                
                // Initially wait until we're connected.
                while (!manager.isConnected()) { }

                //Then, if we are, send the packet.
                manager.Send(Packet.Serialize(packet));
            });



            mItems = new List<MenuItemModel>();
            mItems.Add(new MenuItemModel { Name = "Songs", Control = new SongView() });
            mItems.Add(new MenuItemModel { Name = "Playlists", Control = new Button() });
            mItems.Add(new MenuItemModel { Name = "Friends", Control = new Button() });
            mItems.Add(new MenuItemModel { Name = "Most Popular", Control = new Button() });
            swapViewModel(mItems[0]);
        }


        /// <summary>
        /// Used to swap a usercontrol in and out.
        /// </summary>
        public Control UserControl {
            get
            {
                return mControl;
            }
            set
            {
                if (mControl != value)
                {
                    mControl = value;
                    FirePropertyChanged("UserControl");
                }
            }
        }  

        /// <summary>
        /// The String reference to the currently selected View. 
        /// </summary>
        public String CurrentlySelected
        {
            get
            {
                return mCurrentSelected;
            }
            set
            {
                if (mCurrentSelected != value)
                {
                    mCurrentSelected = value;
                    FirePropertyChanged("CurrentlySelected");
                }
            }
        }

        /// <summary>
        /// A list of Menu Items.
        /// </summary>
        public List<MenuItemModel> MenuItems
        {
            get
            {
                return mItems;
            }
        }


        /// <summary>
        /// swap the View Model
        /// </summary>
        /// <param name="view">The View Model we want to swap.</param>
        // Swap out the View
        private void swapViewModel(MenuItemModel view)
        {
            if (view != null && view.Control != null)
            {
                UserControl = view.Control;
                CurrentlySelected = view.Name;
            }
        }

        /// <summary>
        /// IS the View Model swappable
        /// </summary>
        /// <param name="swappable">The Menu Item we want to swap with</param>
        /// <returns></returns>
        private Boolean canSwap(MenuItemModel swappable)
        {
            return swappable != null && swappable.Control != null;
        }

        /// <summary>
        /// The command to swap out the view model.
        /// </summary>
        public ICommand updateViewInModel
        {
            get
            {
                return new RelayCommand<MenuItemModel>(swapViewModel, canSwap);
            }
        }
    }
}
