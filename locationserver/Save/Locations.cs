using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using mullak99.ACW.NetworkACW.locationserver.Save.SaveMethod;

namespace mullak99.ACW.NetworkACW.locationserver.Save
{
    public class Locations
    {
        protected string _dbPath;
        internal Database _dataBase;
        internal DatabaseType _dbType;

        protected List<PersonLocation> _peopleLocations = new List<PersonLocation>();

        public Locations(string databaseFilePath = null, DatabaseType dataBaseType = DatabaseType.SQLite)
        {
            _dbPath = databaseFilePath;
            _dbType = dataBaseType;

            if (!String.IsNullOrEmpty(_dbPath))
            {
                if (File.Exists(_dbPath)) ImportFromDB();
                ExportToDB();
            }
        }

        public void SetDbPath(string databaseFilePath)
        {
            _dbPath = databaseFilePath;

            if (!String.IsNullOrEmpty(_dbPath))
            {
                if (File.Exists(_dbPath)) ImportFromDB();
                ExportToDB();
            }
        }

        public bool AddPersonLocation(PersonLocation personLocation, bool useSetOnFail = false)
        {
            if (_dbPath != Program.GetDbPath())
            {
                SetDbPath(Program.GetDbPath());
            }
            if (!DoesPersonExist(personLocation))
            {
                Program.logging.Log(String.Format("LocationsDB: Added '{0}' in location '{1}' to the database!", personLocation.GetPersonID(), personLocation.GetPersonLocation()), 0);
                _peopleLocations.Add(personLocation);
                ExportToDB();
                return true;
            }
            else if (useSetOnFail)
            {
                return SetPersonLocation(personLocation);
            }
            return false;
        }

        public bool SetPersonLocation(PersonLocation personLocation)
        {
            if (DoesPersonExist(personLocation))
            {
                Program.logging.Log(String.Format("LocationsDB: Changed the location of '{0}' to '{1}' in the database!", personLocation.GetPersonID(), personLocation.GetPersonLocation()), 0);
                _peopleLocations[_peopleLocations.IndexOf(GetPersonLocation(personLocation))].SetPersonLocation(personLocation.GetPersonLocation());
                ExportToDB();
                return true;
            }
            return false;
        }

        public PersonLocation GetPersonLocation(string personID)
        {
            if (DoesPersonExist(personID))
            {
                Program.logging.Log(String.Format("LocationsDB: Got the location of '{0}'", personID), 0);
                return _peopleLocations.Where(p => p.GetPersonID() == personID).First();
            }
            else
            {
                Program.logging.Log(String.Format("LocationsDB: '{0}' does not exist!", personID), 0);
                return null;
            }
        }

        public PersonLocation GetPersonLocation(PersonLocation personLocation)
        {
            return GetPersonLocation(personLocation.GetPersonID());
        }

        public List<PersonLocation> GetAllPersonLocations()
        {
            return _peopleLocations;
        }

        public bool DoesPersonExist(string personID)
        {
            return _peopleLocations.Any(p => p.GetPersonID() == personID);
        }

        public bool DoesPersonExist(PersonLocation personLocation)
        {
            return DoesPersonExist(personLocation.GetPersonID());
        }

        public bool ImportFromDB()
        {
            if (!String.IsNullOrEmpty(_dbPath))
            {
                string method;
                switch (_dbType)
                {
                    case DatabaseType.TextFile:
                        {
                            _dataBase = new PropTextFile(_dbPath);
                            method = "TextFile";
                            break;
                        }
                    case DatabaseType.SQLite:
                    default:
                        {
                            if (SQLite.IsFileSQLiteDB(_dbPath))
                            {
                                _dataBase = new SQLite(_dbPath);
                                method = "SQLite";
                                break;
                            }
                            else
                            {
                                Program.logging.Log(String.Format("LocationsDB: '{0}' is not a valid database! Loading aborted", _dbPath), 2);
                                return false;
                            }
                        }
                }
                _peopleLocations = _dataBase.LoadDB();
                Program.logging.Log(String.Format("LocationsDB (METHOD={1}): Importing Locations from '{0}'", _dbPath, method), 0);
                return true;
            }
            return false;
        }

        public void ExportToDB()
        {
            if (!String.IsNullOrEmpty(_dbPath))
            {
                string method = "";
                switch (_dbType)
                {
                    case DatabaseType.TextFile:
                        {
                            if (_dataBase == null)
                                _dataBase = new PropTextFile(_dbPath);

                            method = "TextFile";
                            break;
                        }
                    case DatabaseType.SQLite:
                    default:
                        {
                            if (_dataBase == null)
                                _dataBase = new SQLite(_dbPath);

                            method = "SQLite";
                            break;
                        }
                }
                Program.logging.Log(String.Format("LocationsDB (METHOD={1}): Exporting Locations to '{0}'...", _dbPath, method), 0);
                _dataBase.SaveDB(_peopleLocations);
            }
        }
    }

    public class PersonLocation
    {
        protected string _personID, _personLocation;

        public PersonLocation(string personID, string personLocation)
        {
            _personID = personID.Replace(":", "");
            _personLocation = personLocation.Replace(":", "");
        }

        public string GetPersonID()
        {
            return _personID;
        }

        public string GetPersonLocation()
        {
            return _personLocation;
        }

        public void SetPersonLocation(string personLocation)
        {
            _personLocation = personLocation.Replace(":", "");
        }
    }
}
