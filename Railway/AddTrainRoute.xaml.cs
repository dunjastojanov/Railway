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
    /// Interaction logic for AddTrainRoute.xaml
    /// </summary>
    public partial class AddTrainRoute : Page
    {
        Trainline trainline = null;
        int lastStationLabelRow;
        List<Dictionary<String, object>> infoBetweenStations;
        List<String> addedStations;
        List<String> removedStations;
        List<String> addedStationsEditing;
        int maxSteps;
        int maxStepsEditing;

        Railway.MainWindow Window;

        public AddTrainRoute(Railway.MainWindow window)
        {
            this.Window = window;
            InitializeComponent();
            maxSteps = 0;
            maxStepsEditing = 0;

            infoBetweenStations = new List<Dictionary<string, object>>();
            addedStations = new List<String>();
            removedStations = new List<String>();

            lastStationLabelRow = -1;


            foreach (string stationName in Data.GetStationNames())
            {
                StationComboBox.Items.Add(stationName);

            }
            TryDisableUndoRedo();

        }

        public AddTrainRoute(Railway.MainWindow window, Trainline trainline)
        {
            this.Window = window;
            InitializeComponent();


            this.trainline = trainline;

            maxSteps = 0;

            infoBetweenStations = new List<Dictionary<string, object>>();
            addedStations = new List<String>();
            addedStationsEditing = new List<String>();
            removedStations = new List<String>();
            lastStationLabelRow = -1;


            foreach (string stationName in Data.GetStationNames())
            {
                StationComboBox.Items.Add(stationName);

            }

            AddContentForEditing();
            maxStepsEditing = addedStationsEditing.Count;
            TryDisableUndoRedo();
        }

        private void AddContentForEditing()
        {
            Station station = trainline.FirstStation;
            Model.Path path;


            while (station.PathToNextStation != null)
            {
                AddedStationsInfoGrid.Height = AddedStationsInfoGrid.Height + 30 + 90;
                path = station.PathToNextStation;

                addedStations.Add(station.Name);
                addedStationsEditing.Add(station.Name);
                addRowPixels(AddedStationsInfoGrid, 90);

                if (lastStationLabelRow > -1)
                {
                    addBetweenStationInfoGrid(path.Price, path.Duration);
                }

                addRowPixels(AddedStationsInfoGrid, 30);
                addStationLabel(station.Name);

                lastStationLabelRow += 2;

                station = path.NextStation;


            }

            station = trainline.LastStation;

            AddedStationsInfoGrid.Height = AddedStationsInfoGrid.Height + 30 + 90;
            path = station.PathToPreviousStation;

            addedStations.Add(station.Name);
            addedStationsEditing.Add(station.Name);
            addRowPixels(AddedStationsInfoGrid, 90);

            if (lastStationLabelRow > -1)
            {
                addBetweenStationInfoGrid(path.Price, path.Duration);
            }

            addStationLabel(station.Name);

            lastStationLabelRow += 2;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (addedStations.Count > 0)
            {

                if (StationComboBox.SelectedItem.ToString() == addedStations[addedStations.Count-1])
                {
                    MessageBox.Show("You cannot add the same station two times in a row.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {                  
                    fillInfo();
                    RedoAddTrainRoute.IsEnabled = false;
                }
            }
            else
            {
                fillInfo();
                RedoAddTrainRoute.IsEnabled = false;

            }

        }

        private void AddContentForAdding()
        {
            string lastStation = "";
            AddedStationsInfoGrid.Children.Clear();
            lastStationLabelRow = -1;
            foreach (String station in addedStations)
            {
                addRowPixels(AddedStationsInfoGrid, 90);

                if (lastStationLabelRow > -1)
                {
                    addBetweenStationInfoGrid(lastStation, station);
                }
                addStationLabel(station);
                addRowPixels(AddedStationsInfoGrid, 30);
                lastStation = station;

                lastStationLabelRow += 2;
            }
        }
        private void fillInfo()
        {
            AddedStationsInfoGrid.Height = AddedStationsInfoGrid.Height + 30 + 90;

            if (StationComboBox.SelectedItem != null)
            {
                string parameter = StationComboBox.SelectedItem.ToString();
                int response = (int)MessageBox.Show("Are you sure you want to add station " + parameter + "?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (response == 6)
                {
                    maxSteps++;
                    maxStepsEditing++;
                    addedStations.Add(StationComboBox.SelectedItem.ToString());
                    RefreshPage();
                }
                else
                {
                    MessageBox.Show("Adding station to the train route cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            else
            {
                MessageBox.Show("Station must be chosen before clicking ADD button.", "Station not found.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void addBetweenStationInfoGrid(int price, int duration)
        {
            Grid grid = new Grid();
            addColumnStars(grid, 2);
            addColumnStars(grid, 4);
            addColumnStars(grid, 3);
            addColumnStars(grid, 3);
            addRowStars(grid, 1);
            addRowStars(grid, 2);
            addRowStars(grid, 2);
            addRowStars(grid, 1);

            Label durationLabel = new Label();
            durationLabel.Content = "Trip duration (minutes):";
            durationLabel.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetRow(durationLabel, 1);
            Grid.SetColumn(durationLabel, 1);
            grid.Children.Add(durationLabel);

            TextBox durationTextBox = new TextBox();
            durationTextBox.Text = duration.ToString();
            Grid.SetRow(durationTextBox, 1);
            Grid.SetColumn(durationTextBox, 2);
            durationTextBox.ToolTip = "Duration of the trip beetwen the stations above and below.";
            grid.Children.Add(durationTextBox);

            Label priceLabel = new Label();
            priceLabel.Content = "Price (rsd):";
            priceLabel.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetRow(priceLabel, 2);
            Grid.SetColumn(priceLabel, 1);
            grid.Children.Add(priceLabel);

            TextBox priceTextBox = new TextBox();
            priceTextBox.Text = price.ToString();
            Grid.SetRow(priceTextBox, 2);
            Grid.SetColumn(priceTextBox, 2);
            priceTextBox.ToolTip = "Price for the trip between the stations above and below.";
            grid.Children.Add(priceTextBox);

            Grid.SetRow(grid, lastStationLabelRow + 1);
            AddedStationsInfoGrid.Children.Add(grid);

            Dictionary<String, object> info = new Dictionary<string, object>();
            info.Add("startStation", addedStations[addedStations.Count - 2]);
            info.Add("endStation", addedStations[addedStations.Count - 1]);
            info.Add("durationTextBox", durationTextBox);
            info.Add("priceTextBox", priceTextBox);


            infoBetweenStations.Add(info);
        }

        private void addBetweenStationInfoGrid(string lastStation, string station)
        {
            Grid grid = new Grid();
            addColumnStars(grid, 2);
            addColumnStars(grid, 4);
            addColumnStars(grid, 3);
            addColumnStars(grid, 3);
            addRowStars(grid, 1);
            addRowStars(grid, 2);
            addRowStars(grid, 2);
            addRowStars(grid, 1);

            Label durationLabel = new Label();
            durationLabel.Content = "Trip duration (minutes):";
            durationLabel.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetRow(durationLabel, 1);
            Grid.SetColumn(durationLabel, 1);
            grid.Children.Add(durationLabel);

            TextBox durationTextBox = new TextBox();
            Grid.SetRow(durationTextBox, 1);
            Grid.SetColumn(durationTextBox, 2);
            grid.Children.Add(durationTextBox);

            Label priceLabel = new Label();
            priceLabel.Content = "Price (rsd):";
            priceLabel.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetRow(priceLabel, 2);
            Grid.SetColumn(priceLabel, 1);
            grid.Children.Add(priceLabel);

            TextBox priceTextBox = new TextBox();
            Grid.SetRow(priceTextBox, 2);
            Grid.SetColumn(priceTextBox, 2);
            grid.Children.Add(priceTextBox);

            Grid.SetRow(grid, lastStationLabelRow + 1);
            AddedStationsInfoGrid.Children.Add(grid);

            Dictionary<String, object> info = new Dictionary<string, object>();
            info.Add("startStation", lastStation);
            info.Add("endStation", station);
            info.Add("durationTextBox", durationTextBox);
            info.Add("priceTextBox", priceTextBox);


            infoBetweenStations.Add(info);
        }

       

        private void addStationLabel(String stationName)
        {
            Label label = new Label();
            label.Content = stationName;
            label.Foreground = Brushes.Black;
            Grid.SetRow(label, lastStationLabelRow + 2);
            AddedStationsInfoGrid.Children.Add(label);

        }

        private void addRowPixels(Grid grid, double height)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(height);
            grid.RowDefinitions.Add(rd);
        }

        private void addRowStars(Grid grid, double stars)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(stars, GridUnitType.Star);
            grid.RowDefinitions.Add(rd);
        }

        private void addColumnStars(Grid grid, double stars)
        {
            var cd = new ColumnDefinition();
            cd.Width = new GridLength(stars, GridUnitType.Star);
            grid.ColumnDefinitions.Add(cd);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

            String messages = "";
            int duration;
            int price;

            String parameters = "";


            if (infoBetweenStations.Count == 0)
            {
                messages += $"You have not added enough stations. Minimal number of stations is 2.\n";
            }

            foreach (var info in infoBetweenStations)
            {               
                TextBox durationTextBox = (TextBox)info["durationTextBox"];
                String durationString = durationTextBox.Text;

                if (durationString == "")
                {
                    messages += $"You must fill trip duration between {info["startStation"]} and {info["endStation"]}.\n";
                }
                else
                {

                    try
                    {
                        duration = Int32.Parse(durationString);
                        info["duration"] = duration;
                    }
                    catch (Exception)
                    {
                        messages += $"Trip duration between {info["startStation"]} and {info["endStation"]} must be a number.\n";
                    }

                }

                TextBox priceTextBox = (TextBox)info["priceTextBox"];

                String priceString = priceTextBox.Text;


                if (priceString == "")
                {
                    messages += $"You must fill price between {info["startStation"]} and {info["endStation"]}.\n";
                }

                else
                {
                    try
                    {
                        price = Int32.Parse(priceString);


                        info["price"] = price;
                    }
                    catch (FormatException)
                    {
                        messages += $"Price between {info["startStation"]} and {info["endStation"]} must be a number.\n";
                    }
                }

                if (messages == "")
                {

                    Console.WriteLine();

                    parameters += $"From {info["startStation"]} to {info["endStation"]} you will travel {info["duration"]} minutes, and you will spend {info["price"]}rsd\n";
                }

            }

            if (messages == "")
            {

                if (trainline == null)
                {
                    int response = (int)MessageBox.Show("Are you sure you want to add a train route with these parameters?\n" + parameters, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (response == 6)
                    {

                        Data.AddTrainLine(infoBetweenStations);
                        int ok = (int)MessageBox.Show("Train route successfully added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window.ShowReadTrainRoute(true);
                    }
                    else
                    {
                        MessageBox.Show("Train route addition cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                else
                {
                    int response = (int)MessageBox.Show("Are you sure you want to edit a train route with these parameters?\n" + parameters, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (response == 6)
                    {

                        Data.editTrainLine(infoBetweenStations, trainline.Name);
                        int ok = (int)MessageBox.Show("Train route successfully edited!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window.ShowReadTrainRoute(true);
                    }
                    else
                    {
                        MessageBox.Show("Train route editing cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

            }
            else
            {
                MessageBox.Show(messages, "Inadequate parameters", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (trainline == null)
            {
                int response = (int)MessageBox.Show("Are you sure you want to cancel train route addition?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (response == 6)
                {

                    MessageBox.Show("Train route addition cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    Window.ShowReadTrainRoute(true);
                }

            }

            else
            {
                int response = (int)MessageBox.Show("Are you sure you want to cancel train route editing?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (response == 6)
                {

                    MessageBox.Show("Train route editing cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    Window.ShowReadTrainRoute(true);
                }

            }
        }
        public void RefreshPage()
        {
            infoBetweenStations.Clear();
            TryDisableUndoRedo();
            AddContentForAdding();
        }
        private void TryDisableUndoRedo()
        {
            if (addedStationsEditing == null)
            {
                if (addedStations.Count == 0)
                {
                    UndoAddTrainRoute.IsEnabled = false;
                    maxSteps = 0;
                }
                else
                    UndoAddTrainRoute.IsEnabled = true;
            }
            else
            {
                if (addedStations.Count == addedStationsEditing.Count)
                {
                    UndoAddTrainRoute.IsEnabled = false;
                    maxSteps = maxStepsEditing;
                }
                else
                    UndoAddTrainRoute.IsEnabled = true;
            }
            if (addedStationsEditing == null)
            {
                if (addedStations.Count == maxSteps)
                    RedoAddTrainRoute.IsEnabled = false;
                else
                    RedoAddTrainRoute.IsEnabled = true;
            }
            else
            {
                if (addedStations.Count == maxStepsEditing)
                    RedoAddTrainRoute.IsEnabled = false;
                else
                    RedoAddTrainRoute.IsEnabled = true;
            }
        }

        private void UndoAddTrainRoute_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to undo adding a station to trainline?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                string st = addedStations[addedStations.Count - 1];
                removedStations.Add(st);
                addedStations.Remove(st);
                RefreshPage();
            }
            else
            {
                MessageBox.Show("Undo adding station cancelled.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void RedoAddTrainRoute_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to redo adding a station to trainline?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                addedStations.Add(removedStations[removedStations.Count - 1]);
                RefreshPage();
            }
            else
            {
                MessageBox.Show("Redo adding station cancelled.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpProvider.ShowHelp("AddTrainline", Window);
        }
    }
}

