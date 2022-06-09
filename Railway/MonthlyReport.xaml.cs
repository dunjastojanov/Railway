using Railway.model;
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
    /// Interaction logic for MonthlyReport.xaml
    /// </summary>
    public partial class MonthlyReport : Page
    {
        public List<ReportTicketDTO> Tickets { get; set; }
        public MonthlyReport()
        {
            InitializeComponent();
            SetMonths();
            SetYears();
            SetDataGrid();
        }

        private void SetDataGrid()
        {
            DataGridTextColumn TempColumn;

            dataGrid.AutoGenerateColumns = false;

            TempColumn = new DataGridTextColumn();
            TempColumn.Header = "Start station";
            TempColumn.Binding = new Binding("StartStation");
            dataGrid.Columns.Add(TempColumn);

            TempColumn = new DataGridTextColumn();
            TempColumn.Header = "End station";
            TempColumn.Binding = new Binding("EndStation");
            dataGrid.Columns.Add(TempColumn);

            TempColumn = new DataGridTextColumn();
            TempColumn.Header = "Date";
            TempColumn.Binding = new Binding("Date");
            dataGrid.Columns.Add(TempColumn);

            TempColumn = new DataGridTextColumn();
            TempColumn.Header = "Price";
            TempColumn.Binding = new Binding("Price");
            dataGrid.Columns.Add(TempColumn);

            TempColumn = new DataGridTextColumn();
            TempColumn.Header = "Number of seats";
            TempColumn.Binding = new Binding("NumOfSeats");
            dataGrid.Columns.Add(TempColumn);
        }

        private void SetMonths()
        {
            List<string> months = new List<string>() { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            {
                foreach (string month in months)
                {
                    monthBox.Items.Add(month);
                }
            };
        }
        public void SetYears()
        {
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                yearBox.Items.Add(i);
            }
        }

        private void showMonthlyReport_Click(object sender, RoutedEventArgs e)
        {
            var month = monthBox.Text;
            var year = yearBox.Text;
            if (month == "")
            {
                MessageBox.Show("Please enter month.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (year == "")
            {
                MessageBox.Show("Please enter year.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Tickets = Data.GetMonthyReport(month, year);
                if (Tickets.Count == 0)
                {
                    MessageBox.Show("There are no bougth tickets for date.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    dataGrid.ItemsSource = Tickets;
                }
            }
        }
    }
}

