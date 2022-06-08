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
    /// Interaction logic for TicketHistory.xaml
    /// </summary>
    public partial class TicketHistory : Page
    {
        public User LogedUser { get; set; }
        public List<Ticket> BoughtTickets { get; set; }
        public TicketHistory(User logedUser)
        {
            InitializeComponent();
            LogedUser = logedUser;          
            DisplayTickets();
        }
        private void DisplayTickets()
        {
            BoughtTickets = Data.GetBoughtTickets(LogedUser);
            int row = 1;
     
            foreach (Ticket ticket in BoughtTickets)
            {
                DisplayTicketHistory.Height += 210;
                var margine = new RowDefinition();
                margine.Height = new GridLength(10, GridUnitType.Pixel);
                DisplayTicketHistory.RowDefinitions.Add(margine);
                var ticketRow = new RowDefinition();
                ticketRow.Height = new GridLength(190, GridUnitType.Pixel);
                DisplayTicketHistory.RowDefinitions.Add(ticketRow);
                Grid grid = new Grid();

                Border border = MakeBorder();
                Grid.SetColumn(border, 0);
                Grid.SetRow(border, 0);
                Grid.SetColumnSpan(border, 5);
                Grid.SetRowSpan(border, 7);
                grid.Children.Add(border);

                AddContent(grid, ticket);
                Grid.SetRow(grid, row);
                Grid.SetColumn(grid, 1);
                DisplayTicketHistory.Children.Add(grid);
                row += 2;
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
        private void AddContent(Grid grid, Ticket ticket)
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
            trainName.Content = ticket.Train.Name;
            trainName.FontSize = 18;
            trainName.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumn(trainName, 0);
            Grid.SetRow(trainName, 4);
            grid.Children.Add(trainName);

            Label departure = new Label();
            departure.Content = ticket.Date.Hour.ToString("D2") + ":" + ticket.Date.Minute.ToString("D2") + "h" + "\n" + ticket.Date.Day.ToString("d2") + ". " + ticket.Date.Month.ToString("d2") + ". " + ticket.Date.Year + "." + "\n" + ticket.StartStation.Name;
            departure.FontSize = 15;
            departure.VerticalAlignment = VerticalAlignment.Top;
            departure.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumn(departure, 1);
            Grid.SetRow(departure, 2);
            Grid.SetRowSpan(departure, 3);
            grid.Children.Add(departure);

            Label duration = new Label();
            duration.Content = ticket.Duration + " minutes";
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
            DateTime arrivalTime = ticket.Date.AddMinutes(ticket.Duration);
            arrival.Content = arrivalTime.Hour.ToString("D2") + ":" + arrivalTime.Minute.ToString("D2") + "h" + "\n" + arrivalTime.Day.ToString("d2") + ". " + arrivalTime.Month.ToString("d2") + ". " + arrivalTime.Year + "." + "\n" + ticket.EndStation.Name;
            arrival.FontSize = 15;
            arrival.VerticalAlignment = VerticalAlignment.Top;
            arrival.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumn(arrival, 3);
            Grid.SetRow(arrival, 2);
            Grid.SetRowSpan(arrival, 3);
            grid.Children.Add(arrival);

            Label passengersLabel = new Label();
            passengersLabel.Content = "Number of seats:";
            passengersLabel.HorizontalAlignment = HorizontalAlignment.Center;
            passengersLabel.FontSize = 15;
            
            Grid.SetColumn(passengersLabel, 1);
            Grid.SetColumnSpan(passengersLabel, 2);
            Grid.SetRow(passengersLabel, 5);
            grid.Children.Add(passengersLabel);

            Label passengers = new Label();
            passengers.Content = ticket.NumberOfPassengers;
            passengers.HorizontalAlignment = HorizontalAlignment.Left;
            passengers.FontSize = 17;
            Grid.SetColumn(passengers, 3);
            Grid.SetRow(passengers, 5);
            grid.Children.Add(passengers);

            Label price = new Label();
            price.Content = ticket.Price + " rsd";
            price.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ee964b"));
            price.FontSize = 18;
            price.VerticalAlignment = VerticalAlignment.Top;
            price.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetColumn(price, 4);
            Grid.SetRow(price, 1);
            Grid.SetRowSpan(price, 2);
            grid.Children.Add(price);         
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
        public void RefreshPage()
        {
            DisplayTicketHistory.Children.RemoveRange(0, DisplayTicketHistory.Children.Count);
            DisplayTicketHistory.Height = 0;
            this.DisplayTickets();
        }
    }
}
