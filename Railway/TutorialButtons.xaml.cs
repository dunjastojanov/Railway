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
    /// Interaction logic for TutorialButtons.xaml
    /// </summary>
    public partial class TutorialButtons : Page
    {
        TutorialHomePage TutorialHomePage { get; set; }
        public TutorialButtons(TutorialHomePage thp)
        {
            InitializeComponent();
            TutorialHomePage = thp;
        }
        private void ShowTrainlineTut_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to start tutorial for trainlines?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                MessageBox.Show("Please select button 'Trainlines' on the left.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                TutorialHomePage.TrainlinesTut.IsEnabled = true;
                TutorialHomePage.TrainsTut.IsEnabled = false;
                TutorialHomePage.TimetablesTut.IsEnabled = false;
                TutorialHomePage.StationsTut.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Exiting trainlines tutorial successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ShowTrainTut_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to start tutorial for trains?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                MessageBox.Show("Please select button 'Trains' on the left.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                TutorialHomePage.TrainlinesTut.IsEnabled = false;
                TutorialHomePage.TrainsTut.IsEnabled = true;
                TutorialHomePage.TimetablesTut.IsEnabled = false;
                TutorialHomePage.StationsTut.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Exiting trains tutorial successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ShowTimetableTut_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to start tutorial for timetables?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                MessageBox.Show("Please select button 'Timetables' on the left.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                TutorialHomePage.TrainlinesTut.IsEnabled = false;
                TutorialHomePage.TrainsTut.IsEnabled = false;
                TutorialHomePage.TimetablesTut.IsEnabled = true;
                TutorialHomePage.StationsTut.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Exiting timetables tutorial successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ShowStationTut_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to start tutorial for stations?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                MessageBox.Show("Please select button 'Stations' on the left.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                TutorialHomePage.TrainlinesTut.IsEnabled = false;
                TutorialHomePage.TrainsTut.IsEnabled = false;
                TutorialHomePage.TimetablesTut.IsEnabled = false;
                TutorialHomePage.StationsTut.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Exiting stations tutorial successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
