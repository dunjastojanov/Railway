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
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Page
    {
        Railway.MainWindow Window;
        public Reports(Railway.MainWindow window)
        {
            InitializeComponent();
            this.Window = window; 
        }

        private void MonthReport_Checked(object sender, RoutedEventArgs e)
        {
            ShowMonthReport();
        }

        private void RouteReport_Checked(object sender, RoutedEventArgs e)
        {
            ShowRouteReport();
        }

        private void ShowMonthReport()
        {
            MonthlyReport mr = new MonthlyReport();
            ReportsFrame.Content = mr;
        }
        private void ShowRouteReport()
        {
            RouteReport rr = new RouteReport();
            ReportsFrame.Content = rr;
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpProvider.ShowHelp("Reports", Window);
        }
    }
}
