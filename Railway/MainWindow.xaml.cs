using Railway.model;
using Railway.Model;
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

namespace Railway
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string CurrentPage { get; set; }

        internal void doThings(string param)
        {
            throw new NotImplementedException();
        }

        public SearchRoute SearchRoute { get; set; }
        public TicketHistory TicketHistory { get; set; }
        public Login Login { get; set; }
        public AdminPage AdminPage {get; set;}
        public ReadTrainRoute ReadTrainRoute { get; set; }
        public ReadTrainRoute ReadTrainRouteUser { get; set; }
        public ReadTrain ReadTrain { get; set; }
        public ReadTimetable ReadTimetable { get; set; }
        public ReadTimetable ReadTimetableUser { get; set; }
        public ReadStations ReadStations { get; set; }
        public Reports Reports { get; set; }
        public Frame Frame { get; set; }    
        public User LogedUser { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            Data.FillData();
            Login = new Login(MainFrame, this);
            ShowLogin();                 
            Frame = MainFrame;                         
        }
        public void InitializeUserComponents(User logedUser)
        {
            LogedUser = logedUser;
            AddNavbar();
            CreateUserNavbar();
            SearchRoute = new SearchRoute(this, logedUser);
            TicketHistory = new TicketHistory(logedUser, this);
            ReadTimetableUser = new ReadTimetable(this, "user");
            ReadTrainRouteUser = new ReadTrainRoute(this, "user");
        }
        public void InitializeManagerComponents()
        {
            AddNavbar();
            CreateAdminNavbar();
            AdminPage = new AdminPage();
            ReadTrainRoute = new ReadTrainRoute(this);
            ReadTrain = new ReadTrain(this);
            ReadTimetable = new ReadTimetable(this);
            ReadStations = new ReadStations(this);
            Reports = new Reports(this);
        }
       
        public void ShowAdminHomePage()
        {         
            MainFrame.Content = AdminPage;
            Data.ResetCurrentIndex();
            CurrentPage = "adminHomePage";
        }
        public void CreateAdminNavbar()
        {
            navButtons.Children.RemoveRange(0, navButtons.Children.Count);

            Button routes = new Button();
            routes.BorderThickness = new Thickness(0);
            routes.Height = 35;
            routes.HorizontalAlignment = HorizontalAlignment.Stretch;
            routes.FontSize = 15;
            routes.Content = "Trainlines";
            routes.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            routes.Foreground = Brushes.FloralWhite;
            routes.Click += Routes_Click;

            Button trains = new Button();
            trains.BorderThickness = new Thickness(0);
            trains.Height = 35;
            trains.HorizontalAlignment = HorizontalAlignment.Stretch;
            trains.FontSize = 15;
            trains.Content = "Trains";
            trains.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            trains.Foreground = Brushes.FloralWhite;
            trains.Click += Trains_Click;

            Button stations = new Button();
            stations.BorderThickness = new Thickness(0);
            stations.Height = 35;
            stations.HorizontalAlignment = HorizontalAlignment.Stretch;
            stations.FontSize = 15;
            stations.Content = "Stations";
            stations.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            stations.Foreground = Brushes.FloralWhite;
            stations.Click += Stations_Click;

            Button schedules = new Button();
            schedules.BorderThickness = new Thickness(0);
            schedules.Height = 35;
            schedules.HorizontalAlignment = HorizontalAlignment.Stretch;
            schedules.FontSize = 15;
            schedules.Content = "Timetables";
            schedules.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            schedules.Foreground = Brushes.FloralWhite;
            schedules.Click += Schedules_Click;

            Button reports = new Button();
            reports.BorderThickness = new Thickness(0);
            reports.Height = 35;
            reports.HorizontalAlignment = HorizontalAlignment.Stretch;
            reports.FontSize = 15;
            reports.Content = "Reports";
            reports.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            reports.Foreground = Brushes.FloralWhite;
            reports.Click += Reports_Click;

            navButtons.Children.Add(routes);
            navButtons.Children.Add(trains);
            navButtons.Children.Add(stations);
            navButtons.Children.Add(schedules);
            navButtons.Children.Add(reports);

        }
        public void CreateUserNavbar()
        {
            navButtons.Children.RemoveRange(0, navButtons.Children.Count);

            Button searchTicket = new Button();
            searchTicket.BorderThickness = new Thickness(0);
            searchTicket.Height = 35;
            searchTicket.FontSize = 15;
            searchTicket.Content = "Search ticket";
            searchTicket.HorizontalAlignment = HorizontalAlignment.Stretch;
            searchTicket.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            searchTicket.Foreground = Brushes.FloralWhite;
            searchTicket.Click += Button_Click_ShowSearchRoute;

            Button ticketHistory = new Button();
            ticketHistory.BorderThickness = new Thickness(0);
            ticketHistory.Height = 35;
            ticketHistory.HorizontalAlignment = HorizontalAlignment.Stretch;
            ticketHistory.FontSize = 15;
            ticketHistory.Content = "Ticket history";
            ticketHistory.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            ticketHistory.Foreground = Brushes.FloralWhite;
            ticketHistory.Click += Button_Click_ShowTicketHistory;

            Button routes = new Button();
            routes.BorderThickness = new Thickness(0);
            routes.Height = 35;
            routes.HorizontalAlignment = HorizontalAlignment.Stretch;
            routes.FontSize = 15;
            routes.Content = "Trainlines";
            routes.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            routes.Foreground = Brushes.FloralWhite;
            routes.Click += RoutesUser_Click;

            Button schedules = new Button();
            schedules.BorderThickness = new Thickness(0);
            schedules.Height = 35;
            schedules.HorizontalAlignment = HorizontalAlignment.Stretch;
            schedules.FontSize = 15;
            schedules.Content = "Timetables";
            schedules.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            schedules.Foreground = Brushes.FloralWhite;
            schedules.Click += SchedulesUser_Click;

            navButtons.Children.Add(searchTicket);
            navButtons.Children.Add(ticketHistory);
            navButtons.Children.Add(routes);
            navButtons.Children.Add(schedules);
        }
        public void ShowLogin()
        {
            Data.ResetCurrentIndex();
            Login.emailTextBox.Text = "";
            MainFrame.Content = Login;
            CurrentPage = "Login";
            DeleteNavbar();
        }


        public void ShowSearchRoute()
        {        
            MainFrame.Content = SearchRoute;
            CurrentPage = "SearchRoute";
            Data.ResetCurrentIndex();
        }

        public void ShowReports()
        {
            MainFrame.Content = Reports;
            CurrentPage = "Reports";
            Data.ResetCurrentIndex();       
        }

        public void ShowBuyTicket(BuyTicket buyTicket)
        {
            Data.ResetCurrentIndex();
            CurrentPage = "BuyTickets";
            MainFrame.Content = buyTicket;
        }

        public void ShowReadTrainRoute(bool needsReset)
        {
            if (needsReset)
                Data.ResetCurrentIndex();
            CurrentPage = "ReadTrainRoute";
            ReadTrainRoute.RefreshPage();
            MainFrame.Content = ReadTrainRoute;
        }

        public void ShowReadTrain(bool needsReset)
        {
            if (needsReset)
                Data.ResetCurrentIndex();
            CurrentPage = "ReadTrain";
            ReadTrain.RefreshPage();
            MainFrame.Content = ReadTrain;
        }

        public void ShowReadTimetable(bool needsReset)
        {
            if (needsReset)
                Data.ResetCurrentIndex();
            CurrentPage = "ReadTimetable";
            ReadTimetable.RefreshPage();
            MainFrame.Content = ReadTimetable;
        }

        public void ShowReadStations(bool needsReset)
        {
            if (needsReset)
                Data.ResetCurrentIndex();
            CurrentPage = "ReadStations";
            ReadStations.RefreshPage();
            MainFrame.Content = ReadStations;
        }

        public void DeleteNavbar()
        {
            window.Children.Clear();         
            Grid.SetColumn(MainFrame, 0);
            Grid.SetColumnSpan(MainFrame, 2);
            
            window.Children.Add(MainFrame);
        }

        public void AddNavbar()
        {
            window.Children.Clear();
            Grid.SetColumn(navbar, 0);
            Grid.SetColumnSpan(navbar, 1);
            window.Children.Add(navbar);
            Grid.SetColumn(MainFrame, 1);
            Grid.SetColumnSpan(MainFrame, 1);
            window.Children.Add(MainFrame);
        }
        private void Button_Click_ShowSearchRoute(object sender, RoutedEventArgs e)
        {       
            MainFrame.Content = SearchRoute;
        }
        private void Button_Click_ShowTicketHistory(object sender, RoutedEventArgs e)
        {         
            TicketHistory.RefreshPage();
            MainFrame.Content = TicketHistory;
        }

        private void Routes_Click(object sender, RoutedEventArgs e)
        {
            ShowReadTrainRoute(true);
        }
        private void RoutesUser_Click(object sender, RoutedEventArgs e)
        {
            ReadTrainRouteUser.RefreshPage();
            MainFrame.Content = ReadTrainRouteUser;
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {           
            ShowReports();
        }

        private void Trains_Click(object sender, RoutedEventArgs e)
        {
            ShowReadTrain(true);
        }

        private void Stations_Click(object sender, RoutedEventArgs e)
        {
            ShowReadStations(true);
        }

        private void Schedules_Click(object sender, RoutedEventArgs e)
        {
            ShowReadTimetable(true);
        }

        private void SchedulesUser_Click(object sender, RoutedEventArgs e)
        {
            ReadTimetableUser.RefreshPage();
            MainFrame.Content = ReadTimetableUser;
        }


        private void Button_Click_Logout(object sender, RoutedEventArgs e)
        {
            ShowLogin();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
        }

    }
}
