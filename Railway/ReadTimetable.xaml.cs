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
    /// Interaction logic for ReadTimetable.xaml
    /// </summary>
    public partial class ReadTimetable : Page
    {
        private Railway.MainWindow Window;
        string User { get; set; }
        public ReadTimetable(Railway.MainWindow window)
        {
            InitializeComponent();
            Window = window;
            User = null;
            TryDisableUndoRedo();

            AddContent();
        }

        public ReadTimetable(Railway.MainWindow window, string user)
        {
            InitializeComponent();
            Window = window;
            User = user;
            MainGrid.Children.Clear();
            Grid.SetRow(ReadTrainRouteScrollViewer, 0);
            Grid.SetRowSpan(ReadTrainRouteScrollViewer, 2);
            MainGrid.Children.Add(ReadTrainRouteScrollViewer);
            AddContent();
        }

        public void AddContent()
        {
            int timetableIndex = 1;

            foreach (Trainline trainline in Data.GetTrainLines())
            {
                foreach (Timetable timetable in trainline.Timetables)
                {
                    OneTimetable oneTimetable;
                    if (User == null)
                        oneTimetable = new OneTimetable(Window, timetable);
                    else
                        oneTimetable = new OneTimetable(Window, timetable, "user");
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
            TryDisableUndoRedo();
            ReadTimetableGrid.Height = 35;
            AddContent();
        }
        private void TryDisableUndoRedo()
        {
            if (!Data.NeedUndo())
                UndoDeleteTimetable.IsEnabled = false;
            else
                UndoDeleteTimetable.IsEnabled = true;
            if (!Data.NeedRedo())
                RedoDeleteTimetable.IsEnabled = false;
            else
                RedoDeleteTimetable.IsEnabled = true;
        }

        private void UndoDeleteTimetable_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to undo deleting train route?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Data.Undo();
                RefreshPage();
            }
            else
            {
                MessageBox.Show("Undo deleting timetable cancelled.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void RedoDeleteTimetable_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to redo deleting timetable?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Data.Redo();
                RefreshPage();
            }
            else
            {
                MessageBox.Show("Redo deleting timetable cancelled.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpProvider.ShowHelp("ReadTimetable", Window);
        }
    }
}
