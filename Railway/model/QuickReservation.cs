using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Model
{
    public class QuickReservation
    {
        public string FirstStation { get; set; }
        public string LastStation { get; set; }
        public List<string> AllStations { get; set; }
        public Trainline Trainline {get; set;}
        public Timetable Timetable { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Price { get; set; }

        public int Duration { get; set; }

        public QuickReservation()
        {
            DepartureTime = new DateTime();
            ArrivalTime = new DateTime();
        }

        public QuickReservation(string firstStation, string lastStation, List<string> allStations, Trainline trainline, Timetable timetable, DateTime departure, DateTime arrival, int price, int duration)
        {
            FirstStation = firstStation;
            LastStation = lastStation;
            AllStations = allStations;
            Trainline = trainline;
            Timetable = timetable;
            DepartureTime = departure;
            ArrivalTime = arrival;
            Price = price;
            Duration = duration;
        }

        public override string ToString()
        {
            return "QUICK RESERVATION: \n" + "First station: " + FirstStation + "\nLast station: " + LastStation + "\n" + Trainline.ToString() + "\nTimetable: " + Timetable.ToString() + "\nDuration: " + Duration + "\nPrice: " + Price + "\nDeparture time: " + DepartureTime; 
        }
    }
}
