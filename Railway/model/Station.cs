using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Model
{
    public class Station
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public Location Location { get; set; }
        public Path PathToNextStation { get; set; }
        public Path PathToPreviousStation { get; set; }

        public Station()  { }

        public Station DeepCopy()
        {
            Station newStation = new Station();
            newStation.Name = Name;
            newStation.Longitude = Longitude;
            newStation.Latitude = Latitude;
            newStation.Location = new Location(Latitude, Longitude);
            if (PathToNextStation != null)
                newStation.PathToNextStation = PathToNextStation.DeepCopy(); //.DeepCopy()
            else
                newStation.PathToNextStation = null;
            if (PathToPreviousStation != null)
                newStation.PathToPreviousStation = PathToPreviousStation.DeepCopy(); //.DeepCopy()
            else
                newStation.PathToPreviousStation = null;
            return newStation;
        }
        public Station(string name, double longitude, double latitude, Path pathToNextStation, Path pathToPreviousStation)
        {
            Name = name;
            Longitude = longitude;
            Latitude = latitude;
            Location = new Location(latitude, longitude);
            PathToNextStation = pathToNextStation;
            PathToPreviousStation = pathToPreviousStation;
        }

        public Station(string name, double longitude, double latitude)
        {
            Name = name;
            Longitude = longitude;
            Latitude = latitude;
            Location = new Location(latitude, longitude);
        }

        public override string ToString()
        {
            return "Name: " + Name;
        }


    }
}
