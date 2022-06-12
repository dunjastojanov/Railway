﻿using Railway.model;
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
using System.Windows.Shapes;

namespace Railway
{
    /// <summary>
    /// Interaction logic for ChooseSeat.xaml
    /// </summary>
    public partial class ChooseSeat : Window
    {
        BuyTicket BuyTicket { get; set; }
        List<Ticket> BoughtTickets { get; set; }
        Train Train { get; set; }
        public int SeatToTake { get; set; }
        public List<TicketSeat> ChosenSeats { get; set; }
        public ChooseSeat(BuyTicket buyTicket, List<Ticket> tickets, Train train, int seats)
        {
            InitializeComponent();
            BuyTicket = buyTicket;
            BoughtTickets = tickets;
            SeatToTake = seats;
            Train = train;
            seatsLeft.Content = seats.ToString();
            ChosenSeats = new List<TicketSeat>();
            for (int i = 1; i < train.seats.numberOfWagons; i++)
                wagonNum.Items.Add(i);
        }
        public void ShowTrain_Button_Click(object sender, RoutedEventArgs e)
        {
            int wagon = (int)wagonNum.SelectedValue;
            ChooseTrainSeats chooseSeat = new ChooseTrainSeats(this, Train.seats, wagon, filterTakenSeats(wagon));
            trainFrame.Content = chooseSeat;
            
        }
        public void DecreaseSeats()
        {
            SeatToTake--;
            seatsLeft.Content = SeatToTake.ToString();
        }
        private List<TicketSeat> filterTakenSeats(int wagon)
        {
            List<TicketSeat> ticketSeats = new List<TicketSeat>();
            foreach (Ticket ticket in BoughtTickets)
            {
                foreach (TicketSeat ticketSeat in ticket.TicketSeats)
                {
                    if (ticketSeat.Wagon == wagon)
                        ticketSeats.Add(ticketSeat);
                }
            }
            return ticketSeats;
        }

        private void saveSeats_Click(object sender, RoutedEventArgs e)
        {
            if (ChosenSeats.Count == 0 || SeatToTake > 0)
            {
                MessageBox.Show("Please choose seats.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int response = (int)MessageBox.Show("Are you sure you want to save chosen seats?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == 6)
            {
                BuyTicket.BoughtSeats = ChosenSeats;
                MessageBox.Show("Seats successfully chosen!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Choosing seats cancelled successfully.", "Cancellation successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
