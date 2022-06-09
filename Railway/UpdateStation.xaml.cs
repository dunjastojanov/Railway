﻿using System;
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
using Microsoft.Maps.MapControl.WPF;
using Railway.Model;

namespace Railway
{
    /// <summary>
    /// Interaction logic for UpdateStation.xaml
    /// </summary>
    public partial class UpdateStation : Page
    {
        private Vector mouseToMarker;

        private bool dragPin;
        public Pushpin SelectedPushpin { get; set; }
        public Station Station { get; set; }
        public UpdateStation(Frame frame, Station station)
        {
            this.DataContext = this;
            Station = station;
            InitializeComponent();
        }

        private void Pushpin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (station_name.Text == "")
            {
                MessageBox.Show("You have to type station name if you want to change station location.", "Update station confirmation");
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
                SelectedPushpin = sender as Pushpin;
                dragPin = true;
                mouseToMarker = Point.Subtract(mapa.LocationToViewportPoint(SelectedPushpin.Location), e.GetPosition(mapa));
            }
        }

        private void mapa_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (dragPin && SelectedPushpin != null)
                {
                    SelectedPushpin.Location = mapa.ViewportPointToLocation(
                      Point.Add(e.GetPosition(mapa), mouseToMarker));
                    e.Handled = true;
                }
            }
        }

        private void mapa_Drop(object sender, DragEventArgs e)
        {
            if (dragPin && SelectedPushpin != null)
            {
                SelectedPushpin.Location = mapa.ViewportPointToLocation(
                    Point.Add(e.GetPosition(mapa), mouseToMarker));
                e.Handled = true;
            }
        }

        private void updateStation_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to update chosen station?", "Update station confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (station_name.Text == "")
                {
                    MessageBox.Show("Station name is empty.\nPlease enter station name.", "Update station confirmation");
                }
                else
                {
                    SelectedPushpin.ToolTip = station_name.Text;
                    SelectedPushpin.Background = new SolidColorBrush(Colors.Blue);
                    Station.Name = station_name.Text;
                    Station.Location = SelectedPushpin.Location;
                    
                    station_name.Text = "";

                    //sacuvaj podatke
                    MessageBox.Show("You have succesfully updated station", "Update station confirmation");
                }
            }
        }
    }
}