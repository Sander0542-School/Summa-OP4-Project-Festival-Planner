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
    /// Interaction logic for Bands.xaml
    /// </summary>
    public partial class Bands : Window
    {
        public Bands()
        {
            InitializeComponent();
            CheckBand();
        }

        public void CheckBand()
        {
            if (bandID == 0)
            {
                Button btnCreate = new Button();

                btnCreate.Content = "Voeg Band Toe";
                btnCreate.Name = "btnCreate";
                btnCreate.Click += btnCreate_Click;


                spButton.Children.Add(btnCreate);
            }
            else
            {
                Button btnUpdate = new Button();

                btnUpdate.Content = "Update Band";
                btnUpdate.Name = "btnUpdate";
                btnUpdate.Click += btnUpdate_Click;


                spButton.Children.Add(btnUpdate);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string sBandName = tbBandName.Text;
            string sBandGenre = tbBandGenre.Text;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string sBandName = tbBandName.Text;
            string sBandGenre = tbBandGenre.Text;
        }
    }
}
