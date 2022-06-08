using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Model
{
    public class Path
    {
        public Station PreviousStation { get; set; }
        public Station NextStation { get; set; }
        public int Duration { get; set; } //in minutes
        public int Price { get; set; }

        public Path()  {}
   
        public Path DeepCopy()
        {
            Path newPath = new Path();
            newPath.PreviousStation = PreviousStation.DeepCopy();
            newPath.NextStation = NextStation.DeepCopy();
            newPath.Duration = Duration;
            newPath.Price = Price;
            return newPath;
        }
        public Path(Station previousStation, Station nextStation, int duration, int price)
        {
            PreviousStation = previousStation;
            NextStation = nextStation;
            Duration = duration;
            Price = price;
        }

        public override string ToString()
        {
            return "Previous station: " + PreviousStation.ToString() + "/nNext station: " + NextStation.ToString() + "/nDuration: " + Duration + "/nPrice: " + Price;
        }
    }
}
