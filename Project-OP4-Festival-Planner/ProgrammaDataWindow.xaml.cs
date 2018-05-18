using System;
using System.Collections.Generic;
using System.Data;
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
        private DatabaseConnection dbConnection = new DatabaseConnection();

        public ProgrammaDataWindow(string programmaID)
        {
            InitializeComponent();

            LoadProgrammas(programmaID);
        }

        public void LoadProgrammas(string programmaID)
        {
            DataTable dataTableProgramma = dbConnection.getProgrammaData(programmaID);

            lbProgramms.ItemsSource = dataTableProgramma.DefaultView;

            lbProgramms.SelectedIndex = 0;

            DataTable dataTablePodium = dbConnection.getPodiumInfo(programmaID);

            tbPodiumNaam.Text = "Podium: " + dataTablePodium.Rows[0]["podiumNaam"].ToString();

            tbGenres.Text = "Genres: " + dataTablePodium.Rows[0]["genres"].ToString();
            tbOpbouwTijd.Text = "Opbouw Tijd: " + dataTablePodium.Rows[0]["opbouwTijd"].ToString();
            tbAfbouwTijd.Text = "Afbouw Tijd: " + dataTablePodium.Rows[0]["afbouwTijd"].ToString();
        }

        public void LoadProgrammaData(string programmaInfoID)
        {
            DataTable dataTable = dbConnection.getProgrammaDataInfo(programmaInfoID);

            tbBandNaam.Text = "Naam: " + dataTable.Rows[0]["bandNaam"].ToString();
            tbBandGenre.Text = "Genre: " + dataTable.Rows[0]["bandGenre"].ToString();
            tbBandKosten.Text = "Kosten: €" + dataTable.Rows[0]["bandPrijs"].ToString();

            tbBeginTijd.Text = "Begin Tijd: " + dataTable.Rows[0]["beginTijd"].ToString();
            tbEindTijd.Text = "Eind Tijd: " + dataTable.Rows[0]["eindTijd"].ToString();
        }

        private void lbProgramms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            LoadProgrammaData(listBox.SelectedValue.ToString());
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ProgrammasWindow programmasWindow = new ProgrammasWindow();
            programmasWindow.Show();
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
