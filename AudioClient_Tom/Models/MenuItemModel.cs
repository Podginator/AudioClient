using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AudioClient_Tom.Models
{
    class MenuItemModel
    {

        //The Name of the Menu Item.
        public String Name
        {
            get; set;
        }

        //The Image Icon of this menu item.
        public Image ImageIcon
        {
            get;
            set;
        }


        //The Associated control of the Menu Item.
        public Control Control
        {
            get; set; 
        } 

    }
}
