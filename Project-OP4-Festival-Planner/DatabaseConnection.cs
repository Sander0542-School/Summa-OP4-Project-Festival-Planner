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
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=festival;Uid=root;Pwd=;Convert Zero Datetime=True;");

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
            sqlCommand.CommandText = "SELECT programmas.id as programmaID, podiums.naam as podiumNaam, programmas.naam as programmaNaam, CONCAT(HOUR(opbouwTijd),':',CASE WHEN (MINUTE(opbouwTijd) < 10) THEN CONCAT('0',MINUTE(opbouwTijd)) ELSE MINUTE(opbouwTijd) END) as beginTijd , CONCAT(HOUR(afbouwTijd),':',CASE WHEN (MINUTE(afbouwTijd) < 10) THEN CONCAT('0',MINUTE(afbouwTijd)) ELSE MINUTE(afbouwTijd) END) as eindTijd FROM programmas INNER JOIN podiums ON podiums.id = programmas.id;";
            MySqlDataReader dataReader = sqlCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            conn.Close();

            return dataTable;
        }

        public DataTable getProgrammaData(string sProgrammaID)
        {
            conn.Open();

            MySqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = "SELECT programma_data.id as dataID, bands.naam as bandNaam, CONCAT(HOUR(beginTijd),':',CASE WHEN (MINUTE(beginTijd) < 10) THEN CONCAT('0',MINUTE(beginTijd)) ELSE MINUTE(beginTijd) END) as tijd FROM programma_data INNER JOIN bands ON programma_data.bandID = bands.id WHERE programmaID = @pID";
            sqlCommand.Parameters.AddWithValue("@pID", sProgrammaID);

            MySqlDataReader dataReader = sqlCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            conn.Close();

            return dataTable;
        }

        public DataTable getPodiumInfo(string sProgrammaID)
        {
            conn.Open();

            MySqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = "SELECT podiums.naam as podiumNaam, podiums.genres, CONCAT(HOUR(opbouwTijd),':',CASE WHEN (MINUTE(opbouwTijd) < 10) THEN CONCAT('0',MINUTE(opbouwTijd)) ELSE MINUTE(opbouwTijd) END) as opbouwTijd, CONCAT(HOUR(afbouwTijd),':',CASE WHEN (MINUTE(afbouwTijd) < 10) THEN CONCAT('0',MINUTE(afbouwTijd)) ELSE MINUTE(afbouwTijd) END) as afbouwTijd FROM programmas INNER JOIN podiums ON programmas.podiumID = podiums.id WHERE programmas.id = @pID";
            sqlCommand.Parameters.AddWithValue("@pID", sProgrammaID);

            MySqlDataReader dataReader = sqlCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            conn.Close();

            return dataTable;
        }

        public DataTable getProgrammaDataInfo(string sProgrammaDataID)
        {
            conn.Open();

            MySqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = "SELECT bands.naam as bandNaam, bands.genre as bandGenre, bandPrijs, CONCAT(HOUR(beginTijd),':',CASE WHEN (MINUTE(beginTijd) < 10) THEN CONCAT('0',MINUTE(beginTijd)) ELSE MINUTE(beginTijd) END) as beginTijd, CONCAT(HOUR(beginTijd),':',CASE WHEN (MINUTE(eindTijd) < 10) THEN CONCAT('0',MINUTE(eindTijd)) ELSE MINUTE(eindTijd) END) as eindTijd FROM programma_data INNER JOIN bands ON programma_data.bandID = bands.id WHERE programma_data.id = @pID";
            sqlCommand.Parameters.AddWithValue("@pID", sProgrammaDataID);

            MySqlDataReader dataReader = sqlCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            conn.Close();

            return dataTable;
        }
        public DataTable getAllBands()
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM bands";

            MySqlDataReader reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            conn.Close();

            return dt;
        }
        public DataTable getBandData(string sBandID)
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM programma_data WHERE bandID = " + sBandID + ";";

            MySqlDataReader reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            conn.Close();

            return dt;
        }
    }
}
