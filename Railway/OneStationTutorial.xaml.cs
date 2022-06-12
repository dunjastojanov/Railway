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
using Railway.Model;

namespace Railway
{
    /// <summary>
    /// Interaction logic for OneStationTutorial.xaml
    /// </summary>
    public partial class OneStationTutorial : Grid
    {
        public Railway.MainWindow Window { get; set; }
        public Station Station { get; set; }
        ReadStationTutorial ReadStationTutorial { get; set; }

        TutorialHomePage TutorialHomePage { get; set; }
        public OneStationTutorial(TutorialHomePage tutorialHomePage, ReadStationTutorial readStationTutorial, Railway.MainWindow window, Station station, string step)
        {
            InitializeComponent();
            Window = window;
            ReadStationTutorial = readStationTutorial;
            TutorialHomePage = tutorialHomePage;
            Station = station;
            if (step.Equals("step1"))
            {
                DeleteButton.IsEnabled = true;
                EditButton.IsEnabled = false;
            }
            else if (step.Equals("step5"))
            {
                DeleteButton.IsEnabled = false;
                EditButton.IsEnabled = true;
            }
            else
            {
                DeleteButton.IsEnabled = false;
                EditButton.IsEnabled = false;
            }
            LatitudeLabel.Content = $"Latitude: {station.Latitude}";
            LongitudeLabel.Content = $"Longitude: {station.Longitude}";
            NameLabel.Content = $"Name: {station.Name}";
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            TutorialHomePage.tutorialFrame.Content = new UpdateStationTutorial(TutorialHomePage, Window, "step6", Station);
        }

        public int getHeight()
        {
            return 120;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Data.deleteStationTutorial(Station);
            MessageBox.Show("Station deleted succesfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            ReadStationTutorial.Step = "step2";
            ReadStationTutorial.RefreshPage();
            ReadStationTutorial.DoStep();
        }
    }

}
