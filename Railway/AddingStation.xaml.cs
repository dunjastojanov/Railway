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
using Microsoft.Maps.MapControl.WPF;
using Railway.Model;

namespace Railway
{
    /// <summary>
    /// Interaction logic for AddingStation.xaml
    /// </summary>
    public partial class AddingStation : Page
    {
        public List<Station> Stations { get; set; }

        private Pushpin lastPushpin;

        public AddingStation(Frame mainFrame)
        {
            this.DataContext = this;
            Data.FillData();
            Stations = Data.getStations();
            InitializeComponent();
        }

        private void Ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                string stationName = station_name.Text;
                if (stationName == "" || stationName == null)
                {
                    MessageBox.Show("You need to type station name in order to place icon on map.", "Notification", MessageBoxButton.OK);
                }
                else
                {
                    DragDrop.DoDragDrop(LocationPoint, LocationPoint, DragDropEffects.Move);
                }
            }
        }

        private void Map_Loaded(object sender, RoutedEventArgs e)
        {
            Data.FillData();
            Location location = null;
            foreach (var item in Data.getStations())
            {
                location = new Location(item.Latitude, item.Longitude);
                Pushpin pushpin = new Pushpin();
                pushpin.Location = location;
                mapa.Children.Add(pushpin);
            }
        }

        private void mapa_Drop(object sender, DragEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to place the station here?", "Creating new station confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (mapa.Children.Contains(lastPushpin))
                {
                    messageBoxResult = MessageBox.Show("Last mark for the station on the map will be delete.\nAre you sure you want to add new mark?", "Changing mark for new location confirmation", MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        mapa.Children.Remove(lastPushpin);
                        e.Handled = true;
                        Point mousePosition = e.GetPosition(this.mapa);
                        Location pinLocation = mapa.ViewportPointToLocation(mousePosition);
                        MessageBox.Show("Latitude: " + pinLocation.Latitude + "\nLongitude: " + pinLocation.Longitude, "Geographic position of the place you want to add station to", MessageBoxButton.OK);
                        Pushpin pin = new Pushpin();
                        pin.Background = new SolidColorBrush(Colors.Blue);
                        pin.Location = pinLocation;
                        lastPushpin = pin;
                        mapa.Children.Add(lastPushpin);
                    }
                }
                else if (lastPushpin == null) {
                    e.Handled = true;
                    Point mousePosition = e.GetPosition(this.mapa);
                    Location pinLocation = mapa.ViewportPointToLocation(mousePosition);
                    MessageBox.Show("Latitude: " + pinLocation.Latitude + "\nLongitude: " + pinLocation.Longitude, "Geographic position of the place you wnat to add station to", MessageBoxButton.OK);
                    Pushpin pin = new Pushpin();
                    pin.Background = new SolidColorBrush(Colors.Blue);
                    pin.Location = pinLocation;
                    lastPushpin = pin;
                    mapa.Children.Add(lastPushpin);
                }
            }
        }

        private void addStation_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to add a new station?", "Creating new station confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                
                Station station = new Station(station_name.Text, lastPushpin.Location.Longitude, lastPushpin.Location.Latitude);
                Stations.Add(station);
                Data.getStations().Add(station);
                lastPushpin = null;
                station_name.Text = "";
            }
        }
    }
}
