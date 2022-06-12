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
    /// Interaction logic for ReadTrainTutorial.xaml
    /// </summary>
    public partial class ReadTrainTutorial : Page
    {
        private Railway.MainWindow Window;
        public TutorialHomePage TutorialHomePage { get; set; }
        public int Step { get; set; }
        string User { get; set; }


        public ReadTrainTutorial(TutorialHomePage thp, Railway.MainWindow window)
        {
            InitializeComponent();
            TutorialHomePage = thp;
            Window = window;
            Step = 1;
            UndoDeleteTrain.IsEnabled = false;
            RedoDeleteTrain.IsEnabled = false;
            AddNewTrain.IsEnabled = false;
           
            AddContent();
            DoStep();
           
        }

        private void AddContent()
        {
            int trainIndex = 1;

            foreach (Train train in Data.GetTrainsTutorial())
            {
                OneTrainTutorial oneTrain = new OneTrainTutorial(train, Window, Step, this);

                addRowPixels(ReadTrainGrid, oneTrain.getHeight());

                Grid.SetRow(oneTrain, trainIndex);

                ReadTrainGrid.Children.Add(oneTrain);
                trainIndex++;
            }
        }



        public void DoStep()
        {
            switch (Step)
            {
                case 1:
                    {
                        Step1();
                        break;
                    }
                case 2:
                    {
                        Step2();
                        break;
                    }
                case 3:
                    {
                        Step3();
                        break;
                    }
                case 4:
                    {
                        Step4();
                        break;
                    }
                case 5:
                    {
                        Step5();
                        break;

                    }
            }


        }

        private async Task Step1() {
            await Task.Delay(600);
            UndoDeleteTrain.IsEnabled = false;
            RedoDeleteTrain.IsEnabled = false;
            AddNewTrain.IsEnabled = false;
            MessageBox.Show("Please select button 'Delete' to delete one train.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    
        private void Step2() {
            UndoDeleteTrain.IsEnabled = true;
            RedoDeleteTrain.IsEnabled = false;
            AddNewTrain.IsEnabled = false;
            MessageBox.Show("Please select button 'Undo' to undo deleting train.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    
        private void Step3() {
            UndoDeleteTrain.IsEnabled = false;
            RedoDeleteTrain.IsEnabled = true;
            AddNewTrain.IsEnabled = false;
            MessageBox.Show("Please select button 'Undo' to undo deleting train.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    
        private void Step4() {
            UndoDeleteTrain.IsEnabled = false;
            RedoDeleteTrain.IsEnabled = false;
            AddNewTrain.IsEnabled = false;
            MessageBox.Show("Please select button 'Edit' to edit one train.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    
        private void Step5() {
            UndoDeleteTrain.IsEnabled = false;
            RedoDeleteTrain.IsEnabled = false;
            AddNewTrain.IsEnabled = true;
            MessageBox.Show("Please select button 'Add New Train' to add new train.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    
        private void Step6() {
            UndoDeleteTrain.IsEnabled = false;
            RedoDeleteTrain.IsEnabled = false;
            AddNewTrain.IsEnabled = false;
            MessageBox.Show("Congratulations! You have finished trains tutorial.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            TutorialHomePage.ShowTutorialHomePage();
        }
    
    


        private void addRowPixels(Grid grid, double height)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(height);
            ReadTrainGrid.Height += height + 10;
            grid.RowDefinitions.Add(rd);
        }

        private void AddNewTrain_Click(object sender, RoutedEventArgs e)
        {
            //Window.MainFrame.Content = new AddTrainTutorial(Window);
        }
        public void RefreshPage()
        {
            ReadTrainGrid.Children.RemoveRange(0, ReadTrainGrid.Children.Count);
            ReadTrainGrid.Height = 35;

            UndoDeleteTrain.IsEnabled = false;
            RedoDeleteTrain.IsEnabled = false;
            AddNewTrain.IsEnabled = false;

            AddContent();
        }


        private void UndoDeleteTrain_Click(object sender, RoutedEventArgs e)
        {
            Data.UndoTutorial();
            MessageBox.Show("Undo deleting train successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Step = 3;
            RefreshPage();
            DoStep();

        }
        private void RedoDeleteTrain_Click(object sender, RoutedEventArgs e)
        {
            Data.RedoTutorial();
            MessageBox.Show("Redo deleting train successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Step = 4;
            RefreshPage();
            DoStep();

        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpProvider.ShowHelp("ReadTrain", Window);
        }
    }
}
