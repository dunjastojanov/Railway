
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
    /// Interaction logic for TutorialHomePage.xaml
    /// </summary>
    public partial class TutorialHomePage : Page
    {
        Railway.MainWindow Window { get; set; }
        public Button TrainlinesTut { get; set; }
        public Button TrainsTut { get; set; }
        public Button TimetablesTut { get; set; }
        public Button StationsTut { get; set; }

        public TutorialHomePage(Railway.MainWindow window)
        {
            InitializeComponent();
            Window = window;
            AddTutorialNavbar();
            Data.CreateTutorialData();
            ShowTutorialHomePage();
        }
        private void AddTutorialNavbar()
        {
            Window.navButtons.Children.RemoveRange(0, Window.navButtons.Children.Count);

            TrainlinesTut = new Button();
            TrainlinesTut.BorderThickness = new Thickness(0);
            TrainlinesTut.Height = 35;
            TrainlinesTut.HorizontalAlignment = HorizontalAlignment.Stretch;
            TrainlinesTut.FontSize = 15;
            TrainlinesTut.Content = "Trainlines";
            TrainlinesTut.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            TrainlinesTut.Foreground = Brushes.FloralWhite;
            TrainlinesTut.IsEnabled = false;
            TrainlinesTut.Click += TrainlinesBeginTut_Click;

            TrainsTut = new Button();
            TrainsTut.BorderThickness = new Thickness(0);
            TrainsTut.Height = 35;
            TrainsTut.HorizontalAlignment = HorizontalAlignment.Stretch;
            TrainsTut.FontSize = 15;
            TrainsTut.Content = "Trains";
            TrainsTut.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            TrainsTut.Foreground = Brushes.FloralWhite;
            TrainsTut.IsEnabled = false;
            TrainsTut.Click += TrainsBeginTut_Click;

            StationsTut = new Button();
            StationsTut.BorderThickness = new Thickness(0);
            StationsTut.Height = 35;
            StationsTut.HorizontalAlignment = HorizontalAlignment.Stretch;
            StationsTut.FontSize = 15;
            StationsTut.Content = "Stations";
            StationsTut.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            StationsTut.Foreground = Brushes.FloralWhite;
            StationsTut.IsEnabled = false;
            StationsTut.Click += StationsBeginTut_Click;

            TimetablesTut = new Button();
            TimetablesTut.BorderThickness = new Thickness(0);
            TimetablesTut.Height = 35;
            TimetablesTut.HorizontalAlignment = HorizontalAlignment.Stretch;
            TimetablesTut.FontSize = 15;
            TimetablesTut.Content = "Timetables";
            TimetablesTut.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            TimetablesTut.Foreground = Brushes.FloralWhite;
            TimetablesTut.IsEnabled = false;
            TimetablesTut.Click += TimetablesBeginTut_Click;

            Window.navButtons.Children.Add(TrainlinesTut);
            Window.navButtons.Children.Add(TrainsTut);
            Window.navButtons.Children.Add(StationsTut);
            Window.navButtons.Children.Add(TimetablesTut);
        }

        public void ShowTutorialHomePage()
        {
            tutorialFrame.Content = new TutorialButtons(this);
        }
        private void TimetablesBeginTut_Click(object sender, RoutedEventArgs e)
        {
            tutorialFrame.Content = new ReadTimetableTutorial(this, Window);
        }
        private void TrainlinesBeginTut_Click(object sender, RoutedEventArgs e)
        {

        }
        private void TrainsBeginTut_Click(object sender, RoutedEventArgs e)
        {
            tutorialFrame.Content = new ReadTrainTutorial(this, Window);
        }
        private void StationsBeginTut_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to cancel tutorial and return to admin home page?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Window.CreateAdminNavbar();
                Window.ShowAdminHomePage();
            }
            else
            {
                MessageBox.Show("Exiting tutorial cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
