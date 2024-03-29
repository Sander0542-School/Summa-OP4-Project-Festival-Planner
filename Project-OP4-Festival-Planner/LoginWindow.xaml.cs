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
using System.Windows.Shapes;

namespace Project_OP4_Festival_Planner
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private DatabaseConnection dbConnection = new DatabaseConnection();
        
        public LoginWindow()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = tbGebruikersnaam.Text;
            string password = pwbWachtwoord.Password;
            if (dbConnection.Login(username, password) == true)
            {
                // Mag naar nieuw window
                PlannerWindow PW = new PlannerWindow();
                PW.Show();
                this.Close();
            }
            else
            {
                // maakt de border van de textbox en password box rood.
                tbGebruikersnaam.BorderBrush = Brushes.Red;
                tbGebruikersnaam.BorderThickness = new Thickness(2);
                pwbWachtwoord.BorderBrush = Brushes.Red;
                pwbWachtwoord.BorderThickness = new Thickness(2);
            }
        }
    }
}
