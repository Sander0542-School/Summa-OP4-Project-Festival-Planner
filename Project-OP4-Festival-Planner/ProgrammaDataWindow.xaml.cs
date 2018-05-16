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

        public ProgrammaDataWindow()
        {
            InitializeComponent();

            LoadProgramma(1);
        }

        public void LoadProgramma(int programmaID)
        {
            DataTable datatable = dbConnection.getProgrammaData(programmaID);

            lbProgramms.ItemsSource = datatable.DefaultView;
        }

        private void lbProgramms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            MessageBox.Show(listBox.SelectedValuePath);
        }
    }
}
