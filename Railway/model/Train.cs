using Railway.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Model
{
    public class Train
    {
        public string Name { get; set; }
        public Seats seats{ get; set; }

        public Train()
        { }

        public Train(string name, Seats seats)
        {
            Name = name;
            this.seats = seats;
        }

        public override string ToString()
        {
            return "Name: " + Name + "\nNumber of seats: " + seats.getNumberOfSeats();
        }

        public Train DeepCopy(Train oldTrain)
        {
            return new Train(oldTrain.Name, oldTrain.seats.DeepCopy());
        }
    }
}
