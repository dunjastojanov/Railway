using Railway.model;
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
    /// Interaction logic for AddTrainTutorial.xaml
    /// </summary>
    public partial class AddTrainTutorial : Page
    {
        private Train train;
        Seats chosenSeats;
        
        private int Step;
        private bool numberOfWagonsChanged { get; set; }
        private bool numberOfWagonsIncorrect { get; set; }
        public bool nameChanged { get; set; }

        List<Button> buttons;
        int numberOfWagons { get; set; }
        String name { get; set; }

        Railway.MainWindow Window { get; set; }
        ReadTrainTutorial readTrainTutorial;
        public AddTrainTutorial(MainWindow window, ReadTrainTutorial readTrainTutorial)
        {
            InitializeComponent();
            this.readTrainTutorial = readTrainTutorial;
            Window = window;
            buttons = new List<Button>();
            NameTextBox.IsEnabled = false;
            NumberOfWagonsTextBox.IsEnabled = false;
            addRowPixels(SeatsGrid, 360);
            addSeats();
            nameChanged = false;
            numberOfWagonsChanged = false;
            numberOfWagonsIncorrect = false;
            
            Step = 1;
            DoStep();

        }

        public AddTrainTutorial(MainWindow window, Train train, ReadTrainTutorial readTrainTutorial)
        {
            
            InitializeComponent();

            buttons = new List<Button>();
            this.train = train;
            this.readTrainTutorial = readTrainTutorial;
            Window = window;
            
            NameTextBox.IsEnabled = false;
            NumberOfWagonsTextBox.IsEnabled = false;
            nameChanged = true;
            NameTextBox.Text = train.Name;
            nameChanged = false;

            numberOfWagonsChanged = true;
            NumberOfWagonsTextBox.Text = train.seats.numberOfWagons.ToString();
            numberOfWagonsChanged = false;
            numberOfWagonsIncorrect = false;

            chosenSeats = train.seats;           
            SeatDistributionLabel.Content = $"Seat distribution: Number of rows: { train.seats.numberOfSeatsPerColumn}\tNumber of Columns: { train.seats.numberOfColumns}";           
            addRowPixels(SeatsGrid, 360);  
            addSeats();

            Step = 1;
            DoStep();
        }

        private void addSeats()
        {
            int seatIndex = 0;

            int lastColumn = 1;
            int lastRow = 0;

            Seats seats;
            int Column = -1;
            int Row;

            while (seatIndex < Data.seats.Count)
            {
                seats = Data.seats[seatIndex];
                if (seatIndex % 3 == 0)
                {
                    Column = 1;
                }
                else if (seatIndex % 3 == 1)
                {
                    Column = 3;
                }
                else if (seatIndex % 3 == 2)
                {
                    Column = 5;
                }

                if (lastColumn == 5 && Column == 1)
                {
                    addRowPixels(SeatsGrid, 5);
                    addRowPixels(SeatsGrid, 360);
                    lastRow += 2;
                }

                lastColumn = Column;

                Row = lastRow;

                Grid grid = new Grid();

                addRowPixels(grid, 60);
                addRowPixels(grid, 380);

                Button button = new Button();
                button.Click += choseSeats;
                button.Content = $"Number of rows: {seats.numberOfSeatsPerColumn}\nNumber of Columns: {seats.numberOfColumns}";
                button.ToolTip = "Seat distribution chart type.";
                button.Foreground = Brushes.White;
                button.FontSize = 14;
                button.Margin = new Thickness(0, 0, 0, 0);
                
                button.IsEnabled = false;

                buttons.Add(button);
              
                Grid.SetRow(button, 0);
                grid.Children.Add(button);

                TrainSeats trainSeats = new TrainSeats(seats, -1);
                Grid.SetRow(trainSeats, 1);
                grid.Children.Add(trainSeats);

                Grid.SetColumn(grid, Column);
                Grid.SetRow(grid, Row);
                SeatsGrid.Children.Add(grid);

                seatIndex++;

            }
        }

        private void choseSeats(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            String text = (string)button.Content;

            string numberOfRowsString = text.Split('\n')[0];
            int numberOfRows = Int32.Parse(numberOfRowsString.Split(':')[1].Substring(1));
            string numberOfColumnsString = text.Split('\n')[1];

            int numberOfColums = Int32.Parse(numberOfColumnsString.Split(':')[1].Substring(1));
            text = $"Seat distribution: {numberOfRowsString}\t{numberOfColumnsString}";

            chosenSeats = new Seats(1, numberOfColums, numberOfRows);

            MessageBox.Show($"You have chosen seat distribution with {numberOfRows} rows and {numberOfColums} columns.", "Seat distribution", MessageBoxButton.OK, MessageBoxImage.Information);

            SeatDistributionLabel.Content = text;

            Step = 4;
            DoStep();


        }

        private void addRowPixels(Grid grid, double height)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(height);
            grid.RowDefinitions.Add(rd);
        }

        private void enableButtons(bool enable)
        {
            foreach (Button button in buttons)
            {
                button.IsEnabled = enable;
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

            String messages = "";

            if (chosenSeats == null)
            {
                messages += $"You must chose a seat chart.\n";
            }



            name = NameTextBox.Text;
            String numberOfWagonsString = NumberOfWagonsTextBox.Text;


            if (name == "")
            {
                messages += $"You must type in the name.\n";

            }

            if (numberOfWagonsString == "")
            {
                messages += $"You must type in the number of wagons.\n";
                NumberOfWagonsTextBox.IsEnabled = true;
                numberOfWagonsIncorrect = true;
            }
            else
            {
                try
                {
                    numberOfWagons = Int32.Parse(numberOfWagonsString);
                }
                catch (Exception)
                {
                    messages += $"Number of wagons must be a number.\n";
                }
            }
            String parameters = "";
            if (chosenSeats != null)
            {
                parameters = $"Name: {name}\nNumber of wagons: {numberOfWagons}\nNumber of rows per wagon: {chosenSeats.numberOfSeatsPerColumn}\nNumber of columns per wagon: {chosenSeats.numberOfColumns}";

            }

            if (messages == "")
            {
                if (train == null)
                {
                    MessageBox.Show("Train successfully added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    readTrainTutorial.RefreshPage();
                    readTrainTutorial.Step = 6;
                    readTrainTutorial.DoStep();

                }
                else
                {

                    Data.editTrainTutorial(chosenSeats, name, numberOfWagons, train);
                    MessageBox.Show("Train successfully edited!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    readTrainTutorial.RefreshPage();
                    readTrainTutorial.Step = 5;
                    readTrainTutorial.DoStep();


                }
            }
            else
            {
                MessageBox.Show(messages, "Inadequate parameters", MessageBoxButton.OK, MessageBoxImage.Error);
                if (messages == $"Number of wagons must be a number.\n")
                {
                    MessageBox.Show("Please fill in number of wagons correctly and click on the save button again.","Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    NumberOfWagonsTextBox.Text = "";
                    NumberOfWagonsTextBox.IsEnabled = true;
                    NumberOfWagonsTextBox.Focus();
                }
            }
        }

        public async Task Step1Async(){
            await Task.Delay(600);
            NameTextBox.IsEnabled = true;
            NumberOfWagonsTextBox.IsEnabled = false;
            MessageBox.Show("Please fill in name of the train.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBox.Show("Name must have at least five characters in this tutorial.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            NameTextBox.Focus();
        }
        public void Step2(){
            NameTextBox.IsEnabled = false;
            NumberOfWagonsTextBox.IsEnabled = true;
            MessageBox.Show("Please fill in number of wagons of the train.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            NumberOfWagonsTextBox.Focus();
        }
        public void Step3(){
            enableButtons(true);
            NameTextBox.IsEnabled = false;
            NumberOfWagonsTextBox.IsEnabled = false;
            MessageBox.Show("Please select seat distribution of the train.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        public void Step4(){
            enableButtons(false);
            NameTextBox.IsEnabled = false;
            NumberOfWagonsTextBox.IsEnabled = false;
            MessageBox.Show("Please select save button.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void DoStep()
        {
            switch (Step)
            {
                case 1:
                    {
                        Step1Async();
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


            }


        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameTextBox.Text.Length > 4 && !nameChanged)
            {
                nameChanged = true;
                Step = 2;
                DoStep();
            }
        }

        private void NumberOfWagonsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NumberOfWagonsTextBox.Text.Length > 0 && !numberOfWagonsChanged && !numberOfWagonsIncorrect)
            {
                numberOfWagonsChanged = true;
                Step = 3;
                
                DoStep();
            }

        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            if (train != null)
            {
                HelpProvider.ShowHelp("EditTrain", Window);
            }
            else
            {
                HelpProvider.ShowHelp("AddTrain", Window);
            }
        }
    }
}
