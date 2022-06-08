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
    /// Interaction logic for AddTimetable.xaml
    /// </summary>
    /// 



    public partial class AddTimetable : Page
    {
        Train chosenTrain;
        Trainline chosenTrainline;
        DateTime chosenStartTime;
        DateTime chosenEndTime;
        Timetable timetable;

        Railway.MainWindow Window { get; set; }
        public AddTimetable(Railway.MainWindow window)
        {
            InitializeComponent();
            Window = window;
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

        }

        public AddTimetable(Railway.MainWindow window, Timetable timetable)
        {
            this.timetable = timetable;
            InitializeComponent();
            Window = window;
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

        private void TrainComboBox_Selected(object sender, RoutedEventArgs e)
        {
            chosenTrain = Data.GetTrain(TrainComboBox.SelectedItem.ToString());
        }

        private void TrainlineComboBox_Selected(object sender, RoutedEventArgs e)
        {
            chosenTrainline = Data.GetTrainLine(TrainlineComboBox.SelectedItem.ToString());
        }

        private void StartTimeCombo_Selected(object sender, RoutedEventArgs e)
        {
            int hour = Int32.Parse(StartTimeCombo.SelectedItem.ToString().Split(':')[0]);
            int minute = Int32.Parse(StartTimeCombo.SelectedItem.ToString().Split(':')[1]);

            chosenStartTime = new DateTime(2000, 1, 1, hour, minute, 0);

        }

        private void EndTimeCombo_Selected(object sender, RoutedEventArgs e)
        {
            int hour = Int32.Parse(EndTimeCombo.SelectedItem.ToString().Split(':')[0]);
            int minute = Int32.Parse(EndTimeCombo.SelectedItem.ToString().Split(':')[1]);

            chosenEndTime = new DateTime(2000, 1, 1, hour, minute, 0);

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            String messages = "";

            if (Monday.IsChecked == false && Tuesday.IsChecked == false && Wednesday.IsChecked == false && Friday.IsChecked == false && Saturday.IsChecked == false && Sunday.IsChecked==false)
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

                    int response = (int)MessageBox.Show("Are you sure you want to add a timetable with these parameters?\n" + parameters, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (response == 6)
                    {
                        Data.AddTimetable(chosenTrain, chosenTrainline, chosenStartTime, chosenEndTime, days);
                        int ok = (int)MessageBox.Show("Timetable successfully added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window.ShowReadTimetable(true);
                    }
                    else
                    {
                        MessageBox.Show("Timetable addition cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    int response = (int)MessageBox.Show("Are you sure you want to edit a timetable with these parameters?\n" + parameters, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (response == 6)
                    {
                        Data.editTimetable(chosenTrain, chosenStartTime, chosenEndTime, days, timetable);
                        int ok = (int)MessageBox.Show("Timetable successfully edited!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window.ShowReadTimetable(true);
                    }
                    else
                    {
                        MessageBox.Show("Timetable editing cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
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
    }
}
