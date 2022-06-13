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
    /// Interaction logic for OneTrainTutorial.xaml
    /// </summary>
    public partial class OneTrainTutorial : Grid
    {
        Railway.MainWindow Window { get; set; }
        public Train Train { get; set; }
        ReadTrainTutorial rt { get; set; }
        public OneTrainTutorial(Train train, Railway.MainWindow window, int step, ReadTrainTutorial rt)
        {
            this.rt = rt;
            InitializeComponent();
            this.Train = train;
            Window = window;

            

            if (step == 1)
            {
                DeleteButton.IsEnabled = true;
                EditButton.IsEnabled = false;
            }
            else if (step == 4)
            {
                DeleteButton.IsEnabled = false;
                EditButton.IsEnabled = true;
            }
            else
            {
                DeleteButton.IsEnabled = false;
                EditButton.IsEnabled = false;
            }
          

            NumberOfWagonsLabel.Content = $"Number of wagons: {train.seats.numberOfWagons.ToString()}";
            NumberOfColumnsLabel.Content = $"Number of columns: {train.seats.numberOfColumns.ToString()}";
            NumberOfRowsLabel.Content = $"Number of rows: {train.seats.numberOfSeatsPerColumn.ToString()}";
            NameLabel.Content = $"Name: {train.Name}";
        }

        public int getHeight()
        {
            return 120;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            Data.deleteTrainTutorial(Train);
            int ok = (int)MessageBox.Show($"Train {Train.Name} successfully deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            rt.RefreshPage();
            rt.Step = 2;
            rt.DoStep();

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Window.MainFrame.Content = new AddTrainTutorial(Window, Train, rt);
        }


    }
}
