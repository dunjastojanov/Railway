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
        private Railway.MainWindow Window { get; set; }
        public AddingStation(Railway.MainWindow window)
        {
            this.DataContext = this;
            Stations = Data.getStations();
            Window = window;
            InitializeComponent();
            foreach (var item in Data.getStations())
            {
                Location location = new Location(item.Latitude, item.Longitude);
                Pushpin pushpin = new Pushpin();
                pushpin.Location = location;
                pushpin.ToolTip = item.Name;
                mapa.Children.Add(pushpin);
            }
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
                    Point mousePosition = e.GetPosition(this.mapa);
                    Location pinLocation = mapa.ViewportPointToLocation(mousePosition);
                    MessageBox.Show("Latitude: " + pinLocation.Latitude + "\nLongitude: " + pinLocation.Longitude, "Geographic position of the place you wnat to add station to", MessageBoxButton.OK);
                    Pushpin pin = new Pushpin();
                    pin.Background = new SolidColorBrush(Colors.Blue);
                    pin.Location = pinLocation;
                    lastPushpin = pin;
                    mapa.Children.Add(lastPushpin);
                }
                e.Handled = true;
            }
        }

        private void addStation_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to add a new station?", "Creating new station confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (station_name.Text == "")
                {
                    MessageBox.Show("Station name is empty.\nPlease enter station name.", "Creating new station confirmation");
                } else if (lastPushpin==null) {
                    MessageBox.Show("You didn't choose location.\nPlease drag the pin to map.", "Creating new station confirmation");
                }
                else
                {
                    bool sameName = false;
                    bool sameLocation = false;
                    foreach (Station station1 in Stations)
                    {
                        if (station1.Name == station_name.Text) {
                            sameName = true;
                        }
                        if (station1.Location.Longitude == lastPushpin.Location.Longitude && station1.Location.Latitude == lastPushpin.Location.Latitude) {
                            sameLocation = true;
                        }

                    }
                    if (!sameName && !sameLocation)
                    {
                        Station station = new Station(station_name.Text, lastPushpin.Location.Longitude, lastPushpin.Location.Latitude);
                        Data.addNewStation(station);
                        lastPushpin = null;
                        station_name.Text = "";
                        MessageBox.Show("You have succesfully added new station", "Creating new station confirmation");
                        Window.ShowReadStations(true);
                    }
                    else if (!sameName)
                    {
                        MessageBox.Show("You have to name your station diffrently", "Creating new station confirmation");
                    }
                    else if (!sameLocation) {
                        MessageBox.Show("You have to set new location for this station, because it already exists", "Creating new station confirmation");
                    }
                }
            }
        }
    }
}
