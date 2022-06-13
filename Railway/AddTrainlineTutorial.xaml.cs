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
    public partial class AddTrainlineTutorial : Page
    {
        Trainline trainline = null;
        int lastStationLabelRow;
        List<Dictionary<String, object>> infoBetweenStations;
        List<String> addedStations;
        List<String> removedStations;
        List<String> addedStationsEditing;
        int maxSteps;
        int maxStepsEditing;

        TextBox durationText;
        bool durationTextAbleToChange;
        TextBox priceText;
        bool priceTextAbleToChange;

        int Step;

        ReadTrainlineTutorial readTrainlineTutorial;


        Railway.MainWindow Window;

        public AddTrainlineTutorial(Railway.MainWindow window, ReadTrainlineTutorial readTrainlineTutorial)
        {
            this.Window = window;
            this.readTrainlineTutorial = readTrainlineTutorial;
            InitializeComponent();
            maxSteps = 0;
            maxStepsEditing = 0;

            durationTextAbleToChange = false;
            priceTextAbleToChange = false;

            infoBetweenStations = new List<Dictionary<string, object>>();
            addedStations = new List<String>();
            removedStations = new List<String>();

            lastStationLabelRow = -1;

            StationComboBox.IsEnabled = false;
            saveButton.IsEnabled = false;


            foreach (string stationName in Data.GetStationNames())
            {
                StationComboBox.Items.Add(stationName);

            }

            Step = 1;
            DoStep();

        }

        public AddTrainlineTutorial(Railway.MainWindow window, Trainline trainline, ReadTrainlineTutorial readTrainlineTutorial)
        {
            this.Window = window;
            this.readTrainlineTutorial = readTrainlineTutorial;
            InitializeComponent();


            this.trainline = trainline;

            maxSteps = 0;

            infoBetweenStations = new List<Dictionary<string, object>>();
            addedStations = new List<String>();
            addedStationsEditing = new List<String>();
            removedStations = new List<String>();
            lastStationLabelRow = -1;
            saveButton.IsEnabled = false;


            foreach (string stationName in Data.GetStationNames())
            {
                StationComboBox.Items.Add(stationName);

            }

            AddContentForEditing();
            maxStepsEditing = addedStationsEditing.Count;

            Step = 1;
            DoStep();

        }

        public void DoStep()
        {
            switch (Step)
            {
                case 1:
                    {
                        Step1();
                        break;
                    }
                case 2:
                    {
                        Step2();
                        break;
                    }
                case 3:
                    {
                        Step3();
                        break;
                    }
                case 4:
                    {
                        Step4();
                        break;
                    }
                case 5:
                    {
                        Step5();
                        break;

                    }
            }


        }

        public async void Step1()
        {
            await Task.Delay(600);
            StationComboBox.IsEnabled = true;
            MessageBox.Show("Please select a station from dropdowm menu right of the text choose label.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void Step2()
        {
            if (trainline != null)
            {
                Step++;
                DoStep();
            }
            else
            {
                StationComboBox.IsEnabled = true;
                MessageBox.Show("Please select another station from dropdowm menu right of the text choose label.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
        public void Step3()
        {
            StationComboBox.IsEnabled = false;
            durationText.IsEnabled = true;
            priceText.IsEnabled = false;
            durationTextAbleToChange = true;
            MessageBox.Show("Please fill in the duration of the trip between stations above and below.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            durationText.Focus();
        }
        public void Step4()
        {
            durationTextAbleToChange = false;
            priceTextAbleToChange = true;
            StationComboBox.IsEnabled = false;
            durationText.IsEnabled = false;
            priceText.IsEnabled = true;
            MessageBox.Show("Please fill in the price of the trip between stations above and below.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            priceText.Focus();
        }
        public void Step5()
        {
            priceTextAbleToChange = false;
            StationComboBox.IsEnabled = false;
            durationText.IsEnabled = false;
            priceText.IsEnabled = false;
            saveButton.IsEnabled = true;
            MessageBox.Show("Please select the save button.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddContentForEditing()
        {
            Station station = trainline.FirstStation;
            addedStations.Add(station.Name);
            addedStationsEditing.Add(station.Name);
            Model.Path path;


            while (station.PathToNextStation != null)
            {
                AddedStationsInfoGrid.Height = AddedStationsInfoGrid.Height + 30 + 90;
                path = station.PathToNextStation;


                addRowPixels(AddedStationsInfoGrid, 90);

                addRowPixels(AddedStationsInfoGrid, 30);
                addStationLabel(station.Name);


                lastStationLabelRow += 2;

                station = path.NextStation;
                addedStations.Add(station.Name);
                addedStationsEditing.Add(station.Name);

                addBetweenStationInfoGrid(path.Price, path.Duration);

            }

            station = trainline.LastStation;

            AddedStationsInfoGrid.Height = AddedStationsInfoGrid.Height + 30 + 90;
            path = station.PathToPreviousStation;

            addedStations.Add(station.Name);
            addedStationsEditing.Add(station.Name);
            addRowPixels(AddedStationsInfoGrid, 90);


            addBetweenStationInfoGrid(path.Price, path.Duration);


            addStationLabel(station.Name);

            lastStationLabelRow += 2;
        }

        private void durationChange(object sender, RoutedEventArgs e)
        {
            if (durationText.Text.Length > 1 && durationTextAbleToChange == true)
            {
                Step++;
                DoStep();
            }
        }

        private void priceChange(object sender, RoutedEventArgs e)
        {
            if (priceText.Text.Length > 1 && priceTextAbleToChange == true)
            {
                Step++;
                DoStep();
            }
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (addedStations.Count > 0)
            {

                if (addedStations.Contains(StationComboBox.SelectedItem.ToString()) || addedStationsEditing.Contains(StationComboBox.SelectedItem.ToString()))
                {
                    MessageBox.Show("You cannot add the same station two times.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    fillNewInfo();
                    Step++;
                    DoStep();
                }
            }
            else
            {
                fillNewInfo();
                Step++;
                DoStep();

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


        private void fillNewInfo()
        {
            AddedStationsInfoGrid.Height = AddedStationsInfoGrid.Height + 30 + 90;
            
            if (StationComboBox.SelectedItem != null)
            {
                maxSteps++;
                maxStepsEditing++;
                addedStations.Add(StationComboBox.SelectedItem.ToString());

                addStationLabel(StationComboBox.SelectedItem.ToString());

                if (addedStations.Count > 1)
                {
                    addNewBetweenStationInfoGrid(addedStations[addedStations.Count - 2], addedStations[addedStations.Count - 1]);
                }

                lastStationLabelRow += 2;
                
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
            durationTextBox.IsEnabled = false;
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
            priceTextBox.IsEnabled = false;
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
            durationTextBox.IsEnabled = false;
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
            priceTextBox.IsEnabled = false;
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

        private void addNewBetweenStationInfoGrid(string lastStation, string station)
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
            durationText = durationTextBox;
            durationText.TextChanged += durationChange;
            durationText.IsEnabled = false;
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
            priceText = priceTextBox;
            priceText.TextChanged += priceChange;
            priceText.IsEnabled = false;
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

            bool durationBad = false;
            bool priceBad = false;

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
                    durationBad = true;
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
                        durationBad = true;
                        messages += $"Trip duration between {info["startStation"]} and {info["endStation"]} must be a number.\n";
                    }

                }

                TextBox priceTextBox = (TextBox)info["priceTextBox"];

                String priceString = priceTextBox.Text;


                if (priceString == "")
                {
                    priceBad = true;
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
                        priceBad = true;
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

                    int ok = (int)MessageBox.Show("Train route successfully added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    Window.MainFrame.Content = readTrainlineTutorial;
                    readTrainlineTutorial.Step++;
                    readTrainlineTutorial.DoStep();

                }

                else
                {

                    Data.editTrainLineTutorial(infoBetweenStations, trainline.Name);
                    int ok = (int)MessageBox.Show("Train route successfully edited!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    Window.MainFrame.Content = readTrainlineTutorial;
                    readTrainlineTutorial.Step++;
                    readTrainlineTutorial.DoStep();
                }

            }
            else
            {
                MessageBox.Show(messages, "Inadequate parameters", MessageBoxButton.OK, MessageBoxImage.Error);

                if (priceBad == true)
                {
                    priceText.IsEnabled = true;
                }

                if (durationBad == true)
                {
                    durationText.IsEnabled = true;
                }

                MessageBox.Show("Fill in duration and/or price fields with correct parameters and click on the save button again.", "Inadequate parameters", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            if (trainline != null)
            {
                HelpProvider.ShowHelp("EditTrainline", Window);
            }
            else
            {
                HelpProvider.ShowHelp("AddTrainline", Window);
            }
        }
    }
}

