using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Model
{
    public class Trainline
    {
        public string Name { get; set; }
        public Station FirstStation { get; set; }
        public Station LastStation { get; set; }
        public List<Timetable> Timetables { get; set; }
        public Trainline()
        {
            Timetables = new List<Timetable>();
        }

        public Trainline(string name, Station firstStation, Station lastStation, List<Timetable> timetables)
        {
            Name = name;
            FirstStation = firstStation;
            LastStation = lastStation;
            Timetables = timetables;
        }

        public Trainline DeepCopy()
        {
            Trainline newTrainline = new Trainline();
            newTrainline.Name = Name;
            newTrainline.FirstStation = FirstStation.DeepCopy();
            newTrainline.LastStation = LastStation.DeepCopy();
            foreach (Timetable timetable in Timetables)
                newTrainline.AddTimetable(timetable.DeepCopy(newTrainline));
            return newTrainline;
        }

        //MOGUCI PROBLEM AKO VRACA VALUE DA NE STAVI LEPO TICKET
        public Timetable FindTimetable(String name)
        {
            foreach (Timetable timetable in Timetables)
            {
                if (timetable.Name.Equals(name))
                    return timetable;
            }
            return null;
        }
        private void AddTimetable(Timetable timetable)
        {
            Timetables.Add(timetable);
        }

        public override string ToString()
        {
            return "TRAINLINE: FirstStation: " + FirstStation.ToString() + "\nLastStation: " + LastStation.ToString();
        }

        public List<string> GetStationNames()
        {
            List<string> stationNames = new List<string>();
            Station currentStation = FirstStation;
            while (currentStation.PathToNextStation != null)
            {
                stationNames.Add(currentStation.Name);
                currentStation = currentStation.PathToNextStation.NextStation;
            }
            stationNames.Add(currentStation.Name);
            return stationNames;
        }

        public Station getStation(String stationName)
        {
            Station currentStation = FirstStation;
            while (currentStation.PathToNextStation != null)
            {
                if (currentStation.Name.Equals(stationName))
                {
                    return currentStation;
                }             
                currentStation = currentStation.PathToNextStation.NextStation;
            }
            if (currentStation.Name.Equals(stationName))
            {
                return currentStation;
            }
            return null;

        }
        public bool ContainsStations(string stationOne, string stationTwo)
        {
            bool containsOne = false;
            bool containsTwo = false;
            Station currentStation = FirstStation;
            while (currentStation.PathToNextStation != null)
            {
                if (currentStation.Name.Equals(stationOne))
                {
                    containsOne = true;
                }
                else if (currentStation.Name.Equals(stationTwo))
                {
                    containsTwo = true;
                }
                currentStation = currentStation.PathToNextStation.NextStation;

            }
            if (currentStation.Name.Equals(stationOne))
            {
                containsOne = true;
            }
            else if (currentStation.Name.Equals(stationTwo))
            {
                containsTwo = true;
            }
            return containsOne && containsTwo;
        }

        public int CalculatePrice(string startStation, string endStation)
        {
            int price = 0;
            bool visitedStart = false;
            bool visitedEnd = false;
            Station currentStation = FirstStation;
            while (!(visitedStart && visitedEnd) && (currentStation.PathToNextStation != null))
            {
                if (currentStation.Name.Equals(startStation))
                {
                    visitedStart = true;
                }
                else if (currentStation.Name.Equals(endStation))
                {
                    visitedEnd = true;
                }
                if (visitedStart && visitedEnd)
                    break;
                if (visitedStart || visitedEnd)
                    price += currentStation.PathToNextStation.Price;

                currentStation = currentStation.PathToNextStation.NextStation;
            }
            return price;
        }
        public int CalculateDuration(string startStation, string endStation)
        {
            int duration = 0;
            bool visitedStart = false;
            bool visitedEnd = false;
            Station currentStation = FirstStation;
            while (!(visitedStart && visitedEnd) && (currentStation.PathToNextStation != null))
            {
                if (currentStation.Name.Equals(startStation))
                {
                    visitedStart = true;
                }
                else if (currentStation.Name.Equals(endStation))
                {
                    visitedEnd = true;
                }
                if (visitedStart && visitedEnd)
                    break;
                if (visitedStart || visitedEnd)
                    duration += currentStation.PathToNextStation.Duration;

                currentStation = currentStation.PathToNextStation.NextStation;
            }
            return duration;
        }
        public DateTime CalculateDateAndTime(Timetable timetable, DateTime travelDate, string startStation, string endStation)
        {
            bool visitedEnd = false;
            Station currentStation = FirstStation;
            while (currentStation.PathToNextStation != null)
            {
                if (currentStation.Name.Equals(endStation))
                    visitedEnd = true;
                if (currentStation.Name.Equals(startStation))
                {
                    if (visitedEnd)
                    {
                        DateTime time = CalculateTime(startStation, timetable.TimeFromLastStation, false);
                        return new DateTime(travelDate.Year, travelDate.Month, travelDate.Day, time.Hour, time.Minute, time.Second);

                    }
                    else
                    {
                        DateTime time = CalculateTime(startStation, timetable.TimeFromFirstStation, true);
                        return new DateTime(travelDate.Year, travelDate.Month, travelDate.Day, time.Hour, time.Minute, time.Second);
                    }
                }
                currentStation = currentStation.PathToNextStation.NextStation;
            }
            if (currentStation.Name.Equals(startStation))
            {
                return new DateTime(travelDate.Year, travelDate.Month, travelDate.Day, timetable.TimeFromLastStation.Hour, timetable.TimeFromLastStation.Minute, timetable.TimeFromLastStation.Second);
            }
            return new DateTime(0000, 0, 0);
        }

        private DateTime CalculateTime(string startStation, DateTime time, bool startFromFirstStation)
        {
            DateTime startTime = new DateTime(2022,6,6, time.Hour, time.Minute, time.Second);
            if (startFromFirstStation)
            {
                Station currentStation = FirstStation;
                while (!currentStation.Name.Equals(startStation))
                {
                    startTime.AddMinutes(currentStation.PathToNextStation.Duration);
                    currentStation = currentStation.PathToNextStation.NextStation;
                }
            }
            else
            {
                Station currentStation = LastStation;
                while (!currentStation.Name.Equals(startStation))
                {
                    startTime.AddMinutes(currentStation.PathToPreviousStation.Duration);
                    currentStation = currentStation.PathToPreviousStation.PreviousStation;
                }
            }
            return startTime;
        }

        public bool SearchFromStart(string startStation, string endStation)
        {
            Station currentStation = FirstStation;
            while (currentStation.PathToNextStation != null)
            {
                if (currentStation.Name.Equals(endStation))
                    return false;
                if (currentStation.Name.Equals(startStation))
                    return true;
                currentStation = currentStation.PathToNextStation.NextStation;
            }
            return false;
        }

        public List<string> getStationInbetween(string startStation, string endStation)
        {
            List<string> stations = new List<string>();
            bool add = false;
            if (SearchFromStart(startStation, endStation))
            {
                Station currentStation = FirstStation;
                while (!currentStation.Name.Equals(endStation))
                {
                    if (currentStation.Name.Equals(startStation))
                    {
                        add = true;
                    }
                    if (add)
                        stations.Add(currentStation.Name);
                    currentStation = currentStation.PathToNextStation.NextStation;
                }
            }
            else
            {
                Station currentStation = LastStation;
                while (!currentStation.Name.Equals(endStation))
                {
                    if (currentStation.Name.Equals(startStation))
                    {
                        add = true;
                    }
                    if (add)
                        stations.Add(currentStation.Name);
                    currentStation = currentStation.PathToPreviousStation.PreviousStation;
                }
            }
            stations.Add(endStation);
            return stations;
        }
    }
}
