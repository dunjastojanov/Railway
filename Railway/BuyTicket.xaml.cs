using Railway.model;
using Railway.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for BuyTicket.xaml
    /// </summary>
    public partial class BuyTicket : Page
    {      
        public List<QuickReservation> QuickReservations { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfPassengers { get; set; }
        public User LogedUser { get; set; }
        public MainWindow MainWindow { get; set; }
        public BuyTicket(MainWindow mainWindow, ref List<QuickReservation> quickReservations, DateTime date, int numberOfPassengers, User logedUser)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            QuickReservations = quickReservations;
            LogedUser = logedUser;
            Date = date;
            NumberOfPassengers = numberOfPassengers;
            DisplayQuickReservations();
        }

        private void DisplayQuickReservations()
        {
            int row = 1;
            bool addedQuickReservation = false;
            foreach (QuickReservation reservation in QuickReservations)
            {
                if (!reservation.Timetable.HaveTicketsAvailable(reservation.FirstStation, reservation.LastStation, Date, NumberOfPassengers))
                {
                    continue;
                }
                addedQuickReservation = true;              
                DisplayBuyTicket.Height += 210;
                var margine = new RowDefinition();
                margine.Height = new GridLength(10, GridUnitType.Pixel);
                DisplayBuyTicket.RowDefinitions.Add(margine);
                var ticketRow = new RowDefinition();
                ticketRow.Height = new GridLength(190, GridUnitType.Pixel);
                DisplayBuyTicket.RowDefinitions.Add(ticketRow);
                Grid grid = new Grid();

                Border border = MakeBorder();
                Grid.SetColumn(border, 0);
                Grid.SetRow(border, 0);
                Grid.SetColumnSpan(border, 5);
                Grid.SetRowSpan(border, 7);
                grid.Children.Add(border);

                AddContent(grid, reservation); 
                Grid.SetRow(grid, row);
                Grid.SetColumn(grid, 1);
                DisplayBuyTicket.Children.Add(grid);
                row += 2;
            }
            if (!addedQuickReservation)
            {
                MessageBox.Show("Unfortunately, all tickets for this route are bought, please search again for other routes.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                MainWindow.ShowSearchRoute();
            }
        }
        private Border MakeBorder()
        {
            Border border = new Border();
            border.BorderBrush = new SolidColorBrush(Color.FromRgb(30, 30, 30));
            border.Opacity = 1;
            border.CornerRadius = new CornerRadius(8, 8, 8, 8);
            border.BorderThickness = new Thickness(1);
            return border;
        }
        private void AddContent(Grid grid, QuickReservation reservation)
        {
            CreateRowsAndCols(grid);

            Image trainImg = new Image();
            var path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string p = path.Substring(0, path.Length - 10);
            string uriPath = p + "\\images\\train.png";
            trainImg.Source = new BitmapImage(new Uri(uriPath));
            trainImg.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumn(trainImg, 0);
            Grid.SetRow(trainImg, 2);    
            Grid.SetRowSpan(trainImg, 2);
            grid.Children.Add(trainImg);

            Label trainName = new Label();
            trainName.Content = reservation.Timetable.Train.Name;          
            trainName.FontSize = 18;
            trainName.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumn(trainName, 0);
            Grid.SetRow(trainName, 4);       
            grid.Children.Add(trainName);

            Label departure = new Label();
            departure.Content = reservation.DepartureTime.Hour.ToString("D2") + ":" + reservation.DepartureTime.Minute.ToString("D2") + "h" + "\n" + reservation.DepartureTime.Day.ToString("d2") + ". " + reservation.DepartureTime.Month.ToString("d2") + ". " + reservation.DepartureTime.Year + "." + "\n" + reservation.FirstStation;        
            departure.FontSize = 15;
            departure.VerticalAlignment = VerticalAlignment.Top;
            departure.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumn(departure, 1);
            Grid.SetRow(departure, 2);
            Grid.SetRowSpan(departure, 3);
            grid.Children.Add(departure);

            Label duration = new Label();
            duration.Content = reservation.Duration + " minutes";   
            duration.FontSize = 13;
            duration.VerticalAlignment = VerticalAlignment.Bottom;
            duration.HorizontalAlignment = HorizontalAlignment.Center;
            duration.VerticalContentAlignment = VerticalAlignment.Bottom;
            Grid.SetColumn(duration, 2);
            Grid.SetRow(duration, 2);
            grid.Children.Add(duration);

            Image arrowImg = new Image();
            string uriPathArrow = p + "\\images\\arrow.png";
            arrowImg.Source = new BitmapImage(new Uri(uriPathArrow));
            arrowImg.HorizontalAlignment = HorizontalAlignment.Center;
            arrowImg.VerticalAlignment = VerticalAlignment.Top;
            arrowImg.Width = 25;
            
            Grid.SetColumn(arrowImg, 2);
            Grid.SetRow(arrowImg, 3);
            grid.Children.Add(arrowImg);

            Label arrival = new Label();
            arrival.Content = reservation.ArrivalTime.Hour.ToString("D2") + ":" + reservation.ArrivalTime.Minute.ToString("D2") + "h" + "\n" + reservation.ArrivalTime.Day.ToString("d2") + ". " + reservation.ArrivalTime.Month.ToString("d2") + ". " + reservation.ArrivalTime.Year + "." + "\n" + reservation.LastStation;
            arrival.FontSize = 15;
            arrival.VerticalAlignment = VerticalAlignment.Top;
            arrival.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumn(arrival, 3);
            Grid.SetRow(arrival, 2);
            Grid.SetRowSpan(arrival, 3);
            grid.Children.Add(arrival);

            ComboBox stations = new ComboBox();
            foreach (string station in reservation.AllStations)
                stations.Items.Add(station);
            stations.IsEditable = true;
            stations.IsReadOnly = true;
            stations.Text = "Stanice";
            stations.FontSize = 15;
            Grid.SetColumn(stations, 2);
            Grid.SetRow(stations, 5);         
            grid.Children.Add(stations);

            Label price = new Label();
            price.Content = reservation.Price + " rsd";
            price.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ee964b"));     
            price.FontSize = 18;
            price.VerticalAlignment = VerticalAlignment.Top;
            price.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetColumn(price, 4);
            Grid.SetRow(price, 1);
            Grid.SetRowSpan(price, 2);
            grid.Children.Add(price);

            Button buy = new Button();
            buy.Content = "Buy";
            buy.Tag = reservation;
            buy.FontSize = 18;
            buy.Foreground = Brushes.White;
            buy.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ee964b"));
            buy.HorizontalAlignment = HorizontalAlignment.Left;
            buy.Width = 75;
            buy.Click += BuyTicket_Click;
            Grid.SetColumn(buy, 4);
            Grid.SetRow(buy, 5);
            grid.Children.Add(buy);
        }
        private void BuyTicket_Click(object sender, RoutedEventArgs e)
        {
            QuickReservation reservation = (QuickReservation)((Button)sender).Tag;
            Station firstStation = reservation.Trainline.getStation(reservation.FirstStation);
            Station lastStation = reservation.Trainline.getStation(reservation.LastStation);
            DateTime ticketDate = new DateTime(Date.Year, Date.Month, Date.Day, reservation.DepartureTime.Hour, reservation.DepartureTime.Minute, 0);
            Ticket ticket = new Ticket(LogedUser, firstStation, lastStation, ticketDate, NumberOfPassengers, reservation.Price, reservation.Duration, reservation.Timetable.Train);
            string parameters = "Departure: " + reservation.DepartureTime.ToString("dd.MM.yyyy. HH:mm'h'") + ", " + reservation.FirstStation  + "\nArrival: " + reservation.ArrivalTime.ToString("dd.MM.yyyy. HH:mm'h'") + ", " + reservation.LastStation + "\nPrice: " + reservation.Price  + " rsd" + "\nDuration: " + reservation.Duration + " minutes";
            int response = (int)MessageBox.Show("Are you sure you want to buy ticket with these parameters?\n" + parameters, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                //BEZ UNDO I REDO:
                reservation.Timetable.BoughtTickets.Add(ticket);
              
                // SA UNDO I REDO
                //QuickReservations = Data.BuyTicket(reservation, ticket, firstStation.Name, lastStation.Name, Date, NumberOfPassengers);
                
                MessageBox.Show("Ticket successfully bought!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                RefreshPage();
            }
            else
            {
                MessageBox.Show("Buying ticket cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public void RefreshPage()
        {
            //MainWindow.TryDisableUndoRedo();
            DisplayBuyTicket.Children.RemoveRange(0, DisplayBuyTicket.Children.Count);
            DisplayBuyTicket.Height = 0;
            this.DisplayQuickReservations();
        }
        private void CreateRowsAndCols(Grid grid)
        {
            addColumnStars(grid, 20); //voz 0
            addColumnStars(grid, 30); //pocetna stanica 1
            addColumnStars(grid, 20); //strelica i stanice 2
            addColumnStars(grid, 30); //krajnja stanica 3
            addColumnStars(grid, 20); //cena i kupi dugme 4

            addRowStars(grid, 10); //margina 0
            addRowStars(grid, 14); //vreme 1
            addRowStars(grid, 22); //vreme 2
            addRowStars(grid, 12); //vreme 3
            addRowStars(grid, 20); //razmak 4
            addRowStars(grid, 16); //stanice izmedju i kupi dugme 5
            addRowStars(grid, 6); //margina 6
        }
        private void addRowStars(Grid grid, double percentage)
        {
            var rd = new RowDefinition();
            rd.Height = new GridLength(percentage, GridUnitType.Star);
            grid.RowDefinitions.Add(rd);
        }

        private void addColumnStars(Grid grid, double percentage)
        {
            var cd = new ColumnDefinition();
            cd.Width = new GridLength(percentage, GridUnitType.Star);
            grid.ColumnDefinitions.Add(cd);
        }
    }
}
