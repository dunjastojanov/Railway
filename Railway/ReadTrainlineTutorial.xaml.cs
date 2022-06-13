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

    public partial class ReadTrainlineTutorial : Page
    {
        public TutorialHomePage TutorialHomePage { get; set; }
        private Railway.MainWindow window { get; set; }
        string User { get; set; }
        public int Step;
        public ReadTrainlineTutorial(TutorialHomePage TutorialHomePage, Railway.MainWindow mainWindow)
        {
            this.TutorialHomePage = TutorialHomePage;
            this.window = mainWindow;
            InitializeComponent();
            User = null;

            UndoDeleteTrainRoute.IsEnabled = false;
            RedoDeleteTrainRoute.IsEnabled = false;
            AddNewTrainRoute.IsEnabled = false;

            AddContent();
            Step = 1;
            DoStep();
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
                case 6:
                    {
                        Step6();
                        break;
                    }
            }

        }

        public async void Step1() {
            await Task.Delay(600);

            RefreshPage();
            UndoDeleteTrainRoute.IsEnabled = false;
            RedoDeleteTrainRoute.IsEnabled = false;
            AddNewTrainRoute.IsEnabled = false;
            MessageBox.Show("Please select button 'Delete' to delete one trainline.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void Step2() {
            RefreshPage();
            UndoDeleteTrainRoute.IsEnabled = true;
            RedoDeleteTrainRoute.IsEnabled = false;
            AddNewTrainRoute.IsEnabled = false;
            MessageBox.Show("Please select button 'Undo' to undo deleting trainline.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void Step3() {
            RefreshPage();
            UndoDeleteTrainRoute.IsEnabled = false;
            RedoDeleteTrainRoute.IsEnabled = true;
            AddNewTrainRoute.IsEnabled = false;
            MessageBox.Show("Please select button 'Redo' to redo deleting trainline.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void Step4() {
            RefreshPage();
            UndoDeleteTrainRoute.IsEnabled = false;
            RedoDeleteTrainRoute.IsEnabled = false;
            AddNewTrainRoute.IsEnabled = false;
            MessageBox.Show("Please select button 'Edit' to edit one trainline.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void Step5() {
            RefreshPage();
            UndoDeleteTrainRoute.IsEnabled = false;
            RedoDeleteTrainRoute.IsEnabled = false;
            AddNewTrainRoute.IsEnabled = true;
            MessageBox.Show("Please select button 'Add New Trainline' to add new trainline.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void Step6() {
            RefreshPage();
            UndoDeleteTrainRoute.IsEnabled = false;
            RedoDeleteTrainRoute.IsEnabled = false;
            AddNewTrainRoute.IsEnabled = false;
            MessageBox.Show("Congratulations! You have finished trainlines tutorial.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            TutorialHomePage.ShowTutorialHomePage();
        }

        public void AddContent()
        {
            int trainlineIndex = 1;

            foreach (Trainline trainline in Data.GetTrainLinesTutorial())
            {
                OneTrainlineTutorial oneTrainRoute;
                
                oneTrainRoute = new OneTrainlineTutorial(trainline, window, this);

                addRowPixels(ReadTrainRouteGrid, oneTrainRoute.getHeight());
                Grid.SetRow(oneTrainRoute, trainlineIndex);

                ReadTrainRouteGrid.Children.Add(oneTrainRoute);
                trainlineIndex++;
            }
        }

        private void addRowPixels(Grid grid, double height)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(height);
            ReadTrainRouteGrid.Height += height + 10;
            grid.RowDefinitions.Add(rd);
        }

        private void AddNewTrainRoute_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Content = new AddTrainlineTutorial(window, this);
        }

        public void RefreshPage()
        {
            ReadTrainRouteGrid.Children.RemoveRange(0, ReadTrainRouteGrid.Children.Count);
            ReadTrainRouteGrid.Height = 0;
            AddContent();
        }

        private void UndoDeleteTrainRoute_Click(object sender, RoutedEventArgs e)
        {
            Data.UndoTutorial();
            Step = 3;
            DoStep();
        }
        private void RedoDeleteTrainRoute_Click(object sender, RoutedEventArgs e)
        {
            Data.RedoTutorial();
            Step = 4;
            DoStep();
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpProvider.ShowHelp("ReadTrainline", window);
        }

    }
}
