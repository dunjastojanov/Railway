using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for UpdateStation.xaml
    /// </summary>
    public partial class UpdateStation : Page
    {
        private Vector mouseToMarker;

        private bool dragPin;
        public Pushpin SelectedPushpin { get; set; }
        public Station Station { get; set; }
        public String oldStationName { get; set; }
        public Railway.MainWindow MainWindow;

        public Location lastConfirmedLocation;//ovome dodeljuj poslednju izabranu lokaciju  i moram je postaviti ako ne zeli 
        List<Pushpin> Pushpins { get; set; }
        int PushpinIndex { get; set; }
        public UpdateStation(Railway.MainWindow window, Station station)
        {
            this.DataContext = this;
            oldStationName = station.Name;
            MainWindow = window;
            Station = station.DeepCopy();
            Pushpins = new List<Pushpin>();
            PushpinIndex = 0;
            InitializeComponent();
            Pushpin pushpin = new Pushpin();
            pushpin.Location = Station.Location;
            pushpin.Tag = Station.Name;
            pushpin.MouseDown += Pushpin_MouseDown;
            pushpin.ToolTip = pushpin.Tag;
            Pushpins.Add(pushpin);
            TryDisableUnable();
        }

        private void Pushpin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (station_name.Text == "")
            {
                MessageBox.Show("You have to type station name if you want to change station location.", "Update station confirmation");
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
                SelectedPushpin = sender as Pushpin;
                dragPin = true;
                mouseToMarker = Point.Subtract(mapa.LocationToViewportPoint(SelectedPushpin.Location), e.GetPosition(mapa));
            }
        }

        private void mapa_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (dragPin && SelectedPushpin != null)
                {
                    SelectedPushpin.Location = mapa.ViewportPointToLocation(
                        Point.Add(e.GetPosition(mapa), mouseToMarker));
                    
                    e.Handled = true;
                }
            }
        }

        private void mapa_Drop(object sender, DragEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to update location of the station?", "Update station confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (dragPin && SelectedPushpin != null)
                {

                    lastConfirmedLocation = mapa.ViewportPointToLocation(Point.Add(e.GetPosition(mapa), mouseToMarker));
                    SelectedPushpin.Location = lastConfirmedLocation;            
                    e.Handled = true;
                }
            }
        }

        private void updateStation_Click(object sender, RoutedEventArgs e)
        {
            String pattern = @"^[A-Za-z]+[A-Za-z\s]*$";
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to update chosen station?", "Update station confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (station_name.Text == "")
                {
                    MessageBox.Show("Station name is empty.\nPlease enter station name.", "Update station confirmation");
                }
                else if (!Regex.Match(station_name.Text, pattern).Success)
                {
                    MessageBox.Show($"Name must begin with a letter and can contain only letters and spaces.\n", "Creating new station confirmation");
                }
                else
                {
                    String newName = station_name.Text;
                    bool sameName = false;
                    bool sameLocation = false;
                    var collection=Data.getStations().Where(a=> a.Name!=Station.Name);
                    foreach (Station station1 in collection)
                    {
                        if (station1.Name == newName)
                        {
                            sameName = true;
                        }
                        if (SelectedPushpin!=null && station1.Location.Longitude == SelectedPushpin.Location.Longitude && station1.Location.Latitude == SelectedPushpin.Location.Latitude)
                        {
                            sameLocation = true;
                        }
                    }
                    if (!sameName && !sameLocation)
                    {
                        if (SelectedPushpin == null) { 
                            SelectedPushpin = new Pushpin();
                            SelectedPushpin.Location = new Location(Station.Location.Latitude, Station.Location.Longitude);
                        }
                        SelectedPushpin.ToolTip = newName;
                        SelectedPushpin.Background = new SolidColorBrush(Colors.Blue);
                        Station newStation = new Station(newName, SelectedPushpin.Location.Longitude, SelectedPushpin.Location.Latitude);
                        Data.updateStation(oldStationName, newStation);
                        station_name.Text = "";
                        MessageBox.Show("You have succesfully updated station", "Update station confirmation");
                        MainWindow.ShowReadStations(false);
                    }
                    else if (!sameName)
                    {
                        MessageBox.Show("You have to set new name for this station, because it already exists", "Update station confirmation");
                    }
                    else if (!sameLocation)
                    {
                        MessageBox.Show("You have to set new location for this station, because it already exists", "Update station confirmation");
                    }
                }
            }
        }

        private void mapa_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (SelectedPushpin == null) {
                return;
            }
            MessageBoxResult messageBoxResult1 = MessageBox.Show("Are you sure you want to update location of the station?", "Update station confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult1 == MessageBoxResult.No)
            {
                SelectedPushpin.Location = Station.Location;
            }
            else
            {
                if (PushpinIndex != Pushpins.Count - 1)
                    Pushpins.RemoveRange(PushpinIndex + 1, Pushpins.Count - 1 - PushpinIndex);
                Pushpin pushpin = new Pushpin();
                pushpin.Location = SelectedPushpin.Location;
                SelectedPushpin.Tag = station_name.Text;
                SelectedPushpin.ToolTip = station_name.Text;
                pushpin.Tag = station_name.Text;
                pushpin.MouseDown += Pushpin_MouseDown;
                pushpin.ToolTip = pushpin.Tag;
                Pushpins.Add(pushpin);
                PushpinIndex++;
                TryDisableUnable();
                e.Handled = true;
            }
        }

        private void SetPushpin()
        {
            if (PushpinIndex > -1)
            {
                Pushpin p = Pushpins[PushpinIndex];
                mapa.Children.Remove(selectedPushpin);
                selectedPushpin.Location = p.Location;
                selectedPushpin.Tag = p.Tag;
                selectedPushpin.ToolTip = p.ToolTip;
                mapa.Children.Add(selectedPushpin);
                station_name.Text = (String)selectedPushpin.Tag;
            }
            else
            {
                mapa.Children.Remove(selectedPushpin);
                station_name.Text = "";
            }
        }
        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            PushpinIndex--;
            SetPushpin();
            TryDisableUnable();
        }
        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {
            PushpinIndex++;
            SetPushpin();
            TryDisableUnable();
        }
        private void TryDisableUnable()
        {
            if (PushpinIndex < 1 || Pushpins.Count <= 1)
                undoUpdateStation.IsEnabled = false;
            else
                undoUpdateStation.IsEnabled = true;
            if (PushpinIndex == Pushpins.Count - 1)
                redoUpdateStation.IsEnabled = false;
            else
                redoUpdateStation.IsEnabled = true;

        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpProvider.ShowHelp("EditStation", MainWindow);
        }
    }
}
