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

            loadProgrammas();
        }

        private void loadProgrammas()
        {
            lbProgrammas.ItemsSource = dbConnection.getProgrammas().DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewProgrammaWindow newProgrammaWindow = new NewProgrammaWindow(0);
            newProgrammaWindow.ShowDialog();
        }

        private void lbProgrammas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            ProgrammaDataWindow dataWindow = new ProgrammaDataWindow(listBox.SelectedValue.ToString());
            dataWindow.Show();
            dataWindow.Closed += ProgrammaDataWindow_Closed;
            this.Close();
        }

        private void ProgrammaDataWindow_Closed(object sender, EventArgs e)
        {
            loadProgrammas();
        }
    }
}
