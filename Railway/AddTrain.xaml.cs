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
    /// Interaction logic for AddTrain.xaml
    /// </summary>
    public partial class AddTrain : Page
    {

        Seats chosenSeats;
        Train train;

        int numberOfWagons { get; set; }
        String name { get; set; }

        Railway.MainWindow Window { get; set; }

        public AddTrain(Railway.MainWindow window)
        {
            InitializeComponent();
            Window = window;
            addRowPixels(SeatsGrid, 360);
            addSeats();
        }

        public AddTrain(Railway.MainWindow window, Train train)
        {
            InitializeComponent();
            Window = window;

            this.train = train;

            name = train.Name;
            numberOfWagons = train.seats.numberOfWagons;

            NameTextBox.Text = name;
            NumberOfWagonsTextBox.Text = numberOfWagons.ToString();

            chosenSeats = train.seats;

            addRowPixels(SeatsGrid, 360);
            addSeats();
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
                addRowPixels(grid, 300);

                Button button = new Button();
                button.Click += choseSeats;
                button.Content = $"Number of rows: {seats.numberOfSeatsPerColumn}\nNumber of Columns: {seats.numberOfColumns}";
                button.Foreground = Brushes.White;
                button.Background = Brushes.Black;
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


        private void addRowPixels(Grid grid, double height)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(height);
            grid.RowDefinitions.Add(rd);
        }



        private void addColumnPixels(Grid grid, double width)
        {
            var cd = new ColumnDefinition();
            cd.Width = new GridLength(width);
            grid.ColumnDefinitions.Add(cd);
        }

        private void choseSeats(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            String text = (string)button.Content;

            string numberOfRowsString = text.Split('\n')[0];
            int numberOfRows = Int32.Parse(numberOfRowsString.Split(':')[1].Substring(1));
            string numberOfColumnsString = text.Split('\n')[1];

            int numberOfColums = Int32.Parse(numberOfColumnsString.Split(':')[1].Substring(1));
            text = $"Seat distribution: {numberOfRowsString} {numberOfColumnsString}";

            chosenSeats = new Seats(1, numberOfColums, numberOfRows);

            MessageBox.Show($"You have chosen seat distribution with {numberOfRows} rows and {numberOfColums} columns.");

            SeatDistributionLabel.Content = text;


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
                    int response = (int)MessageBox.Show("Are you sure you want to add a train with these parameters?\n" + parameters, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (response == 6)
                    {

                        Data.AddTrain(chosenSeats, name, numberOfWagons);
                        int ok = (int)MessageBox.Show("Train successfully added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window.ShowReadTrain(true);
                    }
                    else
                    {
                        MessageBox.Show("Train addition cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    int response = (int)MessageBox.Show("Are you sure you want to edit a train with these parameters?\n" + parameters, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (response == 6)
                    {
                        Data.editTrain(chosenSeats, name, numberOfWagons, train);
                        int ok = (int)MessageBox.Show("Train successfully edited!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window.ShowReadTrain(true);
                    }
                    else
                    {
                        MessageBox.Show("Train editing cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show(messages, "Inadequate parameters", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (train == null)
            {
                int response = (int)MessageBox.Show("Are you sure you want to cancel adding a train?\n", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (response == 6)
                {

                    MessageBox.Show("Train addition cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    Window.ShowReadTrain(true);
                }
            }
            else
            {
                int response = (int)MessageBox.Show("Are you sure you want to cancel editing a train?\n", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (response == 6)
                {
                    MessageBox.Show("Train addition cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    Window.ShowReadTrain(true);
                }

            }
        }
    }
}
