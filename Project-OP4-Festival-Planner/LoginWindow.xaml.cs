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

namespace Project_OP4_Festival_Planner
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private DatabaseConnection dbconnection = new DatabaseConnection();
        private void Btlogin_Click(object sender, RoutedEventArgs e)
        {
            string username = tbGebruikersnaam.Text;
            string password = pwbPassword.Password;
            if (dbconnection.login(username, password) == true)
            {
                // Mag naar nieuw window
                PlannerWindow PW = new PlannerWindow();
                this.Hide();
                PW.ShowDialog();
                this.Show();

            }
            else
            {
                // maakt de border van de textbox en password box rood.
                tbGebruikersnaam.BorderBrush = Brushes.Red;
                tbGebruikersnaam.BorderThickness = new Thickness(2);
                pbWachtwoord.BorderBrush = Brushes.Red;
                pwbWachtwoord.BorderThickness = new Thickness(2);
            }
        }
    }
}
