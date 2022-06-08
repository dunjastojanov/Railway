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
        public SearchRoute SearchRoute { get; set; }
        public TicketHistory TicketHistory { get; set; }
        public Login Login { get; set; }
        public AdminPage AdminPage {get; set;}
        public ReadTrainRoute ReadTrainRoute { get; set; }
        public ReadTrain ReadTrain { get; set; }
        public ReadTimetable ReadTimetable { get; set; }
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
            TicketHistory = new TicketHistory(logedUser);
        }
        public void InitializeManagerComponents()
        {
            AddNavbar();
            CreateAdminNavbar();
            AdminPage = new AdminPage();
            ReadTrainRoute = new ReadTrainRoute(this);
            ReadTrain = new ReadTrain(this);
            ReadTimetable = new ReadTimetable(this);
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
            routes.Content = "Routes";
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
            schedules.Content = "Schedules";
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

            navButtons.Children.Add(searchTicket);
            navButtons.Children.Add(ticketHistory);
        }
        public void ShowLogin()
        {
            Data.ResetCurrentIndex();
            Login.emailTextBox.Text = "";
            MainFrame.Content = Login;
            CurrentPage = "Login";
            DeleteNavbar();
        }

        public void DeleteNavbar()
        {
            window.Children.Remove(navbar);
        }

        public void AddNavbar()
        {
            window.Children.Add(navbar);
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

        /* public void TryDisableUndoRedo()
         {
             if (!Data.NeedUndo())
                 Undo.IsEnabled = false;
             else
                 Undo.IsEnabled = true;
             if (!Data.NeedRedo())
                 Redo.IsEnabled = false;
             else
                 Redo.IsEnabled = true;
         }*/
        public void AddUndoRedoButtons(StackPanel panel)
        {
           
          /*  Undo = new Button();
            Undo.BorderThickness = new Thickness(0);
            Undo.Width = 100;
            Undo.FontSize = 18;
            Undo.Content = "Undo";
            Undo.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            Undo.Foreground = Brushes.FloralWhite;
            Undo.Click += Button_Click_Undo;

            Redo = new Button();
            Redo.BorderThickness = new Thickness(0);
            Redo.Width = 100;
            Redo.FontSize = 18;
            Redo.Content = "Redo";
            Redo.Background = new SolidColorBrush(Color.FromRgb(0, 176, 255));
            Redo.Foreground = Brushes.FloralWhite;
            Redo.Click += Button_Click_Redo;


            panel.Children.Add(Undo);
            panel.Children.Add(Redo);

            TryDisableUndoRedo();*/
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

        }

        private void Schedules_Click(object sender, RoutedEventArgs e)
        {
            ShowReadTimetable(true);
        }
     

        private void Button_Click_Logout(object sender, RoutedEventArgs e)
        {
            ShowLogin();
        }
    }
}
