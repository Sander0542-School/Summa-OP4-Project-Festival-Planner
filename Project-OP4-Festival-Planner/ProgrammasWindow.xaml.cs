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
    /// Interaction logic for ProgrammasWindow.xaml
    /// </summary>
    public partial class ProgrammasWindow : Window
    {
        DatabaseConnection dbConnection = new DatabaseConnection();
        public ProgrammasWindow()
        {
            InitializeComponent();

            ListBoxItem lbBand = new ListBoxItem();

            lbBand.Name = "lbBand";

            //List<ProgrammaItem> items = new List<ProgrammaItem>();
            //for (int i = 0; i < 40; i++)
            //{
            //    items.Add(new ProgrammaItem() { Title = "Naam", Podium = "Podium 1", Tijd = "10:00 - 18:00" });
            //}

            //lbProgrammas.ItemsSource = items;


        }
    }

    public class ProgrammaItem
    {
        public string Title { get; set; }
        public string Podium { get; set; }
        public string Tijd { get; set; }
    }
}
