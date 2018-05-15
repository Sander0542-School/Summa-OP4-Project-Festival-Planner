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
    /// Interaction logic for ProgrammaDataWindow.xaml
    /// </summary>
    public partial class ProgrammaDataWindow : Window
    {
        public ProgrammaDataWindow()
        {
            InitializeComponent();

            List<BandItem> items = new List<BandItem>();
            for (int i = 0; i < 40; i++)
            {
                items.Add(new BandItem() { Title = "Sander", Time = "14:00 - 15:30" });
            }

            lbProgramms.ItemsSource = items;
        }
    }

    public class BandItem
    {
        public string Title { get; set; }
        public string Time { get; set; }
    }
}
