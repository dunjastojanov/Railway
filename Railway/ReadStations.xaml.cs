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
            TryDisableUndoRedo();
            AddContent();
        }
        public void AddContent() {

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
            ReadStationsGrid.Height += height + 10;
            grid.RowDefinitions.Add(rd);
        }

        private void AddNewStation_Click(object sender, RoutedEventArgs e)
        {
            Window.MainFrame.Content = new AddingStation(Window);
        }

        internal void RefreshPage()
        {
            ReadStationsGrid.Children.Clear();
            ReadStationsGrid.Height = 35;
            TryDisableUndoRedo();
            AddContent();

        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpProvider.ShowHelp("ReadStation", Window);
        }
        private void TryDisableUndoRedo()
        {
            if (!Data.NeedUndo())
                UndoStations.IsEnabled = false;
            else
                UndoStations.IsEnabled = true;
            if (!Data.NeedRedo())
                RedoStations.IsEnabled = false;
            else
                RedoStations.IsEnabled = true;
        }
        private void UndoDeleteStation_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to undo action?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Data.Undo();
                RefreshPage();
            }
            else
            {
                MessageBox.Show("Undo action cancelled.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void RedoDeleteStation_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to redo action?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Data.Redo();
                RefreshPage();
            }
            else
            {
                MessageBox.Show("Redo action cancelled.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
