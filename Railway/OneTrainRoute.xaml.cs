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
using Path = Railway.Model.Path;

namespace Railway
{
    /// <summary>
    /// Interaction logic for OneTrainRoute.xaml
    /// </summary>
    public partial class OneTrainRoute : Grid
    {
        int stationNextRow;
        Railway.MainWindow Window;
        Trainline trainline;

        public OneTrainRoute(Trainline trainline, Railway.MainWindow window)
        {
            InitializeComponent();
            addFirstStationLabel(trainline);
            addLastStationLabel(trainline);
            addTrainLineName(trainline);
            this.Window = window;
            this.trainline = trainline;

            Label stationLabel = new Label();
            Label durationLabel;
            Label priceLabel;
            
            Station station = trainline.FirstStation;
            Path path;
            stationNextRow = 0;

            addRowPixels(StationsGrid, 30);
            stationLabel.Foreground = Brushes.White;
            stationLabel.Content = station.Name;
            Grid.SetRow(stationLabel, stationNextRow);
            StationsGrid.Children.Add(stationLabel);

            
            
            while (station.PathToNextStation != null)
            {

                addRowPixels(StationsGrid, 30);
                path = station.PathToNextStation;
                durationLabel = new Label();
                durationLabel.Content = $"Duration (minutes): {path.Duration}";
                durationLabel.Foreground = Brushes.White;
                Grid.SetRow(durationLabel, stationNextRow+1);
                Grid.SetColumn(durationLabel, 1);
                StationsGrid.Children.Add(durationLabel);

                priceLabel = new Label();
                priceLabel.Content = $"Price ($): {path.Price}";
                priceLabel.Foreground = Brushes.White;
                Grid.SetRow(priceLabel, stationNextRow + 1);
                Grid.SetColumn(priceLabel, 2);
                StationsGrid.Children.Add(priceLabel);
                

                stationNextRow += 2;

                addRowPixels(StationsGrid, 30);

                station = path.NextStation;
                stationLabel = new Label();
                stationLabel.Foreground = Brushes.White;
                stationLabel.Content = station.Name;
                Grid.SetRow(stationLabel, stationNextRow);
                StationsGrid.Children.Add(stationLabel);

            }


        }

        private void addTrainLineName(Trainline trainline)
        {
            Label trainLineName = new Label();
            trainLineName.Content = trainline.Name;
            Grid.SetColumn(trainLineName, 13);

            trainLineName.VerticalAlignment = VerticalAlignment.Center;
            trainLineName.HorizontalAlignment = HorizontalAlignment.Left;
            trainLineName.Foreground = Brushes.White;
            TitleGrid.Children.Add(trainLineName);
        }

        private void addLastStationLabel(Trainline trainline)
        {
            Label lastStationName = new Label();
            lastStationName.Content = trainline.LastStation.Name;
            Grid.SetColumn(lastStationName, 11);

            lastStationName.VerticalAlignment = VerticalAlignment.Center;
            lastStationName.HorizontalAlignment = HorizontalAlignment.Left;
            lastStationName.Foreground = Brushes.White;
            TitleGrid.Children.Add(lastStationName);
        }

        internal double getHeight()
        {
            return (stationNextRow+1)*30 + 60;
        }

        private void addFirstStationLabel(Trainline trainline)
        {
            Label firstStationName = new Label();
            firstStationName.Content = trainline.FirstStation.Name;
            Grid.SetColumn(firstStationName, 7);

            firstStationName.VerticalAlignment = VerticalAlignment.Center;
            firstStationName.HorizontalAlignment = HorizontalAlignment.Right;

            firstStationName.Foreground = Brushes.White;
            TitleGrid.Children.Add(firstStationName);
        }


        private void addRowPixels(Grid grid, double height)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(height);
            grid.RowDefinitions.Add(rd);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Window.MainFrame.Content = new AddTrainRoute(Window, trainline);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show($"Are you sure you want to delete train route {trainline.Name}?\n", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Data.deleteTrainRoute(trainline.Name);
                int ok = (int)MessageBox.Show($"Train route {trainline.Name} successfully deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Window.ShowReadTrainRoute(false);
                //Window.MainFrame.Content = new ReadTrainRoute(Window);
            }
            else
            {
                MessageBox.Show($"Train route {trainline.Name} deletion cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ViewMapButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
