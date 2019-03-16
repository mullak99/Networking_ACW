using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.locationserver.Save.SaveMethod
{
    internal interface Database
    {
        List<PersonLocation> LoadDB();

        void SaveDB(List<PersonLocation> personLocations);
    }

    public enum DatabaseType {
        SQLite,
        TextFile
    };
}
