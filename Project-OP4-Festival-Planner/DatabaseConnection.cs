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
            sqlCommand.CommandText = "SELECT programmas.id as programmaID, podiums.naam as podiumNaam, programmas.naam as programmaNaam, CONCAT(DATE_FORMAT(programmas.aanvangsTijd, '%H:%i'),' - ',DATE_FORMAT(programmas.eindTijd, '%H:%i')) as tijd FROM programmas INNER JOIN podiums ON programmas.podiumID = podiums.id";
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

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            conn.Close();

            return dataTable;
        }

        public DataTable getAllPodiums()
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT id, naam FROM podiums";

            MySqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            conn.Close();

            DataRow dataRow = dataTable.NewRow();
            dataRow[0] = 0;
            dataRow[1] = "Selecteer een Podium";

            dataTable.Rows.InsertAt(dataRow, 0);

            return dataTable;
        }

        public DataTable getBandData(string sBandID)
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM programma_data WHERE bandID = @bID;";
            command.Parameters.AddWithValue("@bID", sBandID);

            MySqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            conn.Close();

            return dataTable;
        }

        public bool InsertProgramma(string sProgrammaNaam, string sPodiumID, string sBeginTijd, string sEindTijd)
        {
            bool bSuccess;
            try
            {
                conn.Open();

                MySqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO programmas (naam, podiumID, aanvangsTijd, eindTijd) VALUES (@naam, @podium, STR_TO_DATE(@beginTijd,'%d %b %Y %k:%i'), STR_TO_DATE(@eindTijd,'%d %b %Y %k:%i'))";
                sqlCommand.Parameters.AddWithValue("@naam", sProgrammaNaam);
                sqlCommand.Parameters.AddWithValue("@podium", sPodiumID);
                sqlCommand.Parameters.AddWithValue("@beginTijd", sBeginTijd);
                sqlCommand.Parameters.AddWithValue("@eindTijd", sEindTijd);

                sqlCommand.ExecuteNonQuery();

                bSuccess = true;
            }
            catch (Exception ex)
            {
                bSuccess = false;
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return bSuccess;
        }

        public bool InsertPodium(string sPodiumName, string sGenres, string sOpbouwTijd, string sAfbouwTijd)
        {
            bool bSuccess;
            try
            {
                conn.Open();

                MySqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO podiums (naam, genres, opbouwTijd, afbouwTijd) VALUES (@naam, @genres, STR_TO_DATE(@opbouwTijd,'%d %b %Y %k:%i'), STR_TO_DATE(@afbouwTijd,'%d %b %Y %k:%i'))";
                sqlCommand.Parameters.AddWithValue("@naam", sPodiumName);
                sqlCommand.Parameters.AddWithValue("@genres", sGenres);
                sqlCommand.Parameters.AddWithValue("@opbouwTijd", sOpbouwTijd);
                sqlCommand.Parameters.AddWithValue("@afbouwTijd", sAfbouwTijd);

                sqlCommand.ExecuteNonQuery();

                bSuccess = true;
            }
            catch (Exception ex)
            {
                bSuccess = false;
            }
            finally
            {
                conn.Close();
            }
            return bSuccess;
        }

        public bool InsertBands(string sBandName, string sBandGenre)
        {
            bool bSuccess;
            try
            {
                conn.Open();

                MySqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO bands (naam, genre) VALUES(@BandName, @BandGenre)";
                sqlCommand.Parameters.AddWithValue("@BandName", sBandName);
                sqlCommand.Parameters.AddWithValue("@BandGenre", sBandGenre);

                sqlCommand.ExecuteNonQuery();

                bSuccess = true;
            }
            catch (Exception ex)
            {
                bSuccess = false;
            }
            finally
            {
                conn.Close();
            }
            return bSuccess;
        }

        public bool UpdateBands(string sBandName, string sBandGenre, int iBandID)
        {
            bool bSuccess;
            try
            {
                conn.Open();

                MySqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = "UPDATE bands SET naam = @BandName, genre = @BandGenre WHERE id =" + iBandID;
                sqlCommand.Parameters.AddWithValue("@BandName", sBandName);
                sqlCommand.Parameters.AddWithValue("@BandGenre", sBandGenre);

                sqlCommand.ExecuteNonQuery();

                bSuccess = true;
            }
            catch (Exception ex)
            {
                bSuccess = false;
            }
            finally
            {
                conn.Close();
            }
            return bSuccess;
        }
    }
}