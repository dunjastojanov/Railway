using Railway.model;
using Railway.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway
{
    class Data
    {
        private static List<Railroad> RailwayStates { get; set; }
        private static int RailwayIndex { get; set; }
        private static int CurrentRailwayIndex { get; set; }
        private static int UpperRailwayIndexBound { get; set; }
        public static List<Seats> seats { get; set; }

        public static List<Train> trains { get; set; }

        private static Dictionary<String, Station> Stations { get; set; }


        public static Railroad FillData()
        {
            Data.RailwayStates = new List<Railroad>();
            Data.seats = new List<Seats>();
            Data.trains = new List<Train>();
            Data.Stations = new Dictionary<string, Station>();

            User admin = new User("admin", "admin", "admin");
            User user1 = new User("mika", "mika", "user");
            User user2 = new User("mara", "mara", "user");
            User user3 = new User("dima", "dima", "user");
            User user4 = new User("sara", "sara", "user");
            User user5 = new User("pera", "pera", "user");            
            List<User> users = new List<User>();
            users.Add(admin);
            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
            users.Add(user4);
            users.Add(user5);

            Seats seats1 = new Seats(5, 4, 12);
            Data.seats.Add(seats1);

            Seats seats2 = new Seats(6, 4, 20);
            Data.seats.Add(seats2);

            Seats seats3 = new Seats(3, 5, 24);
            Data.seats.Add(seats3);

            Seats seats4 = new Seats(8, 2, 12);
            Data.seats.Add(seats4);

            Train train1 = new Train("Eagle", seats1);
            Data.trains.Add(train1);
            Train train2 = new Train("Aurora", seats2);
            Data.trains.Add(train2);
            Train train3 = new Train("Juno", seats3);
            Data.trains.Add(train3);
            Train train4 = new Train("Electra", seats4);
            Data.trains.Add(train4);

            List<string> days1 = new List<string>() { "Monday", "Wednesday", "Sunday" };
            List<string> days2 = new List<string>() { "Tuesday", "Thursday" };
            List<string> days3 = new List<string>() { "Friday", "Saturday", "Sunday" };
            List<string> days4 = new List<string>() { "Monday" };
            List<string> days5 = new List<string>() { "Monday", "Thursday" };
            List<string> days6 = new List<string>() { "Tuesday", "Friday", "Sunday" };
            List<string> days7 = new List<string>() { "Tuesday", "Wednesday", "Thursday", "Friday" };
            List<string> days8 = new List<string>() { "Saturday", "Sunday" };
            List<string> days9 = new List<string>() { "Wednesday" };
            List<string> days10 = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            DateTime time1 = new DateTime(2022, 6, 6, 8, 20, 0);
            DateTime time2 = new DateTime(2022, 6, 6, 10, 00, 0);
            DateTime time3 = new DateTime(2022, 6, 6, 11, 30, 0);
            DateTime time4 = new DateTime(2022, 6, 6, 12, 15, 0);
            DateTime time5 = new DateTime(2022, 6, 6, 15, 15, 0);
            DateTime time6 = new DateTime(2022, 6, 6, 16, 20, 0);
            DateTime time7 = new DateTime(2022, 6, 6, 17, 45, 0);
            DateTime time8 = new DateTime(2022, 6, 6, 18, 35, 0);
            DateTime time9 = new DateTime(2022, 6, 6, 19, 00, 0);
            DateTime time10 = new DateTime(2022, 6, 6, 19, 50, 0);
            DateTime time11 = new DateTime(2022, 6, 6, 20, 20, 0);
            DateTime time12 = new DateTime(2022, 6, 6, 21, 35, 0);
            DateTime time13 = new DateTime(2022, 6, 6, 22, 5, 0);
            DateTime time14 = new DateTime(2022, 6, 6, 22, 20, 0);

            Station subotica = new Station("Subotica", 19.667587, 46.100376);
            Stations.Add(subotica.Name, subotica);
            Station subotica1 = subotica.DeepCopy();

            Station zrenjanin = new Station("Zrenjanin", 20.38194, 45.38361);
            Stations.Add(zrenjanin.Name, zrenjanin);
            Station zrenjanin1 = zrenjanin.DeepCopy();

            Station noviSad = new Station("Novi Sad", 19.833549, 45.267136);
            Stations.Add(noviSad.Name, noviSad);
            Station noviSad1 = noviSad.DeepCopy();
            Station noviSad2 = noviSad.DeepCopy();

            Station staraPazova = new Station("Stara Pazova", 19.833549, 45.267136);
            Stations.Add(staraPazova.Name, staraPazova);
            Station staraPazova1 = new Station("Stara Pazova", 19.833549, 45.267136);


            Station beograd = new Station("Beograd Centar", 20.394058, 44.854897);
            Stations.Add(beograd.Name, beograd);
            Station beograd1 = new Station("Beograd Centar", 20.394058, 44.854897);
            Station beograd2 = new Station("Beograd Centar", 20.394058, 44.854897);
            Station beograd3 = new Station("Beograd Centar", 20.394058, 44.854897);


            Station kragujevac = new Station("Kragujevac", 20.91667, 44.01667);
            Stations.Add(kragujevac.Name, kragujevac);
            Station kragujevac1 = new Station("Kragujevac", 20.91667, 44.01667);

            Station smederevo = new Station("Smederevo", 20.93, 44.66278);
            Stations.Add(smederevo.Name, smederevo);

            Station jagodina = new Station("Jagodina", 21.26121, 43.97713);
            Stations.Add(jagodina.Name, jagodina);

            Station knjazevac = new Station("Knjaževac", 22.25701, 43.56634);
            Stations.Add(knjazevac.Name, knjazevac);
            Station knjazevac1 = new Station("Knjaževac", 22.25701, 43.56634);

            Station bor = new Station("Bor", 22.09591, 44.07488);
            Stations.Add(bor.Name, bor);

            Station valjevo = new Station("Valjevo", 19.89821, 44.27513);
            Stations.Add(valjevo.Name, valjevo);

            Station mladenovac = new Station("Mladenovac", 20.693852, 44.436436);
            Stations.Add(mladenovac.Name, mladenovac);

            Station nis = new Station("Niš", 21.90333, 43.32472);
            Stations.Add(nis.Name, nis);

            Station vranje = new Station("Vranje", 21.90028, 42.55139);
            Stations.Add(vranje.Name, vranje);
            Station vranje1 = new Station("Vranje", 21.90028, 42.55139);

            Station uzice = new Station("Užice", 19.84878, 43.85861);
            Stations.Add(uzice.Name, uzice);

            Station sabac = new Station("Šabac", 19.69, 44.74667);
            Stations.Add(sabac.Name, sabac);
            Station sabac1 = new Station("Šabac", 19.69, 44.74667);


            Path path1 = new Path(subotica, zrenjanin, 45, 230);
            Path path11 = new Path(zrenjanin, noviSad, 30, 170);
            Path path111 = new Path(noviSad, staraPazova, 20, 150);
            Path path1111 = new Path(staraPazova, beograd, 25, 210);
            subotica.PathToPreviousStation = null;
            subotica.PathToNextStation = path1;
            zrenjanin.PathToPreviousStation = path1;
            zrenjanin.PathToNextStation = path11;
            noviSad.PathToPreviousStation = path11;
            noviSad.PathToNextStation = path111;
            staraPazova.PathToPreviousStation = path111;
            staraPazova.PathToNextStation = path1111;
            beograd.PathToPreviousStation = path1111;
            beograd.PathToNextStation = null;


            Path path2 = new Path(beograd1, smederevo, 45, 220);
            Path path22 = new Path(smederevo, jagodina, 30, 190);
            Path path222 = new Path(jagodina, nis, 50, 235);
            Path path2222 = new Path(nis, vranje, 60, 400);
            beograd1.PathToPreviousStation = null;
            beograd1.PathToNextStation = path2;
            smederevo.PathToPreviousStation = path2;
            smederevo.PathToNextStation = path22;
            jagodina.PathToPreviousStation = path22;
            jagodina.PathToNextStation = path222;
            nis.PathToPreviousStation = path222;
            nis.PathToNextStation = path2222;
            vranje.PathToPreviousStation = path2222;
            vranje.PathToNextStation = null;


            Path path3 = new Path(bor, knjazevac, 80, 650);
            bor.PathToPreviousStation = null;
            bor.PathToNextStation = path3;
            knjazevac.PathToPreviousStation = path3;
            knjazevac.PathToNextStation = null;


            Path path4 = new Path(noviSad1, beograd2, 45, 200);
            Path path44 = new Path(beograd2, mladenovac, 50, 280);
            Path path444 = new Path(mladenovac, kragujevac, 60, 300);
            noviSad1.PathToPreviousStation = null;
            noviSad1.PathToNextStation = path4;
            beograd2.PathToPreviousStation = path4;
            beograd2.PathToNextStation = path44;
            mladenovac.PathToPreviousStation = path44;
            mladenovac.PathToNextStation = path444;
            kragujevac.PathToPreviousStation = path444;
            kragujevac.PathToNextStation = null;


            Path path5 = new Path(sabac, valjevo, 65, 450);
            Path path55 = new Path(valjevo, uzice, 60, 330);
            Path path555 = new Path(uzice, staraPazova1, 80, 620);
            sabac.PathToPreviousStation = null;
            sabac.PathToNextStation = path5;
            valjevo.PathToPreviousStation = path5;
            valjevo.PathToNextStation = path55;
            uzice.PathToPreviousStation = path55;
            uzice.PathToNextStation = path555;
            staraPazova1.PathToPreviousStation = path555;
            staraPazova1.PathToNextStation = null;


            Path path6 = new Path(kragujevac1, beograd3, 70, 600);
            Path path66 = new Path(beograd3, noviSad2, 45, 200);
            Path path666 = new Path(noviSad2, zrenjanin1, 30, 200);
            Path path6666 = new Path(zrenjanin1, subotica1, 30, 200);
            kragujevac1.PathToPreviousStation = null;
            kragujevac1.PathToNextStation = path6;
            beograd3.PathToPreviousStation = path6;
            beograd3.PathToNextStation = path66;
            noviSad2.PathToPreviousStation = path66;
            noviSad2.PathToNextStation = path666;
            zrenjanin1.PathToPreviousStation = path666;
            zrenjanin1.PathToNextStation = path6666;
            subotica1.PathToPreviousStation = path6666;
            subotica1.PathToNextStation = null;


            Path path7 = new Path(sabac1, vranje1, 95, 720);
            Path path77 = new Path(vranje1, knjazevac1, 60, 330);
            sabac1.PathToPreviousStation = null;
            sabac1.PathToNextStation = path7;
            vranje1.PathToPreviousStation = path7;
            vranje1.PathToNextStation = path77;
            knjazevac1.PathToPreviousStation = path77;
            knjazevac1.PathToNextStation = null;


            Ticket ticket1 = new Ticket(user1, subotica, beograd, new DateTime(2022, 6, 12, 8, 20, 0), 200, 760, 120, train1);
            Ticket ticket11 = new Ticket(user2, staraPazova, beograd, new DateTime(2022, 6, 12, 9, 55, 0), 35, 210, 25, train1);
            Ticket ticket111 = new Ticket(user3, zrenjanin, noviSad, new DateTime(2022, 6, 15, 9, 5, 0), 6, 170, 30, train1);
            Ticket ticket1111 = new Ticket(user4, subotica, beograd, new DateTime(2022, 6, 15, 8, 20, 0), 10, 760, 120, train1);
            Ticket ticket11111 = new Ticket(user5, beograd, subotica, new DateTime(2022, 6, 12, 16, 20, 0), 22, 760, 120, train1);
            Ticket ticket111111 = new Ticket(user1, noviSad, staraPazova, new DateTime(2022, 6, 12, 9, 35, 0), 7, 150, 20, train1);
            List<Ticket> tickets1 = new List<Ticket>() { ticket1, ticket11, ticket111, ticket1111, ticket11111, ticket111111 };

            Ticket ticket1111111 = new Ticket(user4, subotica, beograd, new DateTime(2022, 6, 15, 10, 0, 0), 1, 760, 120, train2);
            Ticket ticket11111111 = new Ticket(user5, beograd, subotica, new DateTime(2022, 6, 12, 17, 45, 0), 2, 760, 120, train2);
            Ticket ticket111111111 = new Ticket(user1, noviSad, staraPazova, new DateTime(2022, 6, 12, 9, 35, 0), 7, 150, 20, train2);
            List<Ticket> tickets11 = new List<Ticket>() { ticket1111111, ticket11111111, ticket111111111 };

            Ticket ticket2 = new Ticket(user2, beograd1, smederevo, new DateTime(2022, 6, 12, 11, 30, 0), 16, 220, 45, train2);
            Ticket ticket22 = new Ticket(user3, beograd1, vranje, new DateTime(2022, 6, 12, 11, 30, 0), 10, 1045, 185, train2);
            Ticket ticket222 = new Ticket(user4, smederevo, jagodina, new DateTime(2022, 6, 12, 12, 15, 0), 2, 190, 30, train2);
            Ticket ticket2222 = new Ticket(user5, nis, vranje, new DateTime(2022, 6, 12, 13, 35, 0), 4, 400, 60, train2);
            List<Ticket> tickets2 = new List<Ticket>() { ticket2, ticket22, ticket222, ticket2222 };

            Ticket ticket22222 = new Ticket(user2, beograd1, smederevo, new DateTime(2022, 6, 12, 12, 15, 0), 6, 220, 45, train3);
            Ticket ticket222222 = new Ticket(user3, beograd1, vranje, new DateTime(2022, 6, 12, 12, 15, 0), 1, 1045, 185, train3);
            List<Ticket> tickets22 = new List<Ticket>() { ticket22222, ticket222222 };

            Ticket ticket2222222 = new Ticket(user4, smederevo, jagodina, new DateTime(2022, 6, 12, 16, 0, 0), 2, 190, 30, train4);
            Ticket ticket22222222 = new Ticket(user5, nis, vranje, new DateTime(2022, 6, 12, 16, 50, 0), 4, 400, 60, train4);
            List<Ticket> tickets222 = new List<Ticket>() { ticket2222222, ticket22222222 };

            Ticket ticket3 = new Ticket(user1, bor, knjazevac, new DateTime(2022, 6, 12, 16, 20, 0), 10, 650, 80, train1);
            Ticket ticket33 = new Ticket(user2, bor, knjazevac, new DateTime(2022, 6, 12, 16, 20, 0), 6, 650, 80, train1);
            Ticket ticket333 = new Ticket(user3, knjazevac, bor, new DateTime(2022, 6, 15, 19, 0, 0), 8, 650, 80, train1);
            Ticket ticket3333 = new Ticket(user4, bor, knjazevac, new DateTime(2022, 6, 15, 16, 20, 0), 12, 650, 80, train1);
            Ticket ticket33333 = new Ticket(user5, knjazevac, bor, new DateTime(2022, 6, 16, 19, 0, 0), 5, 650, 80, train1);
            Ticket ticket333333 = new Ticket(user1, bor, knjazevac, new DateTime(2022, 6, 16, 16, 20, 0), 17, 650, 80, train1);
            List<Ticket> tickets3 = new List<Ticket>() { ticket3, ticket33, ticket333, ticket3333, ticket33333, ticket333333 };
            
            Ticket ticket3333333 = new Ticket(user1, bor, knjazevac, new DateTime(2022, 6, 12, 17, 45, 0), 10, 650, 80, train1);
            Ticket ticket33333333 = new Ticket(user2, bor, knjazevac, new DateTime(2022, 6, 12, 17, 45, 0), 6, 650, 80, train1);
            Ticket ticket333333333 = new Ticket(user3, knjazevac, bor, new DateTime(2022, 6, 15, 19, 50, 0), 8, 650, 80, train1);
            List<Ticket> tickets33 = new List<Ticket>() { ticket3333333, ticket33333333, ticket333333333 };

            Ticket ticket3333333333 = new Ticket(user4, bor, knjazevac, new DateTime(2022, 6, 15, 18, 35, 0), 12, 650, 80, train4);
            Ticket ticket33333333333 = new Ticket(user5, knjazevac, bor, new DateTime(2022, 6, 16, 20, 20, 0), 5, 650, 80, train4);
            Ticket ticket333333333333 = new Ticket(user1, bor, knjazevac, new DateTime(2022, 6, 16, 18, 35, 0), 17, 650, 80, train4);
            List<Ticket> tickets333 = new List<Ticket>() { ticket3333333333, ticket33333333333, ticket333333333333 };

            Ticket ticket3333333333333 = new Ticket(user2, bor, knjazevac, new DateTime(2022, 6, 12, 19, 0, 0), 6, 650, 80, train4);
            Ticket ticket33333333333333 = new Ticket(user3, knjazevac, bor, new DateTime(2022, 6, 15, 22, 20, 0), 8, 650, 80, train4);
            Ticket ticket333333333333333 = new Ticket(user4, bor, knjazevac, new DateTime(2022, 6, 15, 19, 0, 0), 12, 650, 80, train4);
            Ticket ticket3333333333333333 = new Ticket(user5, knjazevac, bor, new DateTime(2022, 6, 16, 22, 20, 0), 5, 650, 80, train4);
            List<Ticket> tickets3333 = new List<Ticket>() { ticket3333333333333, ticket33333333333333, ticket333333333333333, ticket3333333333333333 };

            Ticket ticket4 = new Ticket(user2, noviSad1, kragujevac, new DateTime(2022, 6, 12, 17, 45, 0), 5, 780, 155, train2);
            Ticket ticket44 = new Ticket(user3, beograd2, kragujevac, new DateTime(2022, 6, 12, 18, 30, 0), 15, 580, 110, train2);
            Ticket ticket444 = new Ticket(user4, beograd2, kragujevac, new DateTime(2022, 6, 12, 18, 30, 0), 5, 580, 110, train2);
            List<Ticket> tickets4 = new List<Ticket>() { ticket4, ticket44, ticket444 };

            Ticket ticket5 = new Ticket(user5, sabac, staraPazova1, new DateTime(2022, 6, 12), 30, 1400, 205, train1);
            Ticket ticket55 = new Ticket(user1, staraPazova1, sabac, new DateTime(2022, 6, 12), 30, 1400, 205, train1);
            List<Ticket> tickets5 = new List<Ticket>() { ticket5, ticket55 };

            Ticket ticket555 = new Ticket(user1, staraPazova1, sabac, new DateTime(2022, 6, 12, 22, 5, 0), 30, 1400, 205, train3);
            List<Ticket> tickets55 = new List<Ticket>() { ticket555 };

            Ticket ticket5555 = new Ticket(user1, sabac, staraPazova1, new DateTime(2022, 6, 12, 10, 0, 0), 40, 1400, 205, train3);
            List<Ticket> tickets555 = new List<Ticket>() { ticket5555 };

            Timetable timetable1 = new Timetable("Red voznje 11", train1, days1, time1, time6, tickets1);
            Timetable timetable11 = new Timetable("Red voznje 12", train2, days2, time2, time7, tickets11);
            List<Timetable> timetables1 = new List<Timetable>() { timetable1, timetable11 };

            Timetable timetable2 = new Timetable("Red voznje 21", train2, days3, time3, time9, tickets2);
            Timetable timetable22 = new Timetable("Red voznje 22", train3, days4, time4, time10, tickets22);
            Timetable timetable222 = new Timetable("Red voznje 23", train4, days5, time5, time13, tickets222);
            List<Timetable> timetables2 = new List<Timetable>() { timetable2, timetable22, timetable222 };

            Timetable timetable3 = new Timetable("Red voznje 31", train1, days6, time6, time9, tickets3);
            Timetable timetable33 = new Timetable("Red voznje 32", train1, days7, time7, time10, tickets33);
            Timetable timetable333 = new Timetable("Red voznje 33", train4, days8, time8, time11, tickets333);
            Timetable timetable3333 = new Timetable("Red voznje 34", train4, days9, time9, time14, tickets3333);
            List<Timetable> timetables3 = new List<Timetable>() { timetable3, timetable33, timetable333, timetable3333 };

            Timetable timetable4 = new Timetable("Red voznje 41", train2, days10, time7, time14, tickets4);
            List<Timetable> timetables4 = new List<Timetable>() { timetable4 };

            Timetable timetable5 = new Timetable("Red voznje 51", train1, days9, time1, time11, tickets5);
            Timetable timetable55 = new Timetable("Red voznje 53", train3, days2, time3, time13, tickets55);
            Timetable timetable555 = new Timetable("Red voznje 52", train3, days3, time2, time12, tickets555);
            List<Timetable> timetables5 = new List<Timetable>() { timetable5, timetable55, timetable555 };

            Timetable timetable6 = new Timetable("Red voznje 61", train2, days1, time3, time7, new List<Ticket>());
            Timetable timetable66 = new Timetable("Red voznje 62", train4, days4, time6, time14, new List<Ticket>());
            List<Timetable> timetables6 = new List<Timetable>() { timetable6, timetable66 };

            Timetable timetable7 = new Timetable("Red voznje 71", train2, days6, time2, time5, new List<Ticket>());
            List<Timetable> timetables7 = new List<Timetable>() { timetable7 };

            Trainline trainline1 = new Trainline("Linija 1", subotica, beograd, timetables1);
            timetable1.Trainline = trainline1;
            timetable11.Trainline = trainline1;

            Trainline trainline2 = new Trainline("Linija 2", beograd1, vranje, timetables2);
            timetable2.Trainline = trainline2;
            timetable22.Trainline = trainline2;
            timetable222.Trainline = trainline2;

            Trainline trainline3 = new Trainline("Linija 3", bor, knjazevac, timetables3);
            timetable3.Trainline = trainline3;
            timetable33.Trainline = trainline3;
            timetable333.Trainline = trainline3;
            timetable3333.Trainline = trainline3;

            Trainline trainline4 = new Trainline("Linija 4", noviSad1, kragujevac, timetables4);
            timetable4.Trainline = trainline4;

            Trainline trainline5 = new Trainline("Linija 5", sabac, staraPazova1, timetables5);
            timetable5.Trainline = trainline5;
            timetable55.Trainline = trainline5;
            timetable555.Trainline = trainline5;

            Trainline trainline6 = new Trainline("Linija 6", kragujevac1, subotica1, timetables6);
            timetable6.Trainline = trainline6;
            timetable66.Trainline = trainline6;

            Trainline trainline7 = new Trainline("Linija 7", sabac1, knjazevac1, timetables7);
            timetable7.Trainline = trainline7;

            List<Trainline> trainlines = new List<Trainline>() { trainline1, trainline2, trainline3, trainline4, trainline5, trainline6, trainline7 };

            Railroad railway = new Railroad(trainlines, users);

            Data.AddRailway(railway);
            Data.SetRailwayIndex(0);
            Data.CurrentRailwayIndex = 0;
            Data.UpperRailwayIndexBound = 0;
            return railway;

        }

        internal static void AddTrain(Seats chosenSeats, string name, int numberOfWagons)
        {
            Railroad oldRailway = Data.RailwayStates[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();

            Seats seats = new Seats(numberOfWagons, chosenSeats.numberOfColumns, chosenSeats.numberOfSeatsPerColumn);
            Train train = new Train(name, seats);

            Data.trains.Add(train);

            Data.AddRailway(newRailway);
            Data.SetRailwayIndex(Data.RailwayIndex + 1);
        }

        internal static void editTrain(Seats chosenSeats, string name, int numberOfWagons, Train oldTrain)
        {
            Railroad oldRailway = Data.RailwayStates[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();

            Seats seats = new Seats(numberOfWagons, chosenSeats.numberOfColumns, chosenSeats.numberOfSeatsPerColumn);
            Train train = new Train(name, seats);

            List<Trainline> trainlines = newRailway.TrainLines;

            foreach (Trainline trainline in trainlines)
            {
                foreach (Timetable timetable in trainline.Timetables)
                {
                    if (timetable.Train.Name == oldTrain.Name)
                    {
                        timetable.Train = train;
                        foreach (Ticket ticket in timetable.BoughtTickets)
                        {
                            ticket.Train = train;
                        }
                    }


                }
            }

            for (int i = 0; i < Data.trains.Count; i++)
            {
                if (Data.trains[i].Name == oldTrain.Name)
                {
                    Data.trains[i] = train;
                }
            }

            newRailway.TrainLines = trainlines;

            Data.AddRailway(newRailway);
            Data.SetRailwayIndex(Data.RailwayIndex + 1);
        }

        internal static void deleteTrain(Train oldTrain)
        {
            Railroad oldRailway = Data.RailwayStates[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();

            List<Trainline> trainlines = newRailway.TrainLines;

            for (int i = 0; i < trainlines.Count; i++)
            {
                List<Timetable> timetables = new List<Timetable>();
                foreach (Timetable timetable in trainlines[i].Timetables)
                {
                    if (timetable.Train.Name != oldTrain.Name)
                    {
                        timetables.Add(timetable);
                    }

                }

                trainlines[i].Timetables = timetables;
            }

            List<Train> trains = new List<Train>();
            for (int i = 0; i < Data.trains.Count; i++)
            {
                if (Data.trains[i].Name != oldTrain.Name)
                {
                    trains.Add(Data.trains[i]);
                }
            }

            Data.trains = trains;

            newRailway.TrainLines = trainlines;

            Data.AddRailway(newRailway);
            Data.SetRailwayIndex(Data.RailwayIndex + 1);
        }

        public static List<Train> GetTrains()
        {
            List<Train> trains = new List<Train>();
            Railroad railway = Data.RailwayStates[Data.CurrentRailwayIndex];
            foreach (Trainline trainline in railway.TrainLines)
            {
                foreach (Timetable timetable in trainline.Timetables)
                {
                    if (!trains.Contains(timetable.Train))
                        trains.Add(timetable.Train);
                }
            }
            return trains;
        }

        internal static void deleteTrainRoute(string name)
        {
            Railroad oldRailway = Data.RailwayStates[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();

            int index = -1;
            List<Trainline> trainlines = newRailway.TrainLines;

            for (int i = 0; i < trainlines.Count; i++)
            {

                Trainline t = trainlines[i].DeepCopy();

                if (t.Name == name)
                {
                    index = i;
                    break;
                }
            }

            trainlines.RemoveAt(index);
         

            Data.AddRailway(newRailway);
            Data.SetRailwayIndex(Data.RailwayIndex + 1);
        }

        internal static void editTrainLine(List<Dictionary<string, object>> infoBetweenStations, string name)
        {
            Railroad oldRailway = Data.RailwayStates[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();

            List<Station> stations = createStationsFromInfoBetweenStations(infoBetweenStations);

            List<Trainline> trainlines = GetTrainLines();

            for (int i = 0; i < trainlines.Count; i++)
            {

                Trainline t = trainlines[i].DeepCopy();

                if (t.Name == name)
                {
                    t.FirstStation = stations[0];
                    t.LastStation = stations[stations.Count - 1];

                    trainlines[i] = t;
                }
            }

            newRailway.TrainLines = trainlines;

            Data.AddRailway(newRailway);
            Data.SetRailwayIndex(Data.RailwayIndex + 1);
        }

        public static User GetLogedUser(string username, string password)
        {
            Railroad railway = Data.RailwayStates[Data.CurrentRailwayIndex];
            foreach (User user in railway.Users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                    return user;
            }
            return null;
        }

        private static void AddRailway(Railroad railway)
        {
            Data.RailwayStates.Add(railway);
        }

        private static void SetRailwayIndex(int index)
        {
            //Data.RailwayIndex = index;
            Data.CurrentRailwayIndex++;
            UpperRailwayIndexBound = Data.RailwayStates.Count - 1;
        }
        public static void Undo()
        {
            CurrentRailwayIndex--;
        }

        public static void Redo()
        {
            CurrentRailwayIndex++;
        }

        public static bool NeedUndo()
        {
            return CurrentRailwayIndex > RailwayIndex;
        }
        public static bool NeedRedo()
        {
            return CurrentRailwayIndex < Data.UpperRailwayIndexBound;
        }

        public static void ResetCurrentIndex()
        {
            RailwayIndex = CurrentRailwayIndex;
            UpperRailwayIndexBound = CurrentRailwayIndex;
        }
        public static List<string> GetStationNames()
        {
            List<string> stationNames = new List<string>();
            Railroad railway = Data.RailwayStates[Data.CurrentRailwayIndex];
            foreach (Trainline trainline in railway.TrainLines)
            {
                foreach (string stationName in trainline.GetStationNames())
                {
                    if (!stationNames.Contains(stationName))
                    {
                        stationNames.Add(stationName);
                    }
                }
            }
            return stationNames;
        }

        public static void AddTrainLine(List<Dictionary<string, object>> infoBetweenStations)
        {
            Railroad oldRailway = Data.RailwayStates[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();
            List<Station> stations = createStationsFromInfoBetweenStations(infoBetweenStations);

            Trainline trainline = new Trainline();
            trainline.FirstStation = stations[0];
            trainline.LastStation = stations[stations.Count - 1];

            newRailway.AddTrainline(trainline);

            Data.AddRailway(newRailway);
            Data.SetRailwayIndex(Data.RailwayIndex + 1);

        }

        private static List<Station> createStationsFromInfoBetweenStations(List<Dictionary<string, object>> infoBetweenStations)
        {
            List<Station> stations = new List<Station>();

            var info = infoBetweenStations[0];

            Station station = Stations[(string)info["startStation"]].DeepCopy();
            station.PathToNextStation = null;
            station.PathToPreviousStation = null;
            stations.Add(station);

            for (int i = 0; i < infoBetweenStations.Count; i++)
            {
                info = infoBetweenStations[i];
                Path path = new Path();
                path.PreviousStation = stations[i];
                stations[i].PathToNextStation = path;


                path.Duration = (int)info["duration"];
                path.Price = (int)info["price"];

                Station s = Stations[(string)info["endStation"]].DeepCopy();
                s.PathToPreviousStation = path;
                s.PathToNextStation = null;
                stations.Add(s);
                path.NextStation = stations[i + 1];

            }

            return stations;
        }


        public static List<QuickReservation> BuyTicket(QuickReservation reservation, Ticket ticket, string startStation, string endStation, DateTime travelDate, int numOfTickets)
        {
            Railroad oldRailway = Data.RailwayStates[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();
            newRailway.AddBoughtTicket(reservation.Trainline, reservation.Timetable, ticket);
            Data.AddRailway(newRailway);
            Data.SetRailwayIndex(Data.RailwayIndex + 1);
            return GetQuickReservations(startStation, endStation, travelDate, numOfTickets);
        }    
 
        public static List<Ticket> GetBoughtTickets(User user)
        {
            List<Ticket> tickets = new List<Ticket>();
            Railroad railway = Data.RailwayStates[Data.CurrentRailwayIndex];
            foreach (Trainline trainline in railway.TrainLines)
            {
                foreach (Timetable timetable in trainline.Timetables)
                {
                    foreach (Ticket ticket in timetable.BoughtTickets)
                    {
                        if (ticket.User.Username.Equals(user.Username))
                        {
                            tickets.Add(ticket);
                        }
                    }
                }
            }
            return tickets;
        }

        public static List<Trainline> GetTrainLines()
        {
            Railroad railway = Data.RailwayStates[Data.CurrentRailwayIndex];
            return railway.TrainLines;
        }
        public static List<QuickReservation> GetQuickReservations(string startStation, string endStation, DateTime travelDate, int numOfTickets)
        {
            List<QuickReservation> quickReservations = null;
            Railroad railway = Data.RailwayStates[Data.CurrentRailwayIndex];
            foreach (Trainline trainline in railway.TrainLines)
            {
                if (trainline.ContainsStations(startStation, endStation))
                {
                    if (quickReservations == null)
                        quickReservations = new List<QuickReservation>();
                    foreach (Timetable timetable in trainline.Timetables)
                    {
                        if (timetable.ContainsDay(travelDate) && timetable.HaveTicketsAvailable(startStation, endStation, travelDate, numOfTickets))
                        {
                            int price = trainline.CalculatePrice(startStation, endStation);
                            int duration = trainline.CalculateDuration(startStation, endStation);
                            DateTime departure = trainline.CalculateDateAndTime(timetable, travelDate, startStation, endStation);
                            DateTime arrival = departure.AddMinutes(duration);
                            List<string> allStations = trainline.getStationInbetween(startStation, endStation);
                            quickReservations.Add(new QuickReservation(startStation, endStation, allStations, trainline, timetable, departure, arrival, price, duration));
                        }
                    }
                }
            }
            return quickReservations;
        }
    }
}
