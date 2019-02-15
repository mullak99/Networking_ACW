using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.locationserver.Save
{
    internal class Database
    {
        protected string _dbPath;
        protected SQLiteConnection _dbConnection;

        internal Database(string path)
        {
            _dbPath = path;

            bool isNewDatabase = CreateSQLiFile();

            _dbConnection = new SQLiteConnection(String.Format("Data Source={0};Version=3;", _dbPath));
            _dbConnection.Open();

            if (isNewDatabase)
                CreateDbTable();
        }

        internal List<PersonLocation> LoadDB()
        {
            return GetAllPersonLocations();
        }

        internal void SaveDB(List<PersonLocation> personLocations)
        {
            foreach (PersonLocation pLoc in personLocations)
            {
                if (!AddPersonLocation(pLoc)) SetPersonLocation(pLoc);
            }
        }

        private bool CreateSQLiFile()
        {
            if (!File.Exists(_dbPath))
            {
                SQLiteConnection.CreateFile(_dbPath);
                return true;
            }
            return false;
        }

        private bool AddPersonLocation(PersonLocation personLocation)
        {
            if (!DoesPersonExist(personLocation.GetPersonID()))
            {
                SQLiteCommand command = new SQLiteCommand("INSERT INTO PersonLocations (PersonName, PersonLocation) VALUES (@personID, @personLoc)", _dbConnection);

                command.Parameters.AddWithValue("@personID", personLocation.GetPersonID());
                command.Parameters.AddWithValue("@personLoc", personLocation.GetPersonLocation());
                command.ExecuteNonQuery();

                return true;
            }
            return false;
        }

        private bool SetPersonLocation(PersonLocation personLocation)
        {
            if (DoesPersonExist(personLocation.GetPersonID()))
            {
                SQLiteCommand command = new SQLiteCommand("UPDATE PersonLocations SET PersonLocation = @personLoc WHERE PersonName = @personID", _dbConnection);

                command.Parameters.AddWithValue("@personID", personLocation.GetPersonID());
                command.Parameters.AddWithValue("@personLoc", personLocation.GetPersonLocation());
                command.ExecuteNonQuery();

                return true;
            }
            return false;
        }

        private PersonLocation GetPersonLocation(string personID)
        {
            if (DoesPersonExist(personID))
            {
                SQLiteCommand command = new SQLiteCommand("SELECT PersonLocation FROM PersonLocations WHERE PersonName = @personID", _dbConnection);

                command.Parameters.AddWithValue("@personID", personID);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new PersonLocation(personID, (string)reader[0]);
                    }
                }
            }
            return null;
        }

        private List<PersonLocation> GetAllPersonLocations()
        {
            List<PersonLocation> pLocs = new List<PersonLocation>();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM PersonLocations", _dbConnection);

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Program.logging.Log(String.Format("LocationsDB: Loaded '{0}' at location: '{1}'", (string)reader[0], (string)reader[1]), 0);
                    pLocs.Add(new PersonLocation((string)reader[0], (string)reader[1]));
                }
            }
            return pLocs;
        }

        private bool DoesPersonExist(string personName)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT COUNT(1) FROM PersonLocations WHERE PersonName = @name", _dbConnection);
            command.Parameters.AddWithValue("@name", personName);

            Object o = command.ExecuteScalar();
            int count = Convert.ToInt32(o);

            if (count > 0)
                return true;

            return false;
        }

        private void CreateDbTable()
        {
            SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS PersonLocations (PersonName VARCHAR(255), PersonLocation VARCHAR(255))", _dbConnection);
            command.ExecuteNonQuery();
        }

        public static bool IsFileSQLiteDB(string path)
        {
            if (!String.IsNullOrEmpty(path) && File.Exists(path))
            {
                byte[] bytes = new byte[17];
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    fs.Read(bytes, 0, 16);
                }
                string chkStr = ASCIIEncoding.ASCII.GetString(bytes);
                return chkStr.Contains("SQLite format");
            }
            return false;
        }
    }
}
