using Railway.model;
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
    /// Interaction logic for ChooseTrainSeats.xaml
    /// </summary>
    public partial class ChooseTrainSeats : Page
    {
        List<TicketSeat> TakenSeats { get; set; }
        ChooseSeat ChooseSeat { get; set; }
        public ChooseTrainSeats(ChooseSeat chooseSeat ,Seats seats, int wagonNumber, List<TicketSeat> takenSeats)
        {
            InitializeComponent();
            TakenSeats = takenSeats;
            ChooseSeat = chooseSeat;

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            int firstColumRows = seats.numberOfColumns / 2;

            addColumnPixels(TrainGrid, 5);

            for (int i = 0; i < seats.numberOfColumns + 1; i++)
            {
                addColumnStars(TrainGrid, 1);
            }

            addColumnPixels(TrainGrid, 5);
            addRowPixels(TrainGrid, 5);
            for (int i = 0; i < seats.numberOfSeatsPerColumn; i++)
            {
                addRowPixels(TrainGrid, 20);
            }
            addRowPixels(TrainGrid, 5);

            for (int i = 1; i <= seats.numberOfSeatsPerColumn; i++)
            {
                for (int j = 0; j < firstColumRows; j++)
                {
                    SeatButton seatButton = new SeatButton(wagonNumber, alpha[j], i);
                    if (SeatTaken(wagonNumber, alpha[j], i) || SeatChosen(wagonNumber, alpha[j], i))
                        seatButton.IsEnabled = false;
                    else
                    {
                        seatButton.Tag = new TicketSeat(wagonNumber, alpha[j], i);
                        seatButton.Click += selectSeat_Click;
                    }
                    Grid.SetColumn(seatButton, j + 1);
                    Grid.SetRow(seatButton, i);

                    TrainGrid.Children.Add(seatButton);

                }

                for (int j = firstColumRows + 1; j <= seats.numberOfColumns; j++)
                {
                    SeatButton seatButton = new SeatButton(wagonNumber, alpha[j], i);
                    if (SeatTaken(wagonNumber, alpha[j], i) || SeatChosen(wagonNumber, alpha[j], i))
                        seatButton.IsEnabled = false;
                    else
                    {
                        seatButton.Tag = new TicketSeat(wagonNumber, alpha[j], i);
                        seatButton.Click += selectSeat_Click;
                    }
                    Grid.SetColumn(seatButton, j + 1);
                    Grid.SetRow(seatButton, i);

                    TrainGrid.Children.Add(seatButton);
                }
            }

        }

        private void selectSeat_Click(object sender, RoutedEventArgs e)
        {

            if (ChooseSeat.SeatToTake == 0)
                MessageBox.Show("You have chosen your seats. If you are satisfied press save, otherwise cancel and try again.", "Seats have been chosen", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                int response = (int)MessageBox.Show("Are you sure you want to choose seat?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (response == 6)
                {
                    MessageBox.Show("Seat is successfully chosen.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    Button chosenButton = (Button)sender;
                    TicketSeat seat = (TicketSeat)chosenButton.Tag;
                    ChooseSeat.ChosenSeats.Add(seat);
                    ChooseSeat.DecreaseSeats();
                    chosenButton.Background = Brushes.Blue;
                    chosenButton.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("Choosing seat cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }
        private bool SeatTaken(int wagon, char column, int row)
        {
            foreach (TicketSeat takenSeat in TakenSeats)
            {
                if (takenSeat.Wagon == wagon && takenSeat.Column == column && takenSeat.Row == row)
                    return true;
            }
            return false;
        }
        private bool SeatChosen(int wagon, char column, int row)
        {
            foreach (TicketSeat takenSeat in ChooseSeat.ChosenSeats)
            {
                if (takenSeat.Wagon == wagon && takenSeat.Column == column && takenSeat.Row == row)
                    return true;
            }
            return false;
        }
        private void addRowPixels(Grid grid, double height)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(height);
            grid.RowDefinitions.Add(rd);
        }

        private void addRowStars(Grid grid, double stars)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(stars, GridUnitType.Star);
            grid.RowDefinitions.Add(rd);
        }

        private void addColumnStars(Grid grid, double stars)
        {
            var cd = new ColumnDefinition();
            cd.Width = new GridLength(stars, GridUnitType.Star);
            grid.ColumnDefinitions.Add(cd);
        }

        private void addColumnPixels(Grid grid, double width)
        {
            var cd = new ColumnDefinition();
            cd.Width = new GridLength(width);
            grid.ColumnDefinitions.Add(cd);
        }
    }
}
