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
    /// Interaction logic for ReadTimetableTutorial.xaml
    /// </summary>
    public partial class ReadTimetableTutorial : Page
    {
        public TutorialHomePage TutorialHomePage { get; set; }
        Railway.MainWindow Window { get; set; }
        string User { get; set; }
        public string Step { get; set; }
        public ReadTimetableTutorial(TutorialHomePage thp, Railway.MainWindow window)
        {
            Step = "step1";
            InitializeComponent();
            Window = window;
            TutorialHomePage = thp;
            User = null;
            AddNewTimetable.IsEnabled = false;
            UndoDeleteTimetable.IsEnabled = false;
            RedoDeleteTimetable.IsEnabled = false;
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
                Step5();
            else if (Step.Equals("step6"))
                Step6();
        }     
        private async void Step1()
        {
            await Task.Delay(600);
            AddNewTimetable.IsEnabled = false;
            UndoDeleteTimetable.IsEnabled = false;
            RedoDeleteTimetable.IsEnabled = false;
            MessageBox.Show("Please select button 'Delete' to delete one timetable.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Step2()
        {
            MessageBox.Show("Please select button 'Undo' to undo deleting timetable.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            AddNewTimetable.IsEnabled = false;
            UndoDeleteTimetable.IsEnabled = true;
            RedoDeleteTimetable.IsEnabled = false;
        }
        private void Step3()
        {
            MessageBox.Show("Please select button 'Redo' to redo deleting timetable.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            AddNewTimetable.IsEnabled = false;
            UndoDeleteTimetable.IsEnabled = false;
            RedoDeleteTimetable.IsEnabled = true;
        }
        private void Step4()
        {
            AddNewTimetable.IsEnabled = false;
            UndoDeleteTimetable.IsEnabled = false;
            RedoDeleteTimetable.IsEnabled = false;
            MessageBox.Show("Please select button 'Edit' to edit one timetable.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);     
        }
        private void Step5()
        {
            AddNewTimetable.IsEnabled = true;
            UndoDeleteTimetable.IsEnabled = false;
            RedoDeleteTimetable.IsEnabled = false;
            MessageBox.Show("Please select button 'Add' to add one timetable.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void Step6()
        {
            AddNewTimetable.IsEnabled = false;
            UndoDeleteTimetable.IsEnabled = false;
            RedoDeleteTimetable.IsEnabled = false;
            MessageBox.Show("Congratulations! You have finished timetables tutorial.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            TutorialHomePage.ShowTutorialHomePage();
        }       
        public void AddContent()
        {
            int timetableIndex = 1;

            foreach (Trainline trainline in Data.GetTrainLinesTutorial())
            {
                foreach (Timetable timetable in trainline.Timetables)
                {
                    OneTimetableTutorial oneTimetable = new OneTimetableTutorial(this, Window,timetable, Step);                  
                    addRowPixels(ReadTimetableGrid, oneTimetable.getHeight());
                    Grid.SetRow(oneTimetable, timetableIndex);

                    ReadTimetableGrid.Children.Add(oneTimetable);
                    timetableIndex++;
                }
            }
        }

        private void addRowPixels(Grid grid, double height)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(height);
            ReadTimetableGrid.Height += height + 10;
            grid.RowDefinitions.Add(rd);
        }

        private void AddNewTimetable_Click(object sender, RoutedEventArgs e)
        {
            TutorialHomePage.tutorialFrame.Content = new AddTimetableTutorial(this, Window);
            /*MessageBox.Show("Adding timetable successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Step = "step6";
            RefreshPage();
            DoStep();*/
        }
        public void RefreshPage()
        {
            ReadTimetableGrid.Children.RemoveRange(0, ReadTimetableGrid.Children.Count);
            ReadTimetableGrid.Height = 35;
            AddContent();
        }       
        private void UndoDeleteTimetable_Click(object sender, RoutedEventArgs e)
        {
           
            Data.UndoTutorial();        
            MessageBox.Show("Undo deleting timetable successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);       
            Step = "step3";
            RefreshPage();
            DoStep();
           
        }
        private void RedoDeleteTimetable_Click(object sender, RoutedEventArgs e)
        {
           
            Data.RedoTutorial();
            MessageBox.Show("Redo deleting timetable successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Step = "step4";
            RefreshPage();
            DoStep();

        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpProvider.ShowHelp("ReadTimetable", Window);
        }
    }
}
