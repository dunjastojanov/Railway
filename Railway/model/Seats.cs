using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.model
{
    
    public class Seats
    {
        public int numberOfWagons { get; set; }
        public int numberOfColumns { get; set; }
        public int numberOfSeatsPerColumn { get; set; }

        public List<Dictionary<char, List<bool>>> seats;

        public Seats()
        {
            seats = new List<Dictionary<char, List<bool>>>();
        }

        public Seats(int numberOfWagons, int numberOfColumns, int numberOfSeatsPerColumn)
        {
            this.numberOfWagons = numberOfWagons;
            this.numberOfColumns = numberOfColumns;
            this.numberOfSeatsPerColumn = numberOfSeatsPerColumn;

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            seats = new List<Dictionary<char, List<bool>>>();

            for (int i = 1; i<=numberOfWagons; i++)
            {
                Dictionary<char, List<bool>> wagon = new Dictionary<char, List<bool>>();
                
                
                for (int j = 0; j<numberOfColumns; j++)
                {
                    List<bool> column = new List<bool>();

                    for (int k = 1; k<=numberOfSeatsPerColumn; k++)
                    {
                        column.Add(false);
                    }

                    wagon.Add(alpha[j], column);
                }
                
                seats.Add(wagon);

            }
        }

        public int getNumberOfSeats()
        {
            return numberOfColumns * numberOfSeatsPerColumn * numberOfWagons;
        }

        public Seats getEmptySeats(Seats filledSeats)
        {
            this.numberOfWagons = filledSeats.numberOfWagons;
            this.numberOfColumns = filledSeats.numberOfColumns;
            this.numberOfSeatsPerColumn = filledSeats.numberOfSeatsPerColumn;

            return new Seats(numberOfWagons, numberOfColumns, numberOfSeatsPerColumn);

            
        }

        public bool isSeatTaken(int numberOfWagon, char column, int numberOfSeat)
        {
            return seats[numberOfWagon][column][numberOfSeat];
        }

        public void takeSeat(int numberOfWagon, char column, int numberOfSeat)
        {
            seats[numberOfWagon][column][numberOfSeat] = true;
        }

        public Seats DeepCopy()
        {

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            Seats newSeats = new Seats();

            for (int i = 1; i <= numberOfWagons; i++)
            {
                Dictionary<char, List<bool>> wagon = new Dictionary<char, List<bool>>();


                for (int j = 0; j < numberOfColumns; j++)
                {
                    List<bool> column = new List<bool>();

                    for (int k = 0; k < numberOfSeatsPerColumn; k++)
                    {
                        column.Add(seats[i][alpha[j]][k]);
                    }

                    wagon.Add(alpha[j], column);
                }

                newSeats.seats.Add(wagon);

            }

            return newSeats;

        }

    }
}
