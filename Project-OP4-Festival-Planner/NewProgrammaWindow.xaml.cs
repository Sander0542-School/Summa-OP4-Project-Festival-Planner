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

using Xceed.Wpf.Toolkit;

namespace Project_OP4_Festival_Planner
{
    /// <summary>
    /// Interaction logic for NewProgrammaWindow.xaml
    /// </summary>
    public partial class NewProgrammaWindow : Window
    {
        private DatabaseConnection dbConnection = new DatabaseConnection();

        private bool bNewProgramma = false;

        public NewProgrammaWindow(int programmaID)
        {
            InitializeComponent();
            if (programmaID == 0)
            {
                bNewProgramma = true;
            }

            loadPodiums();
        }

        private void loadPodiums()
        {
            cbPodiums.ItemsSource = dbConnection.getAllPodiums().DefaultView;
        }

        private void btnMaakProgramma_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNewPodium_Click(object sender, RoutedEventArgs e)
        {
            PodiumWindow podiumWindow = new PodiumWindow();
            podiumWindow.Closed += PodiumWindow_Closed;
            podiumWindow.ShowDialog();
        }

        private void PodiumWindow_Closed(object sender, EventArgs e)
        {
            loadPodiums();
        }
    }
}
