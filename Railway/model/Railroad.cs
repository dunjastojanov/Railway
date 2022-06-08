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
        public Railroad()
        {
            TrainLines = new List<Trainline>();
            Users = new List<User>();
        }

        public Railroad(List<Trainline> trainLines, List<User> users)
        {
            TrainLines = trainLines;
            Users = users;
        }
        public Railroad DeepCopy()
        {        
            Railroad railroad = new Railroad();
            foreach (Trainline trainline in TrainLines) {
                railroad.AddTrainline(trainline.DeepCopy());
            }
            railroad.Users = Users;
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
    }
}
