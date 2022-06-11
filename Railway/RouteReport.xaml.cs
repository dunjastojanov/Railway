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
    /// Interaction logic for RouteReport.xaml
    /// </summary>
    public partial class RouteReport : Page
    {
        public List<ReportTicketDTO> Tickets { get; set; }
        public RouteReport()
        {
            InitializeComponent();
            SetTrainlines();
            SetDataGrid();
        }
        private void SetTrainlines()
        {
            foreach (Trainline trainline in Data.GetTrainLines())
            {
                routeBox.Items.Add(trainline.Name + ": " + trainline.FirstStation.Name + " - " + trainline.LastStation.Name);
            }
        }
        private void SetDataGrid()
        {
            DataGridTextColumn TempColumn;

            dataGridRoute.AutoGenerateColumns = false;

            TempColumn = new DataGridTextColumn();
            TempColumn.Header = "Start station";
            TempColumn.Binding = new Binding("StartStation");
            dataGridRoute.Columns.Add(TempColumn);

            TempColumn = new DataGridTextColumn();
            TempColumn.Header = "End station";
            TempColumn.Binding = new Binding("EndStation");
            dataGridRoute.Columns.Add(TempColumn);

            TempColumn = new DataGridTextColumn();
            TempColumn.Header = "Date";
            TempColumn.Binding = new Binding("Date");
            dataGridRoute.Columns.Add(TempColumn);

            TempColumn = new DataGridTextColumn();
            TempColumn.Header = "Price (rsd)";
            TempColumn.Binding = new Binding("Price");
            dataGridRoute.Columns.Add(TempColumn);

            TempColumn = new DataGridTextColumn();
            TempColumn.Header = "Number of seats";
            TempColumn.Binding = new Binding("NumOfSeats");
            dataGridRoute.Columns.Add(TempColumn);
        }

        private void showRouteReport_Click(object sender, RoutedEventArgs e)
        {
            var route = routeBox.Text;
            DateTime startDate;
            DateTime endDate;
            if (route == "")
            {
                MessageBox.Show("Please enter route.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                startDate = DateTime.Parse(startingDate.Text);
            }
            catch
            {
                MessageBox.Show("Please enter starting date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                endDate = DateTime.Parse(endingDate.Text);
            }
            catch
            {
                MessageBox.Show("Please enter ending date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var trainlineName = route.Split(':')[0];
            Tickets = Data.GetRouteReport(trainlineName, startDate, endDate);
            if (Tickets.Count == 0)
            {
                MessageBox.Show("There are no bougth tickets for the route.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                dataGridRoute.ItemsSource = Tickets;
            }

        }
    }
}
