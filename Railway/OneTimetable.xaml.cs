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
        Frame managerContentFrame;

        int row;
        
        public OneTimetable(Frame managerContentFrame, Timetable timetable)
        {
            InitializeComponent();
            this.managerContentFrame = managerContentFrame;
            NameLabel.Content = timetable.Trainline.Name;
            string days = "";
            foreach (string day in timetable.Days)
            {
                days += day + "\t";
            }
            DaysLabel.Content = days;

            row = 0;

            addRowPixels(StationsGrid, 30);
            addRowPixels(StationsGrid, 5);

            DateTime datetime = timetable.TimeFromFirstStation;
            Station station = timetable.Trainline.FirstStation;
            Path path;

            while (station.PathToNextStation != null)
            {
                Label stationName = new Label();
                stationName.Content = station.Name;
                stationName.Foreground = Brushes.White;
                Grid.SetColumn(stationName, 1);
                Grid.SetRow(stationName, row);
                StationsGrid.Children.Add(stationName);

                Label time = new Label();
                time.Content = $"{datetime.Hour.ToString().PadLeft(2, '0')}:{datetime.Minute.ToString().PadLeft(2, '0')}";
                time.Foreground = Brushes.White;
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
        }

        internal double getHeight()
        {
            return row * 35 + 60;
        }

        private void addRowPixels(Grid grid, double height)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(height);
            grid.RowDefinitions.Add(rd);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
