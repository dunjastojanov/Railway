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
        private Railway.MainWindow Window;
        string User { get; set; }
        public string Step { get; set; }
        public ReadTimetableTutorial(Railway.MainWindow window)
        {
            Step = "step1";
            InitializeComponent();
            Window = window;
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
        }     
        private async void Step1()
        {
            await Task.Delay(600);
            AddNewTimetable.IsEnabled = false;
            UndoDeleteTimetable.IsEnabled = false;
            RedoDeleteTimetable.IsEnabled = false;
            MessageBox.Show("Please select button 'Delete' to delete one trainline.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Step2()
        {
            MessageBox.Show("Please select button 'Undo' to undo deleting trainline.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            AddNewTimetable.IsEnabled = false;
            UndoDeleteTimetable.IsEnabled = true;
            RedoDeleteTimetable.IsEnabled = false;
        }
        private void Step3()
        {
            MessageBox.Show("Please select button 'Redo' to redo deleting trainline.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            AddNewTimetable.IsEnabled = false;
            UndoDeleteTimetable.IsEnabled = false;
            RedoDeleteTimetable.IsEnabled = true;
        }
        private void Step4()
        {
            AddNewTimetable.IsEnabled = false;
            UndoDeleteTimetable.IsEnabled = false;
            RedoDeleteTimetable.IsEnabled = false;
            MessageBox.Show("Please select button 'Edit' to edit one trainline.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);     
        }
        public ReadTimetableTutorial(Railway.MainWindow window, string user)
        {
            InitializeComponent();
            Window = window;
            User = user;
            MainGridTutorial.Children.Clear();
            Grid.SetRow(ReadTrainRouteScrollViewer, 0);
            Grid.SetRowSpan(ReadTrainRouteScrollViewer, 2);
            MainGridTutorial.Children.Add(ReadTrainRouteScrollViewer);
            AddContent();
        }

        public void AddContent()
        {
            int timetableIndex = 1;

            foreach (Trainline trainline in Data.GetTrainLinesTutorial())
            {
                foreach (Timetable timetable in trainline.Timetables)
                {
                    OneTimetableTutorial oneTimetable = new OneTimetableTutorial(this, Window, timetable, Step);                  
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
            Window.Frame.Content = new AddTimetable(Window);
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
            MessageBox.Show("Undo deleting trainline successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);       
            Step = "step3";
            RefreshPage();
            DoStep();
           
        }
        private void RedoDeleteTimetable_Click(object sender, RoutedEventArgs e)
        {
           
            Data.RedoTutorial();
            MessageBox.Show("Redo deleting trainline successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
