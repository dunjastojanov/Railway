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
    /// Interaction logic for UpdateStationTutorial.xaml
    /// </summary>
    public partial class UpdateStationTutorial : Page
    {
        private Vector mouseToMarker;

        private bool dragPin;
        public Pushpin SelectedPushpin { get; set; }
        public Station Station { get; set; }
        public String oldStationName { get; set; }
        public Railway.MainWindow MainWindow;

        public Location lastConfirmedLocation; 
        List<Pushpin> Pushpins { get; set; }
        int PushpinIndex { get; set; }
        public string Step { get; set; }

        public TutorialHomePage TutorialHomePage;
        public int textChange { get; set; }
        public UpdateStationTutorial(TutorialHomePage tutorialHomePage, Railway.MainWindow window, String stepReadStation ,Station station)
        {
            textChange = 1;
            this.DataContext = this;
            TutorialHomePage = tutorialHomePage;
            oldStationName = station.Name;
            MainWindow = window;
            Station = station;
            Pushpins = new List<Pushpin>();
            PushpinIndex = 0;
            Pushpin pushpin = new Pushpin();
            pushpin.Location = Station.Location;
            pushpin.Tag = Station.Name;
            pushpin.MouseDown += Pushpin_MouseDown;
            pushpin.ToolTip = pushpin.Tag;
            Pushpins.Add(pushpin);
            Step = "step1";
            InitializeComponent();
            textChange++;
            DoStep();
        }
        public void DoStep() {
            switch (Step) {
                case "step1":
                    updateStep1Async();
                    break;
                case "step2":
                    updateStep2();
                    break;
                case "step3":
                    updateStep3();
                    break;
                case "step4":
                    updateStep4();
                    break;
                case "step5":
                    updateStep5();
                    break;
            }
        }
        public async Task updateStep1Async() {

            await Task.Delay(600);
            station_name.Focus();
            station_name.SelectAll();
            MessageBox.Show("Type in the blank space to change station name.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBox.Show("Station name must have minimum 6 characters", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            undoUpdateStation.IsEnabled = false;
            redoUpdateStation.IsEnabled = false;
            mapa.IsEnabled = false;
            updateStation.IsEnabled = false;
        }

        public void updateStep2()
        {
            MessageBox.Show("Move pin on the map to change station location.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            undoUpdateStation.IsEnabled = false;
            redoUpdateStation.IsEnabled = false;
            mapa.IsEnabled = true;
            updateStation.IsEnabled = false;
            station_name.IsEnabled = false;

        }

        public void updateStep3()
        {
            MessageBox.Show("Press undo button to revert to last changes.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            undoUpdateStation.IsEnabled = true;
            redoUpdateStation.IsEnabled = false;
            mapa.IsEnabled = false;
            station_name.IsEnabled = false;
            updateStation.IsEnabled = false;
        }

        public void updateStep4()
        {
            MessageBox.Show("Press redo button to reset station location to previously set location.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            undoUpdateStation.IsEnabled = false;
            redoUpdateStation.IsEnabled = true;
            mapa.IsEnabled = false;
            station_name.IsEnabled = false;
            updateStation.IsEnabled = false;
        }

        public void updateStep5()
        {
            MessageBox.Show("Press update station to update all the changes.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            undoUpdateStation.IsEnabled = false;
            redoUpdateStation.IsEnabled = false;
            mapa.IsEnabled = false;
            station_name.IsEnabled = false;
            updateStation.IsEnabled = true;
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
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to update chosen station?", "Update station confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (station_name.Text == "")
                {
                    MessageBox.Show("Station name is empty.\nPlease enter station name.", "Update station confirmation");
                }
                else
                {
                    String newName = station_name.Text;
                    bool sameName = false;
                    bool sameLocation = false;
                    var collection = Data.getStations().Where(a => a.Name != Station.Name);
                    foreach (Station station1 in collection)
                    {
                        if (station1.Name == newName)
                        {
                            sameName = true;
                        }
                        if (SelectedPushpin != null && station1.Location.Longitude == SelectedPushpin.Location.Longitude && station1.Location.Latitude == SelectedPushpin.Location.Latitude)
                        {
                            sameLocation = true;
                        }
                    }
                    if (!sameName && !sameLocation)
                    {
                        if (SelectedPushpin == null)
                        {
                            SelectedPushpin = new Pushpin();
                            SelectedPushpin.Location = new Location(Station.Location.Latitude, Station.Location.Longitude);
                        }
                        SelectedPushpin.ToolTip = newName;
                        SelectedPushpin.Background = new SolidColorBrush(Colors.Blue);
                        Station newStation = new Station(newName, SelectedPushpin.Location.Longitude, SelectedPushpin.Location.Latitude);
                        Data.updateStation(oldStationName, newStation);
                        station_name.Text = "";
                        MessageBox.Show("You have succesfully updated station", "Update station confirmation");
                        TutorialHomePage.tutorialFrame.Content= new ReadStationTutorial(TutorialHomePage,MainWindow,"step6")
;                    }
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
                SelectedPushpin.Tag = station_name.Text;//treba da se stavi tag 
                SelectedPushpin.ToolTip = station_name.Text;
                pushpin.Tag = station_name.Text;
                pushpin.MouseDown += Pushpin_MouseDown;
                pushpin.ToolTip = pushpin.Name;
                Pushpins.Add(pushpin);
                PushpinIndex++;
                e.Handled = true;
                Step = "step3";
                DoStep();
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
            Step = "step4";
            DoStep();
        }
        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {
            PushpinIndex++;
            SetPushpin();
            Step = "step5";
            DoStep();
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpProvider.ShowHelp("EditStation", MainWindow);
        }

        private void station_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (station_name.Text.Length > 5  && textChange%2==0)
            {
                Step = "step2";
                DoStep();
                textChange++;
            }
        }
    }
}
