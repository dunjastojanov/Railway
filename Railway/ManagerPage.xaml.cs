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
    /// Interaction logic for ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Window
    {
       
        public ManagerPage()
        {
            InitializeComponent();
  
 
        }

        private void Routes_Click(object sender, RoutedEventArgs e)
        {
          //  ManagerContentFrame.Content = new ReadTrainRoute(ManagerContentFrame);
        }

        private void Trains_Click(object sender, RoutedEventArgs e)
        {
         //   ManagerContentFrame.Content = new ReadTrain(ManagerContentFrame);
        }

        private void Stations_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Schedules_Click(object sender, RoutedEventArgs e)
        {
           // ManagerContentFrame.Content = new ReadTimetable(ManagerContentFrame);
        }
    }
}
