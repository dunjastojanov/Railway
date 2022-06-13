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
        private static List<Railroad> RailwayStatesTutorial { get; set; }
        private static int RailwayIndex { get; set; }
        private static int CurrentRailwayIndex { get; set; }
        private static int UpperRailwayIndexBound { get; set; }
        private static int RailwayIndexTutorial { get; set; }
       
        public static List<Seats> seats { get; set; }


        public static Railroad FillData()
        {
            Data.RailwayStates = new List<Railroad>();
            Data.seats = new List<Seats>();

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

            Seats seats2 = new Seats(6, 4, 16);
            Data.seats.Add(seats2);

            Seats seats3 = new Seats(3, 5, 14);
            Data.seats.Add(seats3);

            Seats seats4 = new Seats(8, 2, 12);
            Data.seats.Add(seats4);

            Train train1 = new Train("Eagle", seats1);
            Train train2 = new Train("Aurora", seats2);
            Train train3 = new Train("Juno", seats3);
            Train train4 = new Train("Electra", seats4);


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

            Station subotica1 = subotica.DeepCopy();

            Station zrenjanin = new Station("Zrenjanin", 20.38194, 45.38361);

            Station zrenjanin1 = zrenjanin.DeepCopy();

            Station noviSad = new Station("Novi Sad", 19.833549, 45.267136);

            Station noviSad1 = noviSad.DeepCopy();
            Station noviSad2 = noviSad.DeepCopy();

            Station staraPazova = new Station("Stara Pazova", 19.833549, 45.267136);

            Station staraPazova1 = new Station("Stara Pazova", 19.833549, 45.267136);


            Station beograd = new Station("Beograd Centar", 20.394058, 44.854897);

            Station beograd1 = new Station("Beograd Centar", 20.394058, 44.854897);
            Station beograd2 = new Station("Beograd Centar", 20.394058, 44.854897);
            Station beograd3 = new Station("Beograd Centar", 20.394058, 44.854897);


            Station kragujevac = new Station("Kragujevac", 20.91667, 44.01667);

            Station kragujevac1 = new Station("Kragujevac", 20.91667, 44.01667);

            Station smederevo = new Station("Smederevo", 20.93, 44.66278);

            Station jagodina = new Station("Jagodina", 21.26121, 43.97713);

            Station knjazevac = new Station("Knjaževac", 22.25701, 43.56634);

            Station knjazevac1 = new Station("Knjaževac", 22.25701, 43.56634);

            Station bor = new Station("Bor", 22.09591, 44.07488);

            Station valjevo = new Station("Valjevo", 19.89821, 44.27513);

            Station mladenovac = new Station("Mladenovac", 20.693852, 44.436436);

            Station nis = new Station("Niš", 21.90333, 43.32472);

            Station vranje = new Station("Vranje", 21.90028, 42.55139);

            Station vranje1 = new Station("Vranje", 21.90028, 42.55139);

            Station uzice = new Station("Užice", 19.84878, 43.85861);
            
            Station sabac = new Station("Šabac", 19.69, 44.74667);
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


            TicketSeat ticketSeat1 = new TicketSeat(1, 'A', 1);
            TicketSeat ticketSeat2 = new TicketSeat(1, 'A', 2);
            TicketSeat ticketSeat3 = new TicketSeat(1, 'A', 3);
            TicketSeat ticketSeat4 = new TicketSeat(2, 'A', 4);
            TicketSeat ticketSeat5 = new TicketSeat(2, 'A', 5);
            TicketSeat ticketSeat6 = new TicketSeat(2, 'A', 6);
            TicketSeat ticketSeat7 = new TicketSeat(3, 'A', 7);
            TicketSeat ticketSeat8 = new TicketSeat(3, 'A', 8);
            TicketSeat ticketSeat9 = new TicketSeat(3, 'A', 9);
            TicketSeat ticketSeat10 = new TicketSeat(4, 'A', 2);
            TicketSeat ticketSeat11 = new TicketSeat(1, 'B', 2);
            TicketSeat ticketSeat12 = new TicketSeat(1, 'B', 3);
            TicketSeat ticketSeat13 = new TicketSeat(2, 'B', 4);
            TicketSeat ticketSeat14 = new TicketSeat(2, 'B', 5);
            TicketSeat ticketSeat15 = new TicketSeat(2, 'B', 6);
            TicketSeat ticketSeat16 = new TicketSeat(3, 'B', 7);
            TicketSeat ticketSeat17 = new TicketSeat(3, 'B', 8);
            TicketSeat ticketSeat18 = new TicketSeat(4, 'B', 9);
            TicketSeat ticketSeat19 = new TicketSeat(4, 'B', 10);
            TicketSeat ticketSeat20 = new TicketSeat(5, 'B', 1);
            TicketSeat ticketSeat21 = new TicketSeat(1, 'C', 1);
            TicketSeat ticketSeat22 = new TicketSeat(1, 'C', 2);
            TicketSeat ticketSeat23 = new TicketSeat(2, 'C', 3);
            TicketSeat ticketSeat24 = new TicketSeat(3, 'C', 4);
            TicketSeat ticketSeat25 = new TicketSeat(4, 'C', 5);
            TicketSeat ticketSeat26 = new TicketSeat(5, 'C', 6);
            TicketSeat ticketSeat27 = new TicketSeat(5, 'C', 7);
            TicketSeat ticketSeat28 = new TicketSeat(5, 'C', 8);
            TicketSeat ticketSeat29 = new TicketSeat(3, 'C', 9);
            TicketSeat ticketSeat30 = new TicketSeat(3, 'C', 10);
            TicketSeat ticketSeat31 = new TicketSeat(1, 'D', 1);
            TicketSeat ticketSeat32 = new TicketSeat(2, 'D', 2);
            TicketSeat ticketSeat33 = new TicketSeat(3, 'D', 3);
            TicketSeat ticketSeat34 = new TicketSeat(4, 'D', 4);
            TicketSeat ticketSeat35 = new TicketSeat(5, 'D', 5);
            TicketSeat ticketSeat36 = new TicketSeat(5, 'D', 6);
            TicketSeat ticketSeat37 = new TicketSeat(4, 'D', 7);
            TicketSeat ticketSeat38 = new TicketSeat(3, 'D', 8);
            TicketSeat ticketSeat39 = new TicketSeat(2, 'D', 9);
            TicketSeat ticketSeat40 = new TicketSeat(1, 'D', 10);
            TicketSeat ticketSeat41 = new TicketSeat(1, 'E', 11);
            TicketSeat ticketSeat42 = new TicketSeat(2, 'E', 12);
            TicketSeat ticketSeat43 = new TicketSeat(1, 'E', 2);
            TicketSeat ticketSeat44 = new TicketSeat(3, 'E', 3);
            TicketSeat ticketSeat45 = new TicketSeat(1, 'E', 4);
            TicketSeat ticketSeat46 = new TicketSeat(2, 'E', 5);
            TicketSeat ticketSeat47 = new TicketSeat(1, 'E', 6);
            TicketSeat ticketSeat48 = new TicketSeat(5, 'E', 7);
            TicketSeat ticketSeat49 = new TicketSeat(4, 'E', 8);
            TicketSeat ticketSeat50 = new TicketSeat(3, 'E', 12);

            List<TicketSeat> ticketSeats1 = new List<TicketSeat>() { ticketSeat1, ticketSeat2, ticketSeat11, ticketSeat12 };
            List<TicketSeat> ticketSeats2 = new List<TicketSeat>() { ticketSeat3, ticketSeat4, ticketSeat21, ticketSeat22 };
            List<TicketSeat> ticketSeats3 = new List<TicketSeat>() { ticketSeat33, ticketSeat40, ticketSeat23, ticketSeat28, ticketSeat22, ticketSeat18 };
            List<TicketSeat> ticketSeats4 = new List<TicketSeat>() { ticketSeat1, ticketSeat32, ticketSeat37, ticketSeat30 };
            List<TicketSeat> ticketSeats5 = new List<TicketSeat>() { ticketSeat15, ticketSeat9, ticketSeat23, ticketSeat24, ticketSeat32, ticketSeat18, ticketSeat16 };
            List<TicketSeat> ticketSeats6 = new List<TicketSeat>() { ticketSeat13, ticketSeat29, ticketSeat19, ticketSeat39, ticketSeat24, ticketSeat20, ticketSeat7 };

            Ticket ticket1 = new Ticket(user1, subotica, beograd, new DateTime(2022, 6, 12, 8, 20, 0), 4, 760, 120, train1, ticketSeats1);
            Ticket ticket11 = new Ticket(user2, staraPazova, beograd, new DateTime(2022, 6, 12, 9, 55, 0), 4, 210, 25, train1, ticketSeats2);
            Ticket ticket111 = new Ticket(user3, zrenjanin, noviSad, new DateTime(2022, 6, 15, 9, 5, 0), 6, 170, 30, train1, ticketSeats3);
            Ticket ticket1111 = new Ticket(user4, subotica, beograd, new DateTime(2022, 6, 15, 8, 20, 0), 4, 760, 120, train1, ticketSeats4);
            Ticket ticket11111 = new Ticket(user5, beograd, subotica, new DateTime(2022, 6, 12, 16, 20, 0), 7, 760, 120, train1, ticketSeats5);
            Ticket ticket111111 = new Ticket(user1, noviSad, staraPazova, new DateTime(2022, 6, 12, 9, 35, 0), 7, 150, 20, train1, ticketSeats6);
            List<Ticket> tickets1 = new List<Ticket>() { ticket1, ticket11, ticket111, ticket1111, ticket11111, ticket111111 };


            List<TicketSeat> ticketSeats7 = new List<TicketSeat>() { ticketSeat11, ticketSeat22, ticketSeat37, ticketSeat39 };
            List<TicketSeat> ticketSeats8 = new List<TicketSeat>() { ticketSeat15, ticketSeat16, ticketSeat17, ticketSeat18, ticketSeat19, ticketSeat20 };
            List<TicketSeat> ticketSeats9 = new List<TicketSeat>() { ticketSeat13, ticketSeat29, ticketSeat49, ticketSeat39, ticketSeat44, ticketSeat20, ticketSeat7 };

            Ticket ticket1111111 = new Ticket(user4, subotica, beograd, new DateTime(2022, 6, 15, 10, 0, 0), 4, 760, 120, train2, ticketSeats7);
            Ticket ticket11111111 = new Ticket(user5, beograd, subotica, new DateTime(2022, 6, 12, 17, 45, 0), 6, 760, 120, train2, ticketSeats8);
            Ticket ticket111111111 = new Ticket(user1, noviSad, staraPazova, new DateTime(2022, 6, 12, 9, 35, 0), 7, 150, 20, train2, ticketSeats9);
            List<Ticket> tickets11 = new List<Ticket>() { ticket1111111, ticket11111111, ticket111111111 };


            List<TicketSeat> ticketSeats10 = new List<TicketSeat>() { ticketSeat11};
            List<TicketSeat> ticketSeats11 = new List<TicketSeat>() { ticketSeat15, ticketSeat16 };
            List<TicketSeat> ticketSeats12 = new List<TicketSeat>() { ticketSeat13, ticketSeat29, ticketSeat49 };
            List<TicketSeat> ticketSeats13 = new List<TicketSeat>() { ticketSeat13, ticketSeat29, ticketSeat49, ticketSeat3 };

            Ticket ticket2 = new Ticket(user2, beograd1, smederevo, new DateTime(2022, 6, 12, 11, 30, 0), 1, 220, 45, train2, ticketSeats10);
            Ticket ticket22 = new Ticket(user3, beograd1, vranje, new DateTime(2022, 6, 12, 11, 30, 0), 2, 1045, 185, train2, ticketSeats11);
            Ticket ticket222 = new Ticket(user4, smederevo, jagodina, new DateTime(2022, 6, 12, 12, 15, 0), 3, 190, 30, train2, ticketSeats12);
            Ticket ticket2222 = new Ticket(user5, nis, vranje, new DateTime(2022, 6, 12, 13, 35, 0), 4, 400, 60, train2, ticketSeats13);
            List<Ticket> tickets2 = new List<Ticket>() { ticket2, ticket22, ticket222, ticket2222 };


            List<TicketSeat> ticketSeats14 = new List<TicketSeat>() { ticketSeat41, ticketSeat42, ticketSeat1, ticketSeat1, ticketSeat30 };
            List<TicketSeat> ticketSeats15 = new List<TicketSeat>() { ticketSeat15, ticketSeat16, ticketSeat45, ticketSeat46, ticketSeat20 };

            Ticket ticket22222 = new Ticket(user2, beograd1, smederevo, new DateTime(2022, 6, 12, 12, 15, 0), 5, 220, 45, train3, ticketSeats14);
            Ticket ticket222222 = new Ticket(user3, beograd1, vranje, new DateTime(2022, 6, 12, 12, 15, 0), 5, 1045, 185, train3, ticketSeats15);
            List<Ticket> tickets22 = new List<Ticket>() { ticket22222, ticket222222 };

            List<TicketSeat> ticketSeats16 = new List<TicketSeat>() { ticketSeat1, ticketSeat2, ticketSeat7, ticketSeat8, ticketSeat9 };
            List<TicketSeat> ticketSeats17 = new List<TicketSeat>() { ticketSeat11, ticketSeat16, ticketSeat15, ticketSeat6, ticketSeat17 };

            Ticket ticket2222222 = new Ticket(user4, smederevo, jagodina, new DateTime(2022, 6, 12, 16, 0, 0), 5, 190, 30, train4, ticketSeats16);
            Ticket ticket22222222 = new Ticket(user5, nis, vranje, new DateTime(2022, 6, 12, 16, 50, 0), 5, 400, 60, train4, ticketSeats17);
            List<Ticket> tickets222 = new List<Ticket>() { ticket2222222, ticket22222222 };

            List<TicketSeat> ticketSeats18 = new List<TicketSeat>() { ticketSeat5, ticketSeat10, ticketSeat14 };
            List<TicketSeat> ticketSeats19 = new List<TicketSeat>() { ticketSeat25, ticketSeat26, ticketSeat27 };
            List<TicketSeat> ticketSeats20 = new List<TicketSeat>() { ticketSeat25, ticketSeat26, ticketSeat27 };
            List<TicketSeat> ticketSeats21 = new List<TicketSeat>() { ticketSeat34, ticketSeat35, ticketSeat36 };
            List<TicketSeat> ticketSeats23 = new List<TicketSeat>() { ticketSeat31, ticketSeat38 };

            Ticket ticket3 = new Ticket(user1, bor, knjazevac, new DateTime(2022, 6, 12, 16, 20, 0), 3, 650, 80, train1, ticketSeats18);
            Ticket ticket33 = new Ticket(user2, bor, knjazevac, new DateTime(2022, 6, 12, 16, 20, 0), 3, 650, 80, train1, ticketSeats19);
            Ticket ticket333 = new Ticket(user3, knjazevac, bor, new DateTime(2022, 6, 15, 19, 0, 0), 3, 650, 80, train1, ticketSeats20);
            Ticket ticket3333 = new Ticket(user4, bor, knjazevac, new DateTime(2022, 6, 15, 16, 20, 0), 3, 650, 80, train1, ticketSeats21);
            Ticket ticket33333 = new Ticket(user5, knjazevac, bor, new DateTime(2022, 6, 16, 19, 0, 0), 2, 650, 80, train1, ticketSeats23);
            Ticket ticket333333 = new Ticket(user1, bor, knjazevac, new DateTime(2022, 6, 16, 16, 20, 0), 17, 650, 80, train1, ticketSeats1);
            List<Ticket> tickets3 = new List<Ticket>() { ticket3, ticket33, ticket333, ticket3333, ticket33333, ticket333333 };
            

            Ticket ticket3333333 = new Ticket(user1, bor, knjazevac, new DateTime(2022, 6, 12, 17, 45, 0), 3, 650, 80, train1, ticketSeats18);
            Ticket ticket33333333 = new Ticket(user2, bor, knjazevac, new DateTime(2022, 6, 12, 17, 45, 0), 3, 650, 80, train1, ticketSeats19);
            Ticket ticket333333333 = new Ticket(user3, knjazevac, bor, new DateTime(2022, 6, 15, 19, 50, 0), 3, 650, 80, train1, ticketSeats20);
            List<Ticket> tickets33 = new List<Ticket>() { ticket3333333, ticket33333333, ticket333333333 };

            List<TicketSeat> ticketSeats24 = new List<TicketSeat>() { ticketSeat1, ticketSeat2, ticketSeat3, ticketSeat4 };

            Ticket ticket3333333333 = new Ticket(user4, bor, knjazevac, new DateTime(2022, 6, 15, 18, 35, 0), 5, 650, 80, train4, ticketSeats16);
            Ticket ticket33333333333 = new Ticket(user5, knjazevac, bor, new DateTime(2022, 6, 16, 20, 20, 0), 5, 650, 80, train4, ticketSeats17);
            Ticket ticket333333333333 = new Ticket(user1, bor, knjazevac, new DateTime(2022, 6, 16, 18, 35, 0), 4, 650, 80, train4, ticketSeats24);
            List<Ticket> tickets333 = new List<Ticket>() { ticket3333333333, ticket33333333333, ticket333333333333 };

            List<TicketSeat> ticketSeats25 = new List<TicketSeat>() { ticketSeat5 };
            List<TicketSeat> ticketSeats26 = new List<TicketSeat>() { ticketSeat6 };
            List<TicketSeat> ticketSeats27 = new List<TicketSeat>() { ticketSeat7 };
            List<TicketSeat> ticketSeats28 = new List<TicketSeat>() { ticketSeat8 };

            Ticket ticket3333333333333 = new Ticket(user2, bor, knjazevac, new DateTime(2022, 6, 12, 19, 0, 0), 1, 650, 80, train4, ticketSeats25);
            Ticket ticket33333333333333 = new Ticket(user3, knjazevac, bor, new DateTime(2022, 6, 15, 22, 20, 0), 1, 650, 80, train4, ticketSeats26);
            Ticket ticket333333333333333 = new Ticket(user4, bor, knjazevac, new DateTime(2022, 6, 15, 19, 0, 0), 1, 650, 80, train4, ticketSeats27);
            Ticket ticket3333333333333333 = new Ticket(user5, knjazevac, bor, new DateTime(2022, 6, 16, 22, 20, 0), 1, 650, 80, train4, ticketSeats28);
            List<Ticket> tickets3333 = new List<Ticket>() { ticket3333333333333, ticket33333333333333, ticket333333333333333, ticket3333333333333333 };

            Ticket ticket4 = new Ticket(user2, noviSad1, kragujevac, new DateTime(2022, 6, 12, 17, 45, 0), 1, 780, 155, train2, ticketSeats10);
            Ticket ticket44 = new Ticket(user3, beograd2, kragujevac, new DateTime(2022, 6, 12, 18, 30, 0), 2, 580, 110, train2, ticketSeats11);
            Ticket ticket444 = new Ticket(user4, beograd2, kragujevac, new DateTime(2022, 6, 12, 18, 30, 0), 3, 580, 110, train2, ticketSeats12);
            List<Ticket> tickets4 = new List<Ticket>() { ticket4, ticket44, ticket444 };

            Ticket ticket5 = new Ticket(user5, sabac, staraPazova1, new DateTime(2022, 6, 12), 7, 1400, 205, train1, ticketSeats5);
            Ticket ticket55 = new Ticket(user1, staraPazova1, sabac, new DateTime(2022, 6, 12), 7, 1400, 205, train1, ticketSeats6);
            List<Ticket> tickets5 = new List<Ticket>() { ticket5, ticket55 };

            List<TicketSeat> ticketSeats29 = new List<TicketSeat>() { ticketSeat43, ticketSeat47, ticketSeat48, ticketSeat50 };

            Ticket ticket555 = new Ticket(user1, staraPazova1, sabac, new DateTime(2022, 6, 12, 22, 5, 0), 4, 1400, 205, train3, ticketSeats29);
            List<Ticket> tickets55 = new List<Ticket>() { ticket555 };

            Ticket ticket5555 = new Ticket(user1, sabac, staraPazova1, new DateTime(2022, 6, 12, 10, 0, 0), 5, 1400, 205, train3, ticketSeats14);
            List<Ticket> tickets555 = new List<Ticket>() { ticket5555 };

            Timetable timetable1 = new Timetable("Red voznje 11", train1, days1, time1, time6, tickets1);
            Timetable timetable11 = new Timetable("Red voznje 12", train2, days2, time2, time7, new List<Ticket>());
            List<Timetable> timetables1 = new List<Timetable>() { timetable1, timetable11 };

            Timetable timetable2 = new Timetable("Red voznje 21", train2, days3, time3, time9, tickets2);
            Timetable timetable22 = new Timetable("Red voznje 22", train3, days4, time4, time10, new List<Ticket>());
            Timetable timetable222 = new Timetable("Red voznje 23", train4, days5, time5, time13, tickets222);
            List<Timetable> timetables2 = new List<Timetable>() { timetable2, timetable22, timetable222 };

            Timetable timetable3 = new Timetable("Red voznje 31", train1, days6, time6, time9, tickets3);
            Timetable timetable33 = new Timetable("Red voznje 32", train1, days7, time7, time10, tickets33);
            Timetable timetable333 = new Timetable("Red voznje 33", train4, days8, time8, time11, tickets333);
            Timetable timetable3333 = new Timetable("Red voznje 34", train4, days9, time9, time14, new List<Ticket>());
            List<Timetable> timetables3 = new List<Timetable>() { timetable3, timetable33, timetable333, timetable3333 };

            Timetable timetable4 = new Timetable("Red voznje 41", train2, days10, time7, time14, tickets4);
            List<Timetable> timetables4 = new List<Timetable>() { timetable4 };

            Timetable timetable5 = new Timetable("Red voznje 51", train1, days9, time1, time11, tickets5);
            Timetable timetable55 = new Timetable("Red voznje 53", train3, days2, time3, time13, new List<Ticket>());
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

            railway.Stations.Add( subotica);
            railway.Stations.Add(zrenjanin);
            railway.Stations.Add(noviSad);
            railway.Stations.Add(staraPazova);
            railway.Stations.Add(beograd);
            railway.Stations.Add(kragujevac);
            railway.Stations.Add(smederevo);
            railway.Stations.Add(jagodina);
            railway.Stations.Add(knjazevac);
            railway.Stations.Add(bor);
            railway.Stations.Add(valjevo);
            railway.Stations.Add(mladenovac);
            railway.Stations.Add(nis);
            railway.Stations.Add(vranje);
            railway.Stations.Add(uzice);
            railway.Stations.Add(sabac);

            railway.Trains.Add(train1);
            railway.Trains.Add(train2);
            railway.Trains.Add(train3);
            railway.Trains.Add(train4);


            Data.AddRailway(railway);
            Data.SetRailwayIndex();
            Data.CurrentRailwayIndex = 0;
            Data.UpperRailwayIndexBound = 0;
            return railway;

        }

        internal static void editTrainLineTutorial(List<Dictionary<string, object>> infoBetweenStations, string name)
        {
            Railroad oldRailway = Data.RailwayStatesTutorial[Data.RailwayIndexTutorial];
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

            Data.AddRailwayTutorial(newRailway);
            Data.SetRailwayIndexTutorial();
        }

        internal static void deleteTrainRouteTutorial(string name)
        {
            Railroad oldRailway = Data.RailwayStatesTutorial[Data.RailwayIndexTutorial];
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


            Data.AddRailwayTutorial(newRailway);
            Data.SetRailwayIndexTutorial();
        }

        internal static void editTrainTutorial(Seats chosenSeats, string name, int numberOfWagons, Train oldTrain)
        {
            Railroad oldRailway = Data.RailwayStatesTutorial[Data.RailwayIndexTutorial];
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
            for (int i = 0; i < newRailway.Trains.Count; i++)
            {
                if (newRailway.Trains[i].Name == oldTrain.Name)
                {
                    newRailway.Trains[i] = train;
                }
            }
            newRailway.TrainLines = trainlines;

            Data.AddRailwayTutorial(newRailway);
            Data.SetRailwayIndexTutorial();
        }

        internal static void addNewStationTutorial(Station station)
        {
            Railroad oldRailway = Data.RailwayStatesTutorial[Data.RailwayIndexTutorial];
            Railroad newRailway = oldRailway.DeepCopy();
            newRailway.Stations.Add(station);
            Data.AddRailwayTutorial(newRailway);
            Data.SetRailwayIndexTutorial();
        }

        internal static void deleteStationTutorial(Station station)
        {
            Railroad oldRailway = Data.RailwayStatesTutorial[Data.RailwayIndexTutorial];
            Railroad newRailway = oldRailway.DeepCopy();

            newRailway.RemoveStation(station);

            List<Trainline> trainlines = new List<Trainline>();
            foreach (Trainline trainline in newRailway.TrainLines)
            {
                if (!trainline.ContainsStation(station))
                {
                    trainlines.Add(trainline);
                }
            }
            newRailway.TrainLines = trainlines;

            Data.AddRailwayTutorial(newRailway);
            Data.SetRailwayIndexTutorial();
        }

        internal static IEnumerable<Station> getStationsTutorials()
        {
            Railroad railway = Data.RailwayStatesTutorial[Data.RailwayIndexTutorial];
            return railway.Stations;
        }


        internal static List<Train> GetTrainsTutorial()
        {
            Railroad railway = Data.RailwayStatesTutorial[Data.RailwayIndexTutorial];
            return railway.Trains;
        }

        internal static void deleteTrainTutorial(Train oldTrain)
        {
            Railroad oldRailway = Data.RailwayStatesTutorial[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();
            
            List<Train> trains = new List<Train>();
            for (int i = 0; i < newRailway.Trains.Count; i++)
            {
                if (newRailway.Trains[i].Name != oldTrain.Name)
                {
                    trains.Add(newRailway.Trains[i]);
                }
            }

            newRailway.Trains = trains;

            Data.AddRailwayTutorial(newRailway);
            Data.SetRailwayIndexTutorial();
        }

        public static Station getStationByName(String stationName) {
            foreach (Station station in Data.getStations())
            {
                if (station.Name == stationName)
                    return station;
            }
            return null;
        }
        internal static void deleteStation(Station station)
        {
            Railroad oldRailway = Data.RailwayStates[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();

            newRailway.RemoveStation(station);

            List<Trainline> trainlines = new List<Trainline>();
            foreach (Trainline trainline in newRailway.TrainLines)
            {
                if (!trainline.ContainsStation(station))
                {
                    trainlines.Add(trainline);
                }
            }

            newRailway.TrainLines = trainlines;

            Data.AddRailway(newRailway);
            Data.SetRailwayIndex();
        }

        
        public static void addNewStation(Station station) {
            Railroad oldRailway = Data.RailwayStates[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();
            newRailway.Stations.Add(station);
            Data.AddRailway(newRailway);
            Data.SetRailwayIndex();
        }


        public static void updateStation(String oldStationName,Station updatedStation) {
            Railroad oldRailway = Data.RailwayStates[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();
            for (int i = 0; i < newRailway.Stations.Count; i++)
            {
                if (newRailway.Stations[i].Name == oldStationName)
                {
                    newRailway.Stations[i].Longitude = updatedStation.Longitude;
                    newRailway.Stations[i].Latitude = updatedStation.Latitude;
                    newRailway.Stations[i].Location.Latitude = updatedStation.Latitude;
                    newRailway.Stations[i].Location.Longitude = updatedStation.Longitude;
                    newRailway.Stations[i].Name = updatedStation.Name;
                }
            }
            foreach (Trainline trainline in newRailway.TrainLines)
            {
                trainline.UpdateStations(oldStationName,updatedStation);
            }

            Data.AddRailway(newRailway);
            Data.SetRailwayIndex();
        }



        public static void CreateTutorialData()
        {
            RailwayStatesTutorial = new List<Railroad>();
            Railroad railway = Data.RailwayStates[Data.CurrentRailwayIndex];
            RailwayStatesTutorial.Add(railway.DeepCopy());
            RailwayIndexTutorial = 0;
        } 

        internal static void deleteTimetable(Timetable timetable)
        {
            Railroad oldRailway = Data.RailwayStates[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();

            Trainline trainline = newRailway.FindTrainline(timetable.Trainline.Name);

            List<Timetable> timetables = new List<Timetable>();

            foreach (Timetable t in trainline.Timetables)
            {
                if (t.Name != timetable.Name)
                {
                    timetables.Add(t);
                }
            }

            trainline.Timetables = timetables;

            Data.AddRailway(newRailway);
            Data.SetRailwayIndex();
        }

        internal static void deleteTimetableTutorial(Timetable timetable)
        {
            Railroad oldRailway = Data.RailwayStatesTutorial[Data.RailwayIndexTutorial];
            Railroad newRailway = oldRailway.DeepCopy();

            Trainline trainline = newRailway.FindTrainline(timetable.Trainline.Name);

            List<Timetable> timetables = new List<Timetable>();

            foreach (Timetable t in trainline.Timetables)
            {
                if (t.Name != timetable.Name)
                {
                    timetables.Add(t);
                }
            }

            trainline.Timetables = timetables;

            Data.AddRailwayTutorial(newRailway);
            Data.SetRailwayIndexTutorial();
        }

        


        internal static void editTimetable(Train chosenTrain, DateTime chosenStartTime, DateTime chosenEndTime, List<string> days, Timetable oldTimetable)
        {
            Railroad oldRailway = Data.RailwayStates[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();

            

            List<Trainline> trainlines = newRailway.TrainLines;
            foreach (Trainline trainline in trainlines)
            {
                if (trainline.Name == oldTimetable.Trainline.Name)
                {

                    for (int i = 0; i<trainline.Timetables.Count; i++)
                    {
                        if (trainline.Timetables[i].Name.Equals(oldTimetable.Name))
                        {
                            Timetable timetable = trainline.Timetables[i].DeepCopy(trainline);
                            timetable.Train = chosenTrain;
                            timetable.TimeFromFirstStation = chosenStartTime;
                            timetable.TimeFromLastStation = chosenEndTime;
                            timetable.Days = days;
                            trainline.Timetables[i] = timetable;
                        }
                    }
                }
            }

            newRailway.TrainLines = trainlines;

            Data.AddRailway(newRailway);
            Data.SetRailwayIndex();
        }

        internal static void AddTimetable(Train chosenTrain, Trainline chosenTrainline, DateTime chosenStartTime, DateTime chosenEndTime, List<string> days)
        {
            Railroad oldRailway = Data.RailwayStates[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();

            Timetable timetable = new Timetable(chosenTrain, days, chosenStartTime, chosenEndTime);

            List<Trainline> trainlines = newRailway.TrainLines;
            foreach (Trainline trainline in trainlines)
            {
                if (trainline.Name == chosenTrainline.Name)
                {
                    timetable.Trainline = trainline;
                    trainline.Timetables.Add(timetable);

                }
            }

            newRailway.TrainLines = trainlines;

            Data.AddRailway(newRailway);
            Data.SetRailwayIndex();
        }

        public static List<Station> getStations()
        {
            Railroad railway = Data.RailwayStates[Data.CurrentRailwayIndex];
            return railway.Stations;
        }

        internal static void AddTrain(Seats chosenSeats, string name, int numberOfWagons)
        {
            Railroad oldRailway = Data.RailwayStates[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();

            Seats seats = new Seats(numberOfWagons, chosenSeats.numberOfColumns, chosenSeats.numberOfSeatsPerColumn);
            Train train = new Train(name, seats);

            newRailway.Trains.Add(train);

            Data.AddRailway(newRailway);
            Data.SetRailwayIndex();
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
            for (int i = 0; i < newRailway.Trains.Count; i++)
            {
                if (newRailway.Trains[i].Name == oldTrain.Name)
                {
                    newRailway.Trains[i] = train;
                }
            }
            newRailway.TrainLines = trainlines;
            Data.AddRailway(newRailway);
            Data.SetRailwayIndex();
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
            for (int i = 0; i < newRailway.Trains.Count; i++)
            {
                if (newRailway.Trains[i].Name != oldTrain.Name)
                {
                    trains.Add(newRailway.Trains[i]);
                }
            }
            newRailway.Trains = trains;
            newRailway.TrainLines = trainlines;
            Data.AddRailway(newRailway);
            Data.SetRailwayIndex();
        }

        public static List<Train> GetTrains()
        {
            Railroad railway = Data.RailwayStates[Data.CurrentRailwayIndex];
            return railway.Trains;

        }

        public static Train GetTrain(String name)
        {
            foreach (Train train in GetTrains())
            {
                if (train.Name.Equals(name))
                {
                    return train;
                }
            }
            return null;
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
            Data.SetRailwayIndex();
        }

        internal static void editTrainLine(List<Dictionary<string, object>> infoBetweenStations, string name)
        {
            Railroad oldRailway = Data.RailwayStates[Data.CurrentRailwayIndex];
            Railroad newRailway = oldRailway.DeepCopy();

            List<Station> stations = createStationsFromInfoBetweenStations(infoBetweenStations);

            List<Trainline> trainlines = newRailway.TrainLines;

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
            Data.SetRailwayIndex();
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

        private static void SetRailwayIndexTutorial()
        {
            Data.RailwayIndexTutorial++;           
        }
        public static void UndoTutorial()
        {
            RailwayIndexTutorial--;
        }

        public static void RedoTutorial()
        {
            RailwayIndexTutorial++;
        }

        public static bool NeedUndoTutorial()
        {
            return RailwayIndexTutorial == 1;
        }
        public static bool NeedRedoTutorial()
        {
            return RailwayIndexTutorial == 0 && RailwayStatesTutorial.Count > 1;
        }

        private static void AddRailwayTutorial(Railroad railway)
        {
            Data.RailwayStatesTutorial.Add(railway);
        }

        private static void AddRailway(Railroad railway)
        {
            if (NeedRedo())
            {
                Data.RailwayStates.RemoveRange(CurrentRailwayIndex + 1, Data.RailwayStates.Count - 1 - CurrentRailwayIndex);
            }
            Data.RailwayStates.Add(railway);
            UpperRailwayIndexBound = Data.RailwayStates.Count-2;
        }

        private static void SetRailwayIndex()
        {         
            Data.CurrentRailwayIndex++;
            UpperRailwayIndexBound++;
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
            RailwayIndex = 0;
            UpperRailwayIndexBound = 0;
            Railroad currentState = Data.RailwayStates[CurrentRailwayIndex];
            List<Railroad> currentRailroads = new List<Railroad>();
            currentRailroads.Add(currentState);
            Data.RailwayStates = currentRailroads;
            CurrentRailwayIndex = 0;
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
            Data.SetRailwayIndex();

        }

        private static List<Station> createStationsFromInfoBetweenStations(List<Dictionary<string, object>> infoBetweenStations)
        {
            Railroad railway = Data.RailwayStates[Data.CurrentRailwayIndex];
            List<Station> stations = new List<Station>();

            var info = infoBetweenStations[0];
            Station station = Data.getStationByName((string)info["startStation"]).DeepCopy();
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

                Station s = Data.getStationByName((string)info["endStation"]).DeepCopy();
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
            Data.SetRailwayIndex();
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

        public static List<ReportTicketDTO> GetMonthyReport(string month, string year)
        {
            List<ReportTicketDTO> tickets = new List<ReportTicketDTO>();
            Railroad railway = Data.RailwayStates[Data.CurrentRailwayIndex];
            foreach (Trainline trainline in railway.TrainLines)
            {
                foreach (Timetable timetable in trainline.Timetables)
                {
                    foreach (Ticket ticket in timetable.BoughtTickets)
                    {

                        if (ticket.Date.ToString("MMMM").Equals(month) && ticket.Date.Year.ToString().Equals(year))
                        {
                            tickets.Add(new ReportTicketDTO(ticket.StartStation.Name, ticket.EndStation.Name, ticket.Price, ticket.Date.ToString("dd.MM.yyyy. HH:mm'h'"), ticket.NumberOfPassengers));
                        }
                    }
                }
            }
            return tickets;
        }

        public static List<ReportTicketDTO> GetRouteReport(string trainlineName, DateTime startDate, DateTime endDate)
        {
            List<ReportTicketDTO> tickets = new List<ReportTicketDTO>();
            Railroad railway = Data.RailwayStates[Data.CurrentRailwayIndex];

            foreach (Trainline trainline in railway.TrainLines)
            {
                if (!trainline.Name.Equals(trainlineName))
                    continue;
                foreach (Timetable timetable in trainline.Timetables)
                {
                    foreach (Ticket ticket in timetable.BoughtTickets)
                    {
                        DateTime date = ticket.Date;
                        if (date >= startDate && date <= endDate)
                        {
                            tickets.Add(new ReportTicketDTO(ticket.StartStation.Name, ticket.EndStation.Name, ticket.Price, ticket.Date.ToString("dd.MM.yyyy. HH:mm'h'"), ticket.NumberOfPassengers));
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

        public static List<Trainline> GetTrainLinesTutorial()
        {
            Railroad railway = Data.RailwayStatesTutorial[Data.RailwayIndexTutorial];
            return railway.TrainLines;
        }

        public static Trainline GetTrainLine(String name)
        {
            foreach (Trainline trainline in GetTrainLines())
            {
                if (trainline.Name == name)
                {
                    return trainline;
                }
            }
            return null;
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

        public static bool canBeDeleted(Trainline trainline)
        {
            

            foreach (Timetable timetable in trainline.Timetables)
            {
                if (timetable.BoughtTickets.Count > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool canBeDeleted(Timetable timetable)
        {
            if (timetable.BoughtTickets.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}
