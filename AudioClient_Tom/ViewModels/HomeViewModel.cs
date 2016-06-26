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
    class HomeViewModel : AbstractObservable
    {

        // The Control that we wish to swap out.
        private Control mControl;

        private List<MenuItemModel> mItems;

        private String mCurrentSelected;

        //Ctor:
        // The collection of Menu Items we wish to use is built
        public HomeViewModel()
        {
            mItems = new List<MenuItemModel>();
            mItems.Add(new MenuItemModel { Name = "Songs", Control = new SongView() });
            mItems.Add(new MenuItemModel { Name = "Playlists", Control = new Button() });
            mItems.Add(new MenuItemModel { Name = "Friends", Control = new Button() });
            mItems.Add(new MenuItemModel { Name = "Most Popular", Control = new Button() });
            swapViewModel(mItems[0]);

            EventAggregator.EventAggregator.Instace.RegisterListener<SongViewModel>(e => {
                CurrentlySelected = e.ArtistName;
            });
        }


        // Used to swap a user control out.
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

        public List<MenuItemModel> MenuItems
        {
            get
            {
                return mItems;
            }
        }


        // Swap out the View
        private void swapViewModel(MenuItemModel view)
        {
            if (view != null && view.Control != null)
            {
                UserControl = view.Control;
                CurrentlySelected = view.Name;
            }
        }

        // We can swap if our Menu Item Control is not nul.
        private Boolean canSwap(MenuItemModel swappable)
        {
            return swappable != null && swappable.Control != null;
        }

        // the Command to use to swap out a view model.
        public ICommand updateViewInModel
        {
            get
            {
                return new RelayCommand<MenuItemModel>(swapViewModel, canSwap);
            }
        }
    }
}
