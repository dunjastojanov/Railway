using Railway.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Model
{
    public class Ticket
    {
        public Station StartStation { get; set; }
        public Station EndStation { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfPassengers { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
        public Train Train { get; set; }
        public User User { get; set; } 

        public Ticket()
        {
            Date = new DateTime();
        }
        public Ticket DeepCopy()
        {
            Ticket newTicket = new Ticket();
            newTicket.StartStation = StartStation.DeepCopy();
            newTicket.EndStation = EndStation.DeepCopy();
            newTicket.Date = Date;
            newTicket.NumberOfPassengers = NumberOfPassengers;
            newTicket.User = User;
            newTicket.Train = Train;
            newTicket.Price = Price;
            newTicket.Duration = Duration;
            return newTicket;
        }
        public Ticket(User user, Station startStation, Station endStation, DateTime date, int numberOfPassengers, int price, int duration, Train train)
        {
            User = user;
            StartStation = startStation;
            EndStation = endStation;
            Date = date;
            NumberOfPassengers = numberOfPassengers;
            Price = price;
            Duration = duration;
            Train = train;
        }
        public override string ToString()
        {
            return "Start station: " + StartStation.ToString() + "/nEnd station: " + EndStation.ToString() + "/nDate: " + Date + "/nNumberOfPassengers: " + NumberOfPassengers;
        }
    }
}
