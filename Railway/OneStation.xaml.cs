using Railway.Model;
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
    /// Interaction logic for OneStation.xaml
    /// </summary>
    public partial class OneStation : Grid
    {
        Station Station;
        Railway.MainWindow Window;
        public OneStation(Railway.MainWindow window, Station station)
        {
            InitializeComponent();
            Window = window;
            Station = station;

            LatitudeLabel.Content = $"Latitude: {station.Latitude}";
            LongitudeLabel.Content = $"Longitude: {station.Longitude}";
            NameLabel.Content = $"Name: {station.Name}";
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Window.MainFrame.Content = new UpdateStation(Window.MainFrame, Station);
        }

        public int getHeight()
        {
            return 120;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show($"Are you sure you want to delete station {Station.Name}?\nThis would mean deleting all of the trainlines in which contain the station.", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Data.deleteStation(Station);
                int ok = (int)MessageBox.Show($"Station {Station.Name} successfully deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Window.ShowReadStations(true);
            }
            else
            {
                MessageBox.Show($"Station {Station.Name} deletion cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
