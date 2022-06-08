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
    /// Interaction logic for OneTrain.xaml
    /// </summary>
    public partial class OneTrain : Grid
    {
        Railway.MainWindow Window { get; set; }
        public Train Train { get; set; }
        public OneTrain(Train train, Railway.MainWindow window)
        {
            InitializeComponent();
            this.Train = train;
            Window = window;

            NumberOfWagonsLabel.Content = train.seats.numberOfWagons.ToString();
            NumberOfColumnsLabel.Content = train.seats.numberOfColumns.ToString();
            NumberOfRowsLabel.Content = train.seats.numberOfSeatsPerColumn.ToString();
            NameLabel.Content = train.Name;
        }

        public int getHeight()
        {
            return 75;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show($"Are you sure you want to delete train {Train.Name}?\n", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Data.deleteTrain(Train);
                int ok = (int)MessageBox.Show($"Train {Train.Name} successfully deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Window.ShowReadTrain(false);
            }
            else
            {
                MessageBox.Show($"Train route {Train.Name} deletion cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Window.MainFrame.Content = new AddTrain(Window, Train);
        }

      
    }
}
