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

namespace Railway
{
    /// <summary>
    /// Interaction logic for ReadStations.xaml
    /// </summary>
    public partial class ReadStations : Page
    {
        private Railway.MainWindow Window;
        public ReadStations(Railway.MainWindow window)
        {
            InitializeComponent();
            Window = window;

        }

        private void AddNewStation_Click(object sender, RoutedEventArgs e)
        {
            Window.MainFrame.Content = new AddingStation(Window.MainFrame);
        }

        internal void RefreshPage()
        {
            
        }
    }
}
