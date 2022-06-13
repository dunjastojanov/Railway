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
    /// Interaction logic for AddTimetableTutorial.xaml
    /// </summary>
    public partial class AddTimetableTutorial : Page
    {
        Train chosenTrain;
        Trainline chosenTrainline;
        DateTime chosenStartTime;
        DateTime chosenEndTime;
        Timetable timetable;

        Railway.MainWindow Window { get; set; }
        ReadTimetableTutorial ReadTimetableTutorial { get; set; }
        string Mode { get; set; }
        bool TrainNameChanged { get; set; }
        bool StartTimeChanged { get; set; }
        bool EndTimeChanged { get; set; }
        bool TrainlineChanged { get; set; }

        public string Step { get; set; }
        public AddTimetableTutorial(ReadTimetableTutorial readTimetableTutorial, Railway.MainWindow window)
        {
            Step = "step0";
            Mode = "add";
            TrainNameChanged = false;
            StartTimeChanged = false;
            EndTimeChanged = false;
            TrainlineChanged = false;
            InitializeComponent();
            DisableCheckBoxes();
            Window = window;
            ReadTimetableTutorial = readTimetableTutorial;
            fillTimeComboBox(StartTimeCombo);
            fillTimeComboBox(EndTimeCombo);

            foreach (Train train in Data.GetTrains())
            {
                TrainComboBox.Items.Add(train.Name);
            }

            foreach (Trainline trainline in Data.GetTrainLines())
            {
                TrainlineComboBox.Items.Add(trainline.Name);
            }
            DoStep();
        }

        public AddTimetableTutorial(ReadTimetableTutorial readTimetableTutorial, Railway.MainWindow window, Timetable timetable)
        {
            Step = "step1";
            Mode = "edit";
            TrainNameChanged = false;
            StartTimeChanged = false;
            EndTimeChanged = false;
            this.timetable = timetable;
            ReadTimetableTutorial = readTimetableTutorial;
            InitializeComponent();
            Window = window;
            DisableCheckBoxes();
            fillTimeComboBox(StartTimeCombo);
            fillTimeComboBox(EndTimeCombo);

            StartTimeCombo.SelectedItem = $"{timetable.TimeFromFirstStation.Hour.ToString().PadLeft(2, '0')}:{timetable.TimeFromFirstStation.Minute.ToString().PadLeft(2, '0')}";
            EndTimeCombo.SelectedItem = $"{timetable.TimeFromLastStation.Hour.ToString().PadLeft(2, '0')}:{timetable.TimeFromLastStation.Minute.ToString().PadLeft(2, '0')}";

            foreach (Train train in Data.GetTrains())
            {
                TrainComboBox.Items.Add(train.Name);
            }

            TrainComboBox.SelectedItem = timetable.Train.Name;

            TrainlineComboBox.Visibility = Visibility.Hidden;
            TrainlineLabel.Content = $"Trainline: {timetable.Trainline.Name}";

            if (timetable.Days.Contains("Monday"))
            {
                Monday.IsChecked = true;
            }

            if (timetable.Days.Contains("Tuesday"))
            {
                Tuesday.IsChecked = true;
            }

            if (timetable.Days.Contains("Wednesday"))
            {
                Wednesday.IsChecked = true;
            }

            if (timetable.Days.Contains("Thursday"))
            {
                Thursday.IsChecked = true;
            }
            if (timetable.Days.Contains("Friday"))
            {
                Friday.IsChecked = true;
            }
            if (timetable.Days.Contains("Saturday"))
            {
                Saturday.IsChecked = true;
            }
            if (timetable.Days.Contains("Sunday"))
            {
                Sunday.IsChecked = true;
            }
            DoStep();
        }
        public void DoStep()
        {
           
            if (Mode.Equals("edit"))
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
            else
            {
                if (Step.Equals("step0"))
                    Step0();
                else if (Step.Equals("step1"))
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
           
        }
        private async void Step0()
        {
            await Task.Delay(600);
            MessageBox.Show("Please add trainline for timetable.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            TrainlineComboBox.IsEnabled = true;
            TrainlineComboBox.Foreground = Brushes.OrangeRed;
            TrainComboBox.IsEnabled = false;
            StartTimeCombo.IsEnabled = false;
            EndTimeCombo.IsEnabled = false;
            saveButton.IsEnabled = false;
            TrainlineChanged = true;
        }

        private async void Step1()
        {
            await Task.Delay(600);
            MessageBox.Show("Please " +  Mode + " train name for timetable.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            TrainlineComboBox.IsEnabled = false;
            TrainlineComboBox.Foreground = Brushes.Black;
            TrainComboBox.IsEnabled = true;
            TrainComboBox.Foreground = Brushes.OrangeRed;
            StartTimeCombo.IsEnabled = false;
            EndTimeCombo.IsEnabled = false;
            saveButton.IsEnabled = false;
            TrainNameChanged = true;
        }
        private void Step2()
        {
            MessageBox.Show("Please " + Mode + " start time for timetable.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            TrainComboBox.IsEnabled = false;
            TrainComboBox.Foreground = Brushes.Black;
            StartTimeCombo.IsEnabled = true;
            StartTimeCombo.Foreground = Brushes.OrangeRed;
            EndTimeCombo.IsEnabled = false;
            StartTimeChanged = true;
        }
        private void Step3()
        {
            MessageBox.Show("Please " + Mode + " end time for timetable.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            TrainComboBox.IsEnabled = false;
            StartTimeCombo.IsEnabled = false;
            StartTimeCombo.Foreground = Brushes.Black;
            EndTimeCombo.IsEnabled = true;
            EndTimeCombo.Foreground = Brushes.OrangeRed;
            EndTimeChanged = true;
        }
        private void Step4()
        {
            MessageBox.Show("Please select Monday as day that timetable applies.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            TrainComboBox.IsEnabled = false;
            StartTimeCombo.IsEnabled = false;
            StartTimeCombo.Foreground = Brushes.Black;
            EndTimeCombo.IsEnabled = false;
            EndTimeCombo.Foreground = Brushes.Black;
            Monday.IsEnabled = true;
        }
        private void Step5()
        {
            MessageBox.Show("Please click 'Save' to save timetable.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            DisableCheckBoxes();
            saveButton.IsEnabled = true;    
        }
        private void Step6()
        {
            MessageBox.Show(char.ToUpper(Mode[0]) + Mode.Substring(1, Mode.Length-1) + "ing timetable successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            ReadTimetableTutorial.TutorialHomePage.tutorialFrame.Content = ReadTimetableTutorial;
            if (Mode.Equals("edit"))
                ReadTimetableTutorial.Step = "step5";
            else
                ReadTimetableTutorial.Step = "step6";
            ReadTimetableTutorial.RefreshPage();
            ReadTimetableTutorial.DoStep();
        }
        private void DisableCheckBoxes()
        {
            Monday.IsEnabled = false;
            Tuesday.IsEnabled = false;
            Wednesday.IsEnabled = false;
            Thursday.IsEnabled = false;
            Friday.IsEnabled = false;
            Saturday.IsEnabled = false;
            Sunday.IsEnabled = false;
        }
        private void fillTimeComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            String hours;
            String minutes;
            for (int i = 0; i < 24; i++)
            {
                hours = i.ToString().PadLeft(2, '0');
                for (int j = 0; j < 60; j += 5)
                {
                    minutes = j.ToString().PadLeft(2, '0');

                    comboBox.Items.Add($"{hours}:{minutes}");
                }
            }
        }

        private void MondayChosen_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Choosing Monday as day for which timetable apply successfull.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            Step = "step5";
            DoStep();
        }
        private void TrainComboBox_Selected(object sender, RoutedEventArgs e)
        {
            chosenTrain = Data.GetTrain(TrainComboBox.SelectedItem.ToString());
            if (TrainNameChanged)
            {
                MessageBox.Show("Train name for timetable " + Mode + "ed successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                Step = "step2";
                DoStep();
            }
        }

        private void TrainlineComboBox_Selected(object sender, RoutedEventArgs e)
        {
            chosenTrainline = Data.GetTrainLine(TrainlineComboBox.SelectedItem.ToString());
            if (TrainlineChanged)
            {
                MessageBox.Show("Trainline for timetable added successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                Step = "step1";
                DoStep();
            }
        }

        private void StartTimeCombo_Selected(object sender, RoutedEventArgs e)
        {
            int hour = Int32.Parse(StartTimeCombo.SelectedItem.ToString().Split(':')[0]);
            int minute = Int32.Parse(StartTimeCombo.SelectedItem.ToString().Split(':')[1]);

            chosenStartTime = new DateTime(2000, 1, 1, hour, minute, 0);
            if (StartTimeChanged)
            {
                MessageBox.Show("Start time for timetable " + Mode + "ed successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                Step = "step3";
                DoStep();
            }

        }

        private void EndTimeCombo_Selected(object sender, RoutedEventArgs e)
        {
            int hour = Int32.Parse(EndTimeCombo.SelectedItem.ToString().Split(':')[0]);
            int minute = Int32.Parse(EndTimeCombo.SelectedItem.ToString().Split(':')[1]);

            chosenEndTime = new DateTime(2000, 1, 1, hour, minute, 0);
            if (EndTimeChanged)
            {
                MessageBox.Show("End time for timetable " + Mode +"ed successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                Step = "step4";
                DoStep();
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            String messages = "";

            if (Monday.IsChecked == false && Tuesday.IsChecked == false && Wednesday.IsChecked == false && Friday.IsChecked == false && Saturday.IsChecked == false && Sunday.IsChecked == false)
            {
                messages += "You must choose at least one day.\n";
            }

            if (chosenStartTime == null)
            {
                messages += "You must choose time from the first station.\n";
            }

            if (chosenEndTime == null)
            {
                messages += "You must choose time from the last station back.\n";
            }

            if (chosenTrain == null)
            {
                messages += "You must choose a train.\n";
            }

            if (timetable == null && chosenTrainline == null)
            {
                messages += "You must choose a trainline.\n";
            }


            if (messages == "")
            {
                List<string> days = getDays();

                string daysString = "";

                foreach (string day in days)
                {
                    daysString += day + " ";
                }


                string Route;

                if (timetable == null)
                {
                    Route = chosenTrainline.Name;
                }
                else
                {
                    Route = timetable.Trainline.Name;
                }


                string parameters = $"Train: {chosenTrain.Name}\nRoute:{Route}\n" +
                    $"Time from first station: {chosenStartTime.Hour.ToString().PadLeft(2, '0')}:{chosenStartTime.Minute.ToString().PadLeft(2, '0')}\n" +
                    $"Time from last station back: {chosenEndTime.Hour.ToString().PadLeft(2, '0')}:{chosenEndTime.Minute.ToString().PadLeft(2, '0')}\n" +
                    daysString;

                if (timetable == null)
                { 
                   Data.AddTimetable(chosenTrain, chosenTrainline, chosenStartTime, chosenEndTime, days);
                   Step = "step6";
                   DoStep();
                }
                else
                {
                    
                    Data.editTimetable(chosenTrain, chosenStartTime, chosenEndTime, days, timetable);
                    /*int ok = (int)MessageBox.Show("Timetable successfully edited!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    Window.ShowReadTimetable(true);*/
                    Step = "step6";
                    DoStep();
                    
                }
            }
            else
            {
                MessageBox.Show(messages, "Invalid paramaters", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private List<string> getDays()
        {
            List<string> days = new List<string>();
            if (Monday.IsChecked == true)
            {
                days.Add("Monday");
            }
            if (Tuesday.IsChecked == true)
            {
                days.Add("Tuesday");
            }
            if (Wednesday.IsChecked == true)
            {
                days.Add("Wednesday");
            }
            if (Thursday.IsChecked == true)
            {
                days.Add("Thursday");
            }
            if (Friday.IsChecked == true)
            {
                days.Add("Friday");
            }
            if (Saturday.IsChecked == true)
            {
                days.Add("Saturday");
            }
            if (Sunday.IsChecked == true)
            {
                days.Add("Sunday");
            }

            return days;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window.ShowReadTimetable(true);
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpProvider.ShowHelp("AddTimetable", Window); if (timetable != null)
            {
                HelpProvider.ShowHelp("EditTimetable", Window);
            }
            else
            {
                HelpProvider.ShowHelp("AddTimetable", Window);
            }
        }
    }
}
