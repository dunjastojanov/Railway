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
using Microsoft.Maps.MapControl.WPF;
using Railway.Model;

namespace Railway
{
    /// <summary>
    /// Interaction logic for RailwayNetworkOverview.xaml
    /// </summary>
    public partial class RailwayNetworkOverview : Page
    {

        public Trainline Trainline { get; set; }
        public List<Station> Stations { get; set; }
        public LocationCollection Locations { get; set; }
        public RailwayNetworkOverview(Frame mainFrame,Trainline trainline)
        {
            this.DataContext = this;
            
            List<Station> stations = new List<Station>();
            LocationCollection locations = new LocationCollection();
            Station currentStation = trainline.FirstStation;
            while (currentStation.PathToNextStation != null)
            {
                stations.Add(currentStation);
                locations.Add(currentStation.Location);
                currentStation = currentStation.PathToNextStation.NextStation;
            }
            stations.Add(currentStation);
            locations.Add(currentStation.Location);
            Stations = stations;
            Locations = locations;
            InitializeComponent();
            mapa.Center = trainline.FirstStation.Location;
        }
    }
}
