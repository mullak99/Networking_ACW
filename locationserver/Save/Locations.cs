using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.locationserver.Save
{
    public class Locations
    {
        protected string _dbPath;
        internal Database _dataBase;

        protected List<PersonLocation> _peopleLocations = new List<PersonLocation>();

        public Locations(string databaseFilePath = null)
        {
            _dbPath = databaseFilePath;

            ImportFromDB();
        }

        public bool AddPersonLocation(PersonLocation personLocation, bool useSetOnFail = false)
        {
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
                if (Database.IsFileSQLiteDB(_dbPath))
                {
                    _dataBase = new Database(_dbPath);
                    _peopleLocations = _dataBase.LoadDB();
                    Program.logging.Log(String.Format("LocationsDB: Importing Locations from '{0}'", _dbPath), 0);
                    return true;
                }
                Program.logging.Log(String.Format("LocationsDB: '{0}' is not a valid database! Loading aborted", _dbPath), 2);
                return false;
            }
            //Program.logging.Log(String.Format("LocationsDB: Database path not provided! Loading aborted"), 2);
            return false;
        }

        public void ExportToDB()
        {
            if (!String.IsNullOrEmpty(_dbPath))
            {
                if (_dataBase == null)
                    _dataBase = new Database(_dbPath);

                Program.logging.Log(String.Format("LocationsDB: Exporting Locations to '{0}'...", _dbPath), 0);
                _dataBase.SaveDB(_peopleLocations);
            }
            //else Program.logging.Log(String.Format("LocationsDB: Database path not provided! Saving aborted"), 2);
        }
    }

    public class PersonLocation
    {
        protected string _personID, _personLocation;

        public PersonLocation(string personID, string personLocation)
        {
            _personID = personID;
            _personLocation = personLocation;
        }

        public string GetPersonID()
        {
            return _personID;
        }

        public string GetPersonLocation()
        {
            return _personLocation;
        }

        public void SetPersonID(string personID)
        {
            _personID = personID;
        }

        public void SetPersonLocation(string personLocation)
        {
            _personLocation = personLocation;
        }
    }
}
