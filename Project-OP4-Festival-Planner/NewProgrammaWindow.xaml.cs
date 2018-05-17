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
            if (tbProgrammaNaam.Text.Length > 0 && cbPodiums.SelectedIndex != 0 && dtpBeginTijd.Text.Length > 0 && dtpEindTijd.Text.Length > 0)
            {
                if (dbConnection.InsertProgramma(tbProgrammaNaam.Text, cbPodiums.SelectedValue.ToString(), dtpBeginTijd.Text, dtpEindTijd.Text))
                {
                    MessageBox.Show("Het nieuwe programma is toegevoegd", "Programma opgeslagen", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kon het programma niet opslaan", "Kon niet opslaan", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Je moet alle gegevens invullen om een programma te kunnen toeveogen", "Verkeerde Gegevens", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
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
