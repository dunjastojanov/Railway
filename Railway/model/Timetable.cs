using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Model
{
    public class Timetable
    {
        public string Name { get; set; }
        public Train Train { get; set; }
        public Trainline Trainline { get; set; }
        public List<string> Days { get; set; }
        public DateTime TimeFromFirstStation { get; set; }
        public DateTime TimeFromLastStation { get; set; }
        public List<Ticket> BoughtTickets { get; set; }

        public Timetable() {
            Days = new List<string>();
            BoughtTickets = new List<Ticket>();
            TimeFromFirstStation = new DateTime();
            TimeFromLastStation = new DateTime();
        }
        public Timetable DeepCopy(Trainline trainline)
        {
            Timetable newTimetable = new Timetable();
            newTimetable.Name = Name;
            newTimetable.Train = Train;
            newTimetable.Trainline = trainline;
            newTimetable.Days = Days;
            newTimetable.TimeFromFirstStation = TimeFromFirstStation;
            newTimetable.TimeFromLastStation = TimeFromLastStation;
            foreach (Ticket ticket in BoughtTickets)
            {
                newTimetable.AddBoughtTicket(ticket.DeepCopy());
            }

            return newTimetable;
        }
        private void AddBoughtTicket(Ticket ticket)
        {
            BoughtTickets.Add(ticket);
        }
        public Timetable(string name, Train train, List<string> days, DateTime firstTime, DateTime lastTime, List<Ticket> boughtTickets)
        {
            Name = name;
            Train = train;
            Trainline = null;
            Days = days;
            TimeFromFirstStation = firstTime;
            TimeFromLastStation = lastTime;
            BoughtTickets = boughtTickets;
        }

        public override string ToString()
        {
            return "Train: " + Train.ToString() + "\nDays: " + Days[0] + "\nTimeFromFirstStation: " + TimeFromFirstStation + "\nTimeFromLastStation: " + TimeFromLastStation.ToString() + "\nBoughtTickets: " + BoughtTickets.Count();
        }

        public bool ContainsDay(DateTime travelDate)
        {
            String dayOfWeek = travelDate.ToString("dddd"); //dobije Monday / Tuesday / Wednesday ...
            bool contains = Days.Contains(dayOfWeek);
            return contains;
        }

        public bool HaveTicketsAvailable(string startStation, string endStation, DateTime travelDate, int numOfTickets)
        {
            int takenSeats = 0;
            foreach (Ticket ticket in BoughtTickets)
            {
                int dateDifference = ticket.Date.Date.CompareTo(travelDate.Date);
                if ((dateDifference == 0) && TicketInRange(ticket, startStation, endStation)) {
                    takenSeats += ticket.NumberOfPassengers;
                }
            }
            return (Train.seats.getNumberOfSeats() - takenSeats) >= numOfTickets;
        }

        private bool TicketInRange(Ticket ticket, string startStation, string endStation)
        {
            int sameStations = 0;
            List<string> allTicketStations = Trainline.getStationInbetween(ticket.StartStation.Name, ticket.EndStation.Name);
            List<string> allSearchingStations = Trainline.getStationInbetween(startStation, endStation);
            if (SameDirection(ticket, startStation, endStation))
                sameStations = SameStationsCount(allTicketStations, allSearchingStations);

            return sameStations > 1;
        }
        private bool SameDirection(Ticket ticket, string startStation, string endStation)
        {
            bool ticketDirection = Trainline.SearchFromStart(ticket.StartStation.Name, ticket.EndStation.Name);
            bool searcingDirection = Trainline.SearchFromStart(startStation, endStation);
            return ticketDirection == searcingDirection;
        }
        private int SameStationsCount(List<string> list1, List<string> list2)
        {
            int count = 0;
            foreach (string item in list1)
            {
                if (list2.Contains(item))
                    count++;
            }
            return count;
        }
    }
}
