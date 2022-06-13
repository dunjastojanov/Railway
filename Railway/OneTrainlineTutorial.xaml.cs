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
    /// Interaction logic for OneTrainlineTutorial.xaml
    /// </summary>
    public partial class OneTrainlineTutorial : Grid
    {
        private Railway.MainWindow Window;
        private Trainline trainline;
        int stationNextRow;
        ReadTrainlineTutorial trainlineTutorial;


        public OneTrainlineTutorial(Model.Trainline trainline, Railway.MainWindow window, ReadTrainlineTutorial tutorial)
        {
            InitializeComponent();

            trainlineTutorial = tutorial;
            DeleteButton.IsEnabled = false;
            EditButton.IsEnabled = false;
            ViewMapButton.IsEnabled = false;

            if (tutorial.Step == 1)
            {
                DeleteButton.IsEnabled = true;
            }
            else if (tutorial.Step == 4) {
                EditButton.IsEnabled = true;
            }

            addTrainLineName(trainline);
            this.Window = window;
            this.trainline = trainline;

            Label stationLabel = new Label();
            Label durationLabel;
            Label priceLabel;

            Station station = trainline.FirstStation;
            Model.Path path;
            stationNextRow = 0;

            addRowPixels(StationsGrid, 40);
            stationLabel.Foreground = Brushes.Black;
            stationLabel.Content = station.Name;
            Grid.SetRow(stationLabel, stationNextRow);
            StationsGrid.Children.Add(stationLabel);



            while (station.PathToNextStation != null)
            {

                addRowPixels(StationsGrid, 40);
                path = station.PathToNextStation;
                durationLabel = new Label();
                durationLabel.Content = $"Duration: {path.Duration} min";
                durationLabel.ToolTip = "Duration of the trip between stations above and below.";
                durationLabel.Foreground = Brushes.Black;
                Grid.SetRow(durationLabel, stationNextRow + 1);
                Grid.SetColumn(durationLabel, 1);
                StationsGrid.Children.Add(durationLabel);

                priceLabel = new Label();
                priceLabel.Content = $"Price: {path.Price} rsd";
                priceLabel.ToolTip = "Price of the trip between stations above and below.";
                priceLabel.Foreground = Brushes.Black;

                Grid.SetRow(priceLabel, stationNextRow + 1);
                Grid.SetColumn(priceLabel, 2);
                StationsGrid.Children.Add(priceLabel);


                stationNextRow += 2;

                addRowPixels(StationsGrid, 40);

                station = path.NextStation;
                stationLabel = new Label();
                stationLabel.Foreground = Brushes.Black;
                stationLabel.Content = station.Name;
                Grid.SetRow(stationLabel, stationNextRow);
                StationsGrid.Children.Add(stationLabel);
            }
        }


        private void addTrainLineName(Trainline trainline)
        {
            TrainLineName.Content = trainline.Name;
        }

        internal double getHeight()
        {
            return (stationNextRow + 1) * 40 + 120;
        }

        private void addRowPixels(Grid grid, double height)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(height);
            grid.RowDefinitions.Add(rd);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Window.MainFrame.Content = new AddTrainlineTutorial(Window, trainline, trainlineTutorial);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            Data.deleteTrainRouteTutorial(trainline.Name);
            int ok = (int)MessageBox.Show($"Train route {trainline.Name} successfully deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            trainlineTutorial.Step = 2;
            trainlineTutorial.DoStep();
        }

        private void ViewMapButton_Click(object sender, RoutedEventArgs e)
        {
            Window.MainFrame.Content = new RailwayNetworkOverview(Window.MainFrame, trainline);
        }
    }
}
