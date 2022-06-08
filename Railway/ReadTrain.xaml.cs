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
    /// Interaction logic for ReadTrain.xaml
    /// </summary>
    public partial class ReadTrain : Page
    {
        private Railway.MainWindow Window;
        public ReadTrain(Railway.MainWindow window)
        {
            InitializeComponent();
            Window = window;
            TryDisableUndoRedo();

            AddContent();         
        }

        private void AddContent()
        {
            int trainIndex = 1;

            foreach (Train train in Data.GetTrains())
            {
                OneTrain oneTrain = new OneTrain(train, Window);

                addRowPixels(ReadTrainGrid, oneTrain.getHeight());

                Grid.SetRow(oneTrain, trainIndex);

                ReadTrainGrid.Children.Add(oneTrain);
                trainIndex++;
            }
        }

        private void addRowPixels(Grid grid, double height)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(height);
            grid.RowDefinitions.Add(rd);
        }

        private void AddNewTrain_Click(object sender, RoutedEventArgs e)
        {
            Window.MainFrame.Content = new AddTrain(Window);
        }
        public void RefreshPage()
        {
            TryDisableUndoRedo();
            ReadTrainGrid.Children.RemoveRange(0, ReadTrainGrid.Children.Count);
            AddContent();
        }
        private void TryDisableUndoRedo()
        {
            if (!Data.NeedUndo())
                UndoDeleteTrain.IsEnabled = false;
            else
                UndoDeleteTrain.IsEnabled = true;
            if (!Data.NeedRedo())
                RedoDeleteTrain.IsEnabled = false;
            else
                RedoDeleteTrain.IsEnabled = true;
        }

        private void UndoDeleteTrain_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to undo deleting train?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Data.Undo();
                RefreshPage();
            }
            else
            {
                MessageBox.Show("Undo deleting train cancelled.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void RedoDeleteTrain_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to redo deleting train?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Data.Redo();
                RefreshPage();
            }
            else
            {
                MessageBox.Show("Redo deleting train cancelled.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
