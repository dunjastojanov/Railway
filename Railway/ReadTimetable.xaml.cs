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
        public ReadTimetable(Railway.MainWindow window)
        {
            InitializeComponent();
            Window = window;
            TryDisableUndoRedo();

            AddContent();
        }

        public void AddContent()
        {
            int timetableIndex = 1;

            foreach (Trainline trainline in Data.GetTrainLines())
            {
                foreach (Timetable timetable in trainline.Timetables)
                {
                    OneTimetable oneTimetable = new OneTimetable(Window.MainFrame, timetable);
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
            grid.RowDefinitions.Add(rd);
        }

        private void AddNewTimetable_Click(object sender, RoutedEventArgs e)
        {

        }
        public void RefreshPage()
        {
            TryDisableUndoRedo();
            ReadTimetableGrid.Children.RemoveRange(0, ReadTimetableGrid.Children.Count);
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
                MessageBox.Show("Undo deleting train route cancelled.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void RedoDeleteTimetable_Click(object sender, RoutedEventArgs e)
        {
            int response = (int)MessageBox.Show("Are you sure you want to redo deleting train route?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                Data.Redo();
                RefreshPage();
            }
            else
            {
                MessageBox.Show("Redo deleting train route cancelled.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
