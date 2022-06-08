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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {

        public Frame MainFrame { get; set; }
        public Railway.MainWindow window;
        public Login(Frame mainFrame, Railway.MainWindow window)
        {
            MainFrame = mainFrame;
            this.window = window;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String email = emailTextBox.Text;
            String password = passwordTextBox.Password;

            User logedUser = Data.GetLogedUser(email, password);

            if (logedUser != null)
            {
                if (logedUser.Role == "admin")
                {
                    window.InitializeManagerComponents();
                    window.ShowAdminHomePage();
                }
                else if (logedUser.Role == "user")
                {
                    window.InitializeUserComponents(logedUser);
                    window.ShowSearchRoute();
                }
            } else
            {
                MessageBox.Show("Username or password is incorrect.", "Inadequate credentials", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
            
           
           
        }
    }
}
