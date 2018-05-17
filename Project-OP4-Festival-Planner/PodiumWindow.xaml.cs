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
    /// Interaction logic for PodiumWindow.xaml
    /// </summary>
    public partial class PodiumWindow : Window
    {
        private DatabaseConnection dbConnection = new DatabaseConnection();

        public PodiumWindow()
        {
            InitializeComponent();
        }

        private void btnMaakPodium_Click(object sender, RoutedEventArgs e)
        {
            if (tbProgrammaNaam.Text.Length > 0 && tbGenres.Text.Length > 0 && dtpAfbouwTijd.Text.Length > 0 && dtpOpbouwTijd.Text.Length > 0)
            {
                if (dbConnection.InsertPodium(tbProgrammaNaam.Text, tbGenres.Text, dtpOpbouwTijd.Text, dtpAfbouwTijd.Text))
                {
                    MessageBox.Show("Het nieuwe podium is toegevoegd", "Podium opgeslagen", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kon het podium niet opslaan", "Kon niet opslaan", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Je moet alle gegevens invullen om een podium te kunnen toeveogen", "Verkeerde Gegevens", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
