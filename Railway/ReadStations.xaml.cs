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
    /// Interaction logic for ReadStations.xaml
    /// </summary>
    public partial class ReadStations : Page
    {
        private Railway.MainWindow Window;
        public ReadStations(Railway.MainWindow window)
        {
            InitializeComponent();


            Window = window;
            addContent();
            TryDisableUndoRedo();
        }
        public void addContent() {

            int trainIndex = 1;

            foreach (Station station in Data.getStations())
            {
                OneStation oneStation = new OneStation(Window, station);

                addRowPixels(ReadStationsGrid, oneStation.getHeight());

                Grid.SetRow(oneStation, trainIndex);

                ReadStationsGrid.Children.Add(oneStation);
                trainIndex++;
            }
        }

        private void addRowPixels(Grid grid, double height)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(height);
            grid.RowDefinitions.Add(rd);
        }

        private void AddNewStation_Click(object sender, RoutedEventArgs e)
        {
            Window.MainFrame.Content = new AddingStation(Window);
        }

        internal void RefreshPage()
        {
            ReadStationsGrid.Children.Clear();
            TryDisableUndoRedo();
            addContent();

        }
        private void TryDisableUndoRedo()
        {
            if (!Data.NeedUndo())
                UndoStations.IsEnabled = false;
            else
                UndoStations.IsEnabled = true;
            if (!Data.NeedRedo())
                UndoStations.IsEnabled = false;
            else
                UndoStations.IsEnabled = true;
        }
    }
}
