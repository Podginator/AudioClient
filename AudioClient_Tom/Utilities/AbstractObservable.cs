using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.Utilities
{
    // An Abstract class for objects that are observable. 
    class AbstractObservable : INotifyPropertyChanged
    {
        // The event to fire when property is changed.
        public event PropertyChangedEventHandler PropertyChanged;

        //Create an event for when a PRoperty has changed.
        protected virtual void FirePropertyChanged(String propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        //Handle Property Changed Event.
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
