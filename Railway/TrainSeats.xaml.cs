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
    /// Interaction logic for TrainSeats.xaml
    /// </summary>
    public partial class TrainSeats : Grid
    {
        public TrainSeats(Seats seats, int wagonNumber)
        {
            InitializeComponent();

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            int firstColumRows = seats.numberOfColumns / 2;

            addColumnPixels(TrainGrid, 5);

            for (int i = 0; i< seats.numberOfColumns +1; i++) {
                addColumnStars(TrainGrid, 1);
            }

            addColumnPixels(TrainGrid, 5);
            addRowPixels(TrainGrid, 5);
            for (int i = 0; i< seats.numberOfSeatsPerColumn; i++)
            {
                addRowPixels(TrainGrid, 20);
            }
            addRowPixels(TrainGrid, 5);

            for (int i = 1; i <= seats.numberOfSeatsPerColumn; i++)
            {
                for (int j = 0; j< firstColumRows; j++)
                {
                    SeatButton seatButton = new SeatButton(wagonNumber, alpha[j], i);
                    Grid.SetColumn(seatButton, j+1);
                    Grid.SetRow(seatButton, i);

                    TrainGrid.Children.Add(seatButton);

                }

                for (int j = firstColumRows+1; j < seats.numberOfSeatsPerColumn; j++)
                {
                    SeatButton seatButton = new SeatButton(wagonNumber, alpha[j], i);
                    Grid.SetColumn(seatButton, j + 1);
                    Grid.SetRow(seatButton, i);

                    TrainGrid.Children.Add(seatButton);
                }
            }

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
