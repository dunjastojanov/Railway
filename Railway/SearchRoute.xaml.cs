using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Railway.model;
using Railway.Model;
namespace Railway
{
    /// <summary>
    /// Interaction logic for SearchRoute.xaml
    /// </summary>
    public partial class SearchRoute : Page
    {
        public string numberOfTickets = "1";
        public string StartStation { get; set; }
        public string EndStation { get; set; }
        public DateTime Date { get; set; }
        public MainWindow MainWindow { get; set; }
        public BuyTicket BuyTicket { get; set; }
        public User LogedUser { get; set; }
        public SearchRoute(MainWindow mainWindow, User logedUser)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            LogedUser = logedUser;
            List<string> stationNames = Data.GetStationNames();
            {
                foreach (string stationName in stationNames)
                {
                    from.Items.Add(stationName);
                    to.Items.Add(stationName);
                }
            };
            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            travelDate.BlackoutDates.Add(cdr);
        }

        private void plusTicket_Click(object sender, RoutedEventArgs e)
        {
            numberOfTickets = ticketsNum.Text;
            var numberOfTicketsInt = Int64.Parse(numberOfTickets);
            numberOfTicketsInt++;
            numberOfTickets = numberOfTicketsInt.ToString();
            ticketsNum.Text = numberOfTickets;
        }

        private void minusTicket_Click(object sender, RoutedEventArgs e)
        {
            numberOfTickets = ticketsNum.Text;
            var numberOfTicketsInt = Int64.Parse(numberOfTickets);
            if (numberOfTicketsInt > 1)
            {
                numberOfTicketsInt--;
                numberOfTickets = numberOfTicketsInt.ToString();
                ticketsNum.Text = numberOfTickets;
            }
        }

        private void searchRoute_Click(object sender, RoutedEventArgs e)
        {
            StartStation = from.Text;
            EndStation = to.Text;
            if (StartStation == "")
            {
                MessageBox.Show("Please enter staring station.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (EndStation == "")
            {
                MessageBox.Show("Please enter ending station.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (StartStation.Equals(EndStation))
            {
                MessageBox.Show("Starting and ending stations must be different.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                Date = DateTime.Parse(travelDate.Text);
            }
            catch
            {
                MessageBox.Show("Please eneter travelling date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            List<QuickReservation> quickReservations = GetQuickReservations();
            if (quickReservations == null)
            {
                MessageBox.Show("There is no direct route for searched trains. Please enter different stations.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (quickReservations.Count() == 0)
            {
                MessageBox.Show("There are no available trains on the required route for the date. Please try again with different parameters.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            BuyTicket = new BuyTicket(MainWindow, ref quickReservations, Date, Int32.Parse(numberOfTickets), LogedUser);
            MainWindow.ShowBuyTicket(BuyTicket);
        }
        public List<QuickReservation> GetQuickReservations()
        {
            return Data.GetQuickReservations(StartStation, EndStation, Date, Int32.Parse(numberOfTickets));
        }
    }
}

