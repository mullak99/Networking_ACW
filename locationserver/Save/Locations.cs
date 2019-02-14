using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.locationserver.Save
{
    public class Locations
    {
        protected List<PersonLocation> _peopleLocations = new List<PersonLocation>();

        public Locations()
        { }

        public bool AddPersonLocation(PersonLocation personLocation, bool useSetOnFail = false)
        {
            if (!DoesPersonExist(personLocation))
            {
                Program.logging.Log(String.Format("LocationsDB: Added '{0}' in location '{1}' to the database!", personLocation.GetPersonID(), personLocation.GetPersonLocation()), 0);
                _peopleLocations.Add(personLocation);
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

        public bool ImportFromDB(string fileName)
        {
            Program.logging.Log(String.Format("LocationsDB: Importing from a database is not supported at this time!"), 2);
            return false;
        }

        public bool ExportToDB(string fileName)
        {
            Program.logging.Log(String.Format("LocationsDB: Exporting to a database is not supported at this time!"), 2);
            return false;
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
