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
        public Button Trainlines { get; set; }
        public Button Trains { get; set; }
        public Button Timetables { get; set; }
        public Button Stations { get; set; }
        public Button ReportsButton { get; set; }
        public Button Tutorials { get; set; }
        
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
            logOut.Children.Remove(Tutorials);
            Trainlines = new Button();
            Trainlines.BorderThickness = new Thickness(0);
            Trainlines.Height = 35;
            Trainlines.HorizontalAlignment = HorizontalAlignment.Stretch;
            Trainlines.FontSize = 15;
            Trainlines.Content = "Trainlines";
            Trainlines.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            Trainlines.Foreground = Brushes.FloralWhite;
            Trainlines.Click += Routes_Click;

            Trains = new Button();
            Trains.BorderThickness = new Thickness(0);
            Trains.Height = 35;
            Trains.HorizontalAlignment = HorizontalAlignment.Stretch;
            Trains.FontSize = 15;
            Trains.Content = "Trains";
            Trains.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            Trains.Foreground = Brushes.FloralWhite;
            Trains.Click += Trains_Click;

            Stations = new Button();
            Stations.BorderThickness = new Thickness(0);
            Stations.Height = 35;
            Stations.HorizontalAlignment = HorizontalAlignment.Stretch;
            Stations.FontSize = 15;
            Stations.Content = "Stations";
            Stations.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            Stations.Foreground = Brushes.FloralWhite;
            Stations.Click += Stations_Click;

            Timetables = new Button();
            Timetables.BorderThickness = new Thickness(0);
            Timetables.Height = 35;
            Timetables.HorizontalAlignment = HorizontalAlignment.Stretch;
            Timetables.FontSize = 15;
            Timetables.Content = "Timetables";
            Timetables.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            Timetables.Foreground = Brushes.FloralWhite;
            Timetables.Click += Schedules_Click;

            ReportsButton = new Button();
            ReportsButton.BorderThickness = new Thickness(0);
            ReportsButton.Height = 35;
            ReportsButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            ReportsButton.FontSize = 15;
            ReportsButton.Content = "Reports";
            ReportsButton.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            ReportsButton.Foreground = Brushes.FloralWhite;
            ReportsButton.Click += Reports_Click;

            navButtons.Children.Add(Trainlines);
            navButtons.Children.Add(Trains);
            navButtons.Children.Add(Stations);
            navButtons.Children.Add(Timetables);
            navButtons.Children.Add(ReportsButton);

            Tutorials = new Button();
            Tutorials.Name = "tutorial";
            Tutorials.BorderThickness = new Thickness(0);
            Tutorials.Height = 35;
            Tutorials.HorizontalAlignment = HorizontalAlignment.Stretch;
            Tutorials.FontSize = 15;
            Tutorials.Content = "Tutorial";
            Tutorials.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            Tutorials.Foreground = Brushes.FloralWhite;
            Tutorials.Click += Tutorial_Click;           
            logOut.Children.Remove(logOutButton);
            logOut.Children.Add(Tutorials);
            logOut.Children.Add(logOutButton);

        }
        public void CreateUserNavbar()
        {
            navButtons.Children.RemoveRange(0, navButtons.Children.Count);
            logOut.Children.Remove(Tutorials);

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
        private void Tutorial_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new TutorialHomePage(this);
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
