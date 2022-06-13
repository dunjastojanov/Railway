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
    /// Interaction logic for OneTimetable.xaml
    /// </summary>
    public partial class OneTimetable : Grid
    {
        Railway.MainWindow Window { get; set; }
        Timetable timetable;

        int row;
        
        public OneTimetable(Railway.MainWindow window, Timetable timetable)
        {
            InitializeComponent();
            Window = window;


            TimeTableName.Content =timetable.Name;
            TimeTableName.Foreground = new SolidColorBrush(Colors.Black);
            TrainName.Content = timetable.Train.Name;
            TrainName.Foreground = new SolidColorBrush(Colors.Black);

            this.timetable = timetable;
            string days = "";
            foreach (string day in timetable.Days)
            {
                days += day + ", ";
            }
            DaysLabel.Content = days.Remove(days.Length - 2);
            DaysLabel.Foreground = new SolidColorBrush(Colors.Black);
            row = 1;

            addRowPixels(StationsGrid, 30);
            
            

            DateTime datetime = timetable.TimeFromFirstStation;
            Station station = timetable.Trainline.FirstStation;
            Path path;

            while (station.PathToNextStation != null)
            {
                Label stationName = new Label();
                stationName.Content = station.Name;
                Grid.SetColumn(stationName, 1);
                Grid.SetRow(stationName, row);
                StationsGrid.Children.Add(stationName);

                Label time = new Label();
                time.Content = $"{datetime.Hour.ToString().PadLeft(2, '0')}:{datetime.Minute.ToString().PadLeft(2, '0')}";
                Grid.SetColumn(time, 0);
                Grid.SetRow(time, row);
                StationsGrid.Children.Add(time);

                path = station.PathToNextStation;
                datetime = datetime.AddMinutes((double)path.Duration);
                station = path.NextStation;
                row++;

                addRowPixels(StationsGrid, 30);
                

            }

            Label s = new Label();
            s.Content = station.Name;
            Grid.SetColumn(s, 1);
            Grid.SetRow(s, row);
            StationsGrid.Children.Add(s);

            Label t = new Label();
            t.Content = $"{datetime.Hour.ToString().PadLeft(2, '0')}:{datetime.Minute.ToString().PadLeft(2, '0')}";
            Grid.SetColumn(t, 0);
            Grid.SetRow(t, row);
            StationsGrid.Children.Add(t);

            row = 1;

            station = timetable.Trainline.LastStation;
            datetime = timetable.TimeFromLastStation;

            while (station.PathToPreviousStation != null)
            {
                Label stationName = new Label();
                stationName.Content = station.Name;
                Grid.SetColumn(stationName, 3);
                Grid.SetRow(stationName, row);
                StationsGrid.Children.Add(stationName);

                Label time = new Label();
                time.Content = $"{datetime.Hour.ToString().PadLeft(2, '0')}:{datetime.Minute.ToString().PadLeft(2, '0')}";
                Grid.SetColumn(time, 2);
                Grid.SetRow(time, row);
                StationsGrid.Children.Add(time);

                path = station.PathToPreviousStation;
                datetime = datetime.AddMinutes((double)path.Duration);
                station = path.PreviousStation;
                row++;

            }

            Label sn = new Label();
            sn.Content = station.Name;
            Grid.SetColumn(sn, 3);
            Grid.SetRow(sn, row);
            StationsGrid.Children.Add(sn);

            Label tn = new Label();
            tn.Content = $"{datetime.Hour.ToString().PadLeft(2, '0')}:{datetime.Minute.ToString().PadLeft(2, '0')}";
            Grid.SetColumn(tn, 2);
            Grid.SetRow(tn, row);
            StationsGrid.Children.Add(tn);
        }
        public OneTimetable(Railway.MainWindow window, Timetable timetable, string user)
        {
            InitializeComponent();
            Window = window;


            TimeTableName.Content = "Name: " + timetable.Name;
            TrainName.Content = "Train: " + timetable.Train.Name;

            this.timetable = timetable;
            string days = "";
            foreach (string day in timetable.Days)
            {
                days += day + ", ";
            }
            
            DaysLabel.Content = days.Remove(days.Length-2);

            row = 1;

            addRowPixels(StationsGrid, 40);
            addRowPixels(StationsGrid, 3);

            DateTime datetime = timetable.TimeFromFirstStation;
            Station station = timetable.Trainline.FirstStation;
            Path path;

            while (station.PathToNextStation != null)
            {
                Label stationName = new Label();
                stationName.Content = station.Name;
                stationName.Foreground = Brushes.Black;
                Grid.SetColumn(stationName, 1);
                Grid.SetRow(stationName, row);
                StationsGrid.Children.Add(stationName);

                Label time = new Label();
                time.Content = $"{datetime.Hour.ToString().PadLeft(2, '0')}:{datetime.Minute.ToString().PadLeft(2, '0')}";
                time.Foreground = Brushes.Black;
                Grid.SetColumn(time, 0);
                Grid.SetRow(time, row);
                StationsGrid.Children.Add(time);

                path = station.PathToNextStation;
                datetime = datetime.AddMinutes((double)path.Duration);
                station = path.NextStation;
                row++;

                addRowPixels(StationsGrid, 30);
                addRowPixels(StationsGrid, 5);

            }

            Label s = new Label();
            s.Content = station.Name;
            s.Foreground = Brushes.Black;
            Grid.SetColumn(s, 1);
            Grid.SetRow(s, row);
            StationsGrid.Children.Add(s);

            Label t = new Label();
            t.Content = $"{datetime.Hour.ToString().PadLeft(2, '0')}:{datetime.Minute.ToString().PadLeft(2, '0')}";
            t.Foreground = Brushes.Black;
            Grid.SetColumn(t, 0);
            Grid.SetRow(t, row);
            StationsGrid.Children.Add(t);

            row = 1;

            station = timetable.Trainline.LastStation;
            datetime = timetable.TimeFromLastStation;

            while (station.PathToPreviousStation != null)
            {
                Label stationName = new Label();
                stationName.Content = station.Name;
                stationName.Foreground = Brushes.Black;
                Grid.SetColumn(stationName, 3);
                Grid.SetRow(stationName, row);
                StationsGrid.Children.Add(stationName);

                Label time = new Label();
                time.Content = $"{datetime.Hour.ToString().PadLeft(2, '0')}:{datetime.Minute.ToString().PadLeft(2, '0')}";
                time.Foreground = Brushes.Black;
                Grid.SetColumn(time, 2);
                Grid.SetRow(time, row);
                StationsGrid.Children.Add(time);

                path = station.PathToPreviousStation;
                datetime = datetime.AddMinutes((double)path.Duration);
                station = path.PreviousStation;
                row++;

            }

            Label sn = new Label();
            sn.Content = station.Name;
            sn.Foreground = Brushes.Black;
            Grid.SetColumn(sn, 3);
            Grid.SetRow(sn, row);
            StationsGrid.Children.Add(sn);

            Label tn = new Label();
            tn.Content = $"{datetime.Hour.ToString().PadLeft(2, '0')}:{datetime.Minute.ToString().PadLeft(2, '0')}";
            tn.Foreground = Brushes.Black;
            Grid.SetColumn(tn, 2);
            Grid.SetRow(tn, row);
            StationsGrid.Children.Add(tn);
        }

        internal double getHeight()
        {
            return row * 40 + 150;
        }

        private void addRowPixels(Grid grid, double height)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(height);
            grid.RowDefinitions.Add(rd);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Frame.Content = new AddTimetable(Window, timetable);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            if (Data.canBeDeleted(timetable) == false)
            {
                int ok = (int)MessageBox.Show("Timetable cannot be deleted because there are tickets already bought for it", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int response = (int)MessageBox.Show($"Are you sure you want to delete timetable {timetable.Name}?\n", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Data.deleteTimetable(timetable);
                int ok = (int)MessageBox.Show("Timetable successfully deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Window.ShowReadTimetable(false);
            }
            else
            {
                MessageBox.Show("Timetable deleting cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
