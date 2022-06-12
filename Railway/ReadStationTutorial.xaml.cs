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
    /// Interaction logic for ReadStationTutorial.xaml
    /// </summary>
    public partial class ReadStationTutorial : Page
    {
        public TutorialHomePage TutorialHomePage { get; set; }
        Railway.MainWindow Window { get; set; }
        string User { get; set; }
        public string Step { get; set; }
        public ReadStationTutorial(TutorialHomePage tutorialHomePage, Railway.MainWindow window,String step)
        {
            Step = step;
            InitializeComponent();
            Window = window;
            TutorialHomePage = tutorialHomePage;
            User = null;
            AddNewStation.IsEnabled = false;
            UndoStations.IsEnabled = false;
            RedoStations.IsEnabled = false;
            AddContent();
            DoStep();
        }
        public void DoStep()
        {
            if (Step.Equals("step1"))
                Step1();
            else if (Step.Equals("step2"))
                Step2();
            else if (Step.Equals("step3"))
                Step3();
            else if (Step.Equals("step4"))
                Step4();
            else if (Step.Equals("step5"))
                Step5Async();
            else if (Step.Equals("step6"))
                Step6Async();
        }

        private async void Step1()
        {
            await Task.Delay(600);
            AddNewStation.IsEnabled = false;
            UndoStations.IsEnabled = false;
            RedoStations.IsEnabled = false;
            MessageBox.Show("Please select button 'Delete' to delete one station.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Step2()
        {
            MessageBox.Show("Please select button 'Undo' to undo deleting station.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            AddNewStation.IsEnabled = false;
            UndoStations.IsEnabled = true;
            RedoStations.IsEnabled = false;
        }
        private void Step3()
        {
            MessageBox.Show("Please select button 'Redo' to redo deleting station.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            AddNewStation.IsEnabled = false;
            UndoStations.IsEnabled = false;
            RedoStations.IsEnabled = true;
        }
        private void Step4()
        {
            AddNewStation.IsEnabled = true;
            UndoStations.IsEnabled = false;
            RedoStations.IsEnabled = false;
            MessageBox.Show("Please select button 'Add' to add one station.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private async Task Step5Async()
        {
            await Task.Delay(600);
            AddNewStation.IsEnabled = false;
            UndoStations.IsEnabled = false;
            RedoStations.IsEnabled = false;
            MessageBox.Show("Please select button 'Edit' to edit one station.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private async Task Step6Async()
        {
            await Task.Delay(600);
            AddNewStation.IsEnabled = false;
            UndoStations.IsEnabled = false;
            RedoStations.IsEnabled = false;
            MessageBox.Show("Congratulations! You have finished timetables tutorial.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            TutorialHomePage.ShowTutorialHomePage();
        }
        public void AddContent()
        {

            int trainIndex = 1;

            foreach (Station station in Data.getStationsTutorials())
            {
                OneStationTutorial oneStation = new OneStationTutorial(TutorialHomePage,this,Window,station,Step);
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
            TutorialHomePage.tutorialFrame.Content = new AddingStationTutorial(TutorialHomePage,Window, Step);
        }

        internal void RefreshPage()
        {
            ReadStationsGrid.Children.Clear();
            ReadStationsGrid.Height = 35;
            AddContent();

        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpProvider.ShowHelp("ReadStation", Window);
        }
        private void UndoDeleteStation_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to undo deleting station?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Data.UndoTutorial();
                Step = "step3";
                RefreshPage();
                DoStep();
            }
            else
            {
                MessageBox.Show("Undo deleting station cancelled.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void RedoDeleteStation_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to redo deleting station?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Data.RedoTutorial();
                Step = "step4";
                RefreshPage();
                DoStep();
            }
            else
            {
                MessageBox.Show("Redo deleting station cancelled.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
