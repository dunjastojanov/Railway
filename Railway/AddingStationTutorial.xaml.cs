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
    /// Interaction logic for AddingStationTutorial.xaml
    /// </summary>
    public partial class AddingStationTutorial : Page
    {
        public List<Station> Stations { get; set; }

        private Pushpin lastPushpin;
        List<Pushpin> Pushpins { get; set; }
        int PushpinIndex { get; set; }
        private Railway.MainWindow Window { get; set; }
        public string Step { get; set; }
        public string ReadStationStep { get; set; }
        public TutorialHomePage TutorialHomePage { get; set; }
        public bool wasHere { get; set; }
        public AddingStationTutorial(TutorialHomePage tutorialHomePage, Railway.MainWindow window, String stepReadStation)
        {
            wasHere = true;
            TutorialHomePage = tutorialHomePage;
            this.DataContext = this;
            this.Window = window;
            ReadStationStep = stepReadStation;
            Data.FillData();
            Stations = Data.getStations();
            Pushpins = new List<Pushpin>();
            PushpinIndex = -1;
            InitializeComponent();
            foreach (var item in Data.getStations())
            {
                Location location = new Location(item.Latitude, item.Longitude);
                Pushpin pushpin = new Pushpin();
                pushpin.Location = location;
                pushpin.ToolTip = item.Name;
                mapa.Children.Add(pushpin);
            }
            Step = "step1";
            undoAddStation.IsEnabled = false;
            redoAddStation.IsEnabled = false;
            mapa.IsEnabled = false;
            DoStep();

        }
        public void DoStep()
        {
            switch (Step)
            {
                case "step1":
                    Step1();
                    break;
                case "step2":
                    Step2();
                    break;
                case "step3":
                    Step3();
                    break;
                case "step4":
                    Step4();
                    break;
                case "step5":
                    Step5();
                    break;

            }
        }
        public async Task Step1()
        {
            await Task.Delay(600);
            undoAddStation.IsEnabled = false;
            redoAddStation.IsEnabled = false;
            mapa.IsEnabled = false;
            addStation_BTN.IsEnabled = false;
            station_name.Focus();
            MessageBox.Show("Type into blank space to set station name.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBox.Show("Station name must have minimum 6 characters", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void Step2()
        {
            MessageBox.Show("Move pin on the map to change station location.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            undoAddStation.IsEnabled = false;
            redoAddStation.IsEnabled = false;
            mapa.IsEnabled = true;
            addStation_BTN.IsEnabled = false;
            station_name.IsEnabled = false;
            
        }

        public void Step3()
        {
            MessageBox.Show("Press undo button to revert to last set station location.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            undoAddStation.IsEnabled = true;
            redoAddStation.IsEnabled = false;
            mapa.IsEnabled = false;
            station_name.IsEnabled = false;
            addStation_BTN.IsEnabled = false;
        }

        public void Step4()
        {
            MessageBox.Show("Press redo button to reset station location to previously set location.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            undoAddStation.IsEnabled = false;
            redoAddStation.IsEnabled = true;
            mapa.IsEnabled = false;
            station_name.IsEnabled = false;
            addStation_BTN.IsEnabled = false;
        }

        public void Step5()
        {
            MessageBox.Show("Press add station to add the station.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            undoAddStation.IsEnabled = false;
            redoAddStation.IsEnabled = false;
            mapa.IsEnabled = false;
            station_name.IsEnabled = false;
            addStation_BTN.IsEnabled = true;
            
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
                        Point mousePosition = e.GetPosition(this.mapa);
                        Location pinLocation = mapa.ViewportPointToLocation(mousePosition);
                        MessageBox.Show("Latitude: " + pinLocation.Latitude + "\nLongitude: " + pinLocation.Longitude, "Geographic position of the place you want to add station to", MessageBoxButton.OK);
                        Pushpin pin = new Pushpin();
                        pin.Background = new SolidColorBrush(Colors.Blue);
                        pin.Location = pinLocation;
                        pin.Tag= station_name.Text;
                        lastPushpin = pin;
                        mapa.Children.Add(lastPushpin);
                        Pushpins.Add(lastPushpin);
                        PushpinIndex++;
                    }
                }
                else if (lastPushpin == null)
                {
                    Point mousePosition = e.GetPosition(this.mapa);
                    Location pinLocation = mapa.ViewportPointToLocation(mousePosition);
                    MessageBox.Show("Latitude: " + pinLocation.Latitude + "\nLongitude: " + pinLocation.Longitude, "Geographic position of the place you wnat to add station to", MessageBoxButton.OK);
                    Pushpin pin = new Pushpin();
                    pin.Background = new SolidColorBrush(Colors.Blue);
                    pin.Location = pinLocation;
                    pin.Tag= station_name.Text;
                    lastPushpin = pin;
                    mapa.Children.Add(lastPushpin);
                    Pushpins.Add(lastPushpin);
                    PushpinIndex++;
                }
                else
                {
                    Point mousePosition = e.GetPosition(this.mapa);
                    Location pinLocation = mapa.ViewportPointToLocation(mousePosition);
                    MessageBox.Show("Latitude: " + pinLocation.Latitude + "\nLongitude: " + pinLocation.Longitude, "Geographic position of the place you wnat to add station to", MessageBoxButton.OK);
                    Pushpin pin = new Pushpin();
                    pin.Background = new SolidColorBrush(Colors.Blue);
                    pin.Location = pinLocation;
                    pin.Tag = station_name.Text;
                    lastPushpin = pin;
                    mapa.Children.Add(lastPushpin);
                    Pushpins.Add(lastPushpin);
                    PushpinIndex++;
                }
                e.Handled = true;
                Step = "step3";
                DoStep();
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
                }
                else if (lastPushpin == null)
                {
                    MessageBox.Show("You didn't choose location.\nPlease drag the pin to map.", "Creating new station confirmation");
                }
                else
                {
                    bool sameName = false;
                    bool sameLocation = false;
                    foreach (Station station1 in Stations)
                    {
                        if (station1.Name == station_name.Text)
                        {
                            sameName = true;
                        }
                        if (station1.Location.Longitude == lastPushpin.Location.Longitude && station1.Location.Latitude == lastPushpin.Location.Latitude)
                        {
                            sameLocation = true;
                        }

                    }
                    if (!sameName && !sameLocation)
                    {
                        Station station = new Station(station_name.Text, lastPushpin.Location.Longitude, lastPushpin.Location.Latitude);
                        Data.addNewStationTutorial(station);
                        lastPushpin = null;
                        station_name.Text = "";
                        MessageBox.Show("You have succesfully added new station", "Creating new station confirmation");
                        TutorialHomePage.tutorialFrame.Content = new ReadStationTutorial(TutorialHomePage, Window, "step5");
                    }
                    else if (!sameName)
                    {
                        MessageBox.Show("You have to name your station diffrently", "Creating new station confirmation");
                    }
                    else if (!sameLocation)
                    {
                        MessageBox.Show("You have to set new location for this station, because it already exists", "Creating new station confirmation");
                    }
                }
            }

        }

        private void setPushpin()
        {
            if (PushpinIndex > -1)
            {
                Pushpin p = Pushpins[PushpinIndex];
                mapa.Children.Remove(lastPushpin);
                mapa.Children.Add(p);
                lastPushpin = p;
                station_name.Text = (String)p.Tag;
            }
            else
            {
                mapa.Children.Remove(lastPushpin);
                station_name.Text = "";
            }
        }
        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            PushpinIndex--;
            setPushpin();
            Step = "step4";
            DoStep();
        }
        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {
            PushpinIndex++;
            setPushpin();
            
            Step = "step5"; 
            DoStep();
        }
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpProvider.ShowHelp("AddStation", Window);
        }

        private void station_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (station_name.Text.Length > 5 && wasHere)
            {
                wasHere = false;
                Step = "step2";
                DoStep();
            }
        }
    }
}
