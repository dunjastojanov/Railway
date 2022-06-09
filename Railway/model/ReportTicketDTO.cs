using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.model
{
    public class ReportTicketDTO
    {
        public string StartStation { get; set; }
        public string EndStation { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }
        public int NumOfSeats { get; set; }

        public ReportTicketDTO()
        {
        }

        public ReportTicketDTO(string startStation, string endStation, int price, string date, int numOfSeats)
        {
            StartStation = startStation;
            EndStation = endStation;
            Price = price;
            Date = date;
            NumOfSeats = numOfSeats;
        }

        public override string ToString()
        {
            return "Start station: " + StartStation + " End station: " + EndStation;
        }
    }
}
