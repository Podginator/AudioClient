using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AudioClient_Tom.Views
{
    /// <summary>
    /// Interaction logic for SongView.xaml
    /// </summary>
    public partial class SongView : UserControl
    {
        public SongView()
        {
            InitializeComponent();
        }

        // Do I do this in the code behind because it's UI related? 
        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SongTitleHeader.Width = 0.45 * (SongItems.ActualWidth - (SongItems.Margin.Left + SongItems.Margin.Right));
            ArtistTitleHeader.Width = 0.35 * (SongItems.ActualWidth - (SongItems.Margin.Left + SongItems.Margin.Right));
            LengthHeader.Width = 0.20 * (SongItems.ActualWidth - (SongItems.Margin.Left + SongItems.Margin.Right));

        }
    }
}
