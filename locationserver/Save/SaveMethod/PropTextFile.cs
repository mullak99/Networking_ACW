using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.locationserver.Save.SaveMethod
{
    internal class PropTextFile : Database
    {
        protected string _dbPath;

        internal PropTextFile(string path)
        {
            _dbPath = path;
        }

        public List<PersonLocation> LoadDB()
        {
            if (File.Exists(_dbPath))
            {
                List<PersonLocation> personLocations = new List<PersonLocation>();
                string[] formattedPersonLoc = File.ReadAllLines(_dbPath, Encoding.UTF8);

                foreach (string pLoc in formattedPersonLoc)
                {
                    string[] splitPersonLoc = pLoc.Split(':');

                    personLocations.Add(new PersonLocation(splitPersonLoc[0], splitPersonLoc[1]));
                }
                Program.logging.Log(String.Format("LocationsDB (METHOD={1}): Loaded '{0}' person(s) location(s)", personLocations.Count, "TextFile"), 0);

                return personLocations;
            }
            return null;
        }

        public void SaveDB(List<PersonLocation> personLocations)
        {
            if (File.Exists(_dbPath)) File.Delete(_dbPath);

            try
            {
                List<string> formattedPersonLoc = new List<string>();

                foreach (PersonLocation pLoc in personLocations)
                {
                    formattedPersonLoc.Add(pLoc.GetPersonID() + ":" + pLoc.GetPersonLocation());
                }
                File.WriteAllLines(_dbPath, formattedPersonLoc.ToArray(), Encoding.UTF8);

                Program.logging.Log(String.Format("LocationsDB (METHOD={1}): Saved '{0}' person(s) location(s)", formattedPersonLoc.Count, "TextFile"), 0);
            }
            catch
            {
                Program.logging.Log(String.Format("LocationsDB (METHOD={0}): Database could not be saved!", "TextFile"), 2);
            }
        }
    }
}
