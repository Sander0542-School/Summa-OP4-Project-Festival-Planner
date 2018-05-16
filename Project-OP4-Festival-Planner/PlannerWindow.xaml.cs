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
    /// Interaction logic for PlannerWindow.xaml
    /// </summary>
    public partial class PlannerWindow : Window
    {
        private DatabaseConnection dbConnection = new DatabaseConnection();

        public PlannerWindow()
        {
            InitializeComponent();

            loadCombobox();
        }
        public void loadCombobox()
        {
            cbBands.ItemsSource = dbConnection.getAllBands().DefaultView;
        }

        private void cbBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dv = (DataRowView)cbBands.SelectedValue;
            string sId = dv[0].ToString();
            //dt.ItemsSource = dbConnection.getBandData(sId).DefaultView;
        }
    }
}
