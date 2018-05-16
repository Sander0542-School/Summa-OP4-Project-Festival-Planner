using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OP4_Festival_Planner
{
    class DatabaseConnection
    {
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=festival;Uid=root;Pwd=");

        public bool Login(string sUsername, string sPassword)
        {
            bool bResult = false;

            try
            {
                conn.Open();

                MySqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM logins WHERE username = @username AND password = @password";
                sqlCommand.Parameters.AddWithValue("@username", sUsername);
                sqlCommand.Parameters.AddWithValue("@password", sPassword);

                MySqlDataReader dataReader = sqlCommand.ExecuteReader();

                bResult = dataReader.HasRows;
            }
            catch (Exception)
            {
                //Do nothing
            }
            finally
            {
                conn.Close();
            }

            return bResult;
        }
        
        public DataTable getProgrammas()
        {
            conn.Open();

            MySqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = "SELECT podiums.naam as podiumNaam, bands.naam as bandNaam, CONCAT(HOUR(opbouwTijd),':',CASE WHEN (MINUTE(opbouwTijd) < 10) THEN CONCAT('0',MINUTE(opbouwTijd)) ELSE MINUTE(opbouwTijd) END) as beginTijd , CONCAT(HOUR(afbouwTijd),':',CASE WHEN (MINUTE(afbouwTijd) < 10) THEN CONCAT('0',MINUTE(afbouwTijd)) ELSE MINUTE(afbouwTijd) END) as eindTijd FROM programmas INNER JOIN podiums ON podiums.id = programmas.id INNER JOIN bands ON programmas.id = bands.id;";

            MySqlDataReader dataReader = sqlCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            conn.Close();

            return dataTable;
        }

        public DataTable getProgrammaData(int iProgrammaID)
        {
            conn.Open();

            MySqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = "SELECT programmaID, bands.naam as bandNaam, CONCAT(HOUR(beginTijd),':',CASE WHEN (MINUTE(beginTijd) < 10) THEN CONCAT('0',MINUTE(beginTijd)) ELSE MINUTE(beginTijd) END) as tijd FROM programma_data INNER JOIN bands ON programma_data.bandID = bands.id WHERE programmaID = @pID";
            sqlCommand.Parameters.AddWithValue("@pID", iProgrammaID);

            MySqlDataReader dataReader = sqlCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            conn.Close();

            return dataTable;
        }

        public DataTable getProgrammaDataInfo(int iProgrammaDataID)
        {
            conn.Open();

            MySqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = "SELECT bands.naam as bandNaam, bands.genre as bandGenre, bandPrijs, beginTijd, eindTijd FROM programma_data INNER JOIN bands ON programma_data.bandID = bands.id WHERE programma_data.id = @pID";
            sqlCommand.Parameters.AddWithValue("@pID", iProgrammaDataID);

            MySqlDataReader dataReader = sqlCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            conn.Close();

            return dataTable;
        }
    }
}
