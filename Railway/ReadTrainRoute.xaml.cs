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
    public partial class ReadTrainRoute : Page
    {
        private Railway.MainWindow window { get; set; }
        public ReadTrainRoute(Railway.MainWindow mainWindow)
        {
            this.window = mainWindow;
            InitializeComponent();
            TryDisableUndoRedo();

            AddContent();

        }

        public void AddContent()
        {
            int trainlineIndex = 1;

            foreach (Trainline trainline in Data.GetTrainLines())
            {
                OneTrainRoute oneTrainRoute = new OneTrainRoute(trainline, window);

                addRowPixels(ReadTrainRouteGrid, oneTrainRoute.getHeight());
                Grid.SetRow(oneTrainRoute, trainlineIndex);

                ReadTrainRouteGrid.Children.Add(oneTrainRoute);
                trainlineIndex++;
            }
        }

        private void addRowPixels(Grid grid, double height)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(height);
            grid.RowDefinitions.Add(rd);
        }


        private void AddNewTrainRoute_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Content = new AddTrainRoute(window);
        }
        public void RefreshPage()
        {
            TryDisableUndoRedo();
            ReadTrainRouteGrid.Children.RemoveRange(0, ReadTrainRouteGrid.Children.Count);
            AddContent();
        }
        private void TryDisableUndoRedo()
        {
            if (!Data.NeedUndo())
                UndoDeleteTrainRoute.IsEnabled = false;
            else
                UndoDeleteTrainRoute.IsEnabled = true;
            if (!Data.NeedRedo())
                RedoDeleteTrainRoute.IsEnabled = false;
            else
                RedoDeleteTrainRoute.IsEnabled = true;
        }

        private void UndoDeleteTrainRoute_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to undo deleting train route?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Data.Undo();
                RefreshPage();
            }
            else
            {
                MessageBox.Show("Undo deleting train route cancelled.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void RedoDeleteTrainRoute_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to redo deleting train route?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Data.Redo();
                RefreshPage();
            }
            else
            {
                MessageBox.Show("Redo deleting train route cancelled.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

