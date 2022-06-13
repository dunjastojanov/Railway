using Railway.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Model
{
    public class Railroad
    {
        public List<Trainline> TrainLines { get; set; }
        public List<User> Users { get; set; }
        public List<Train> Trains { get; set; }
        public List<Station> Stations { get; set; }
        public Railroad()
        {
            TrainLines = new List<Trainline>();
            Users = new List<User>();
            Stations = new List<Station>();
            Trains = new List<Train>();
        }

        public Railroad(List<Trainline> trainLines, List<User> users)
        {
            TrainLines = trainLines;
            Users = users;
            Stations = new List< Station>();
            Trains = new List<Train>();
        }
        public Railroad DeepCopy()
        {        
            Railroad railroad = new Railroad();
            foreach (Trainline trainline in TrainLines) {
                railroad.AddTrainline(trainline.DeepCopy());
            }
            List<Train> trains = new List<Train>();


            List<Station> stations = new List<Station>();
            foreach (Train item in Trains)
            {
                trains.Add(item.DeepCopy());
            }
            foreach (Station station in Stations)
            {
                stations.Add(station.DeepCopy());
            }
            railroad.Stations = stations;
            railroad.Users = Users;
            railroad.Trains = trains;
            return railroad;
            
        }
        public void AddTrainline(Trainline trainline)
        {
            TrainLines.Add(trainline);
        }
        public void AddBoughtTicket(Trainline trainline, Timetable timetable, Ticket ticket)
        {
            Trainline requiredTrainline = FindTrainline(trainline.Name);
            Timetable requiredTimetable = requiredTrainline.FindTimetable(timetable.Name);
            requiredTimetable.BoughtTickets.Add(ticket);
        }
        public Trainline FindTrainline(String name)
        {
            foreach(Trainline trainline in TrainLines)
            {
                if (trainline.Name.Equals(name))
                    return trainline;
            }
            return null;
        }
        public void RemoveStation(Station station)
        {
            foreach (Station st in Stations)
            {
                if (st.Name.Equals(station.Name))
                {
                    Stations.Remove(st);
                    return;
                }
            }
        }
    }
}
