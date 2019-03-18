using System;
using System.Collections.Generic;
using System.Windows.Forms;
using mullak99.ACW.NetworkACW.locationserver.Save;

namespace mullak99.ACW.NetworkACW.locationserver.MenuPanels
{
    public partial class DatabasePanel : UserControl
    {
        private List<PersonLocation> _allPersons;

        public DatabasePanel()
        {
            InitializeComponent();

            _allPersons = Program.locations.GetAllPersonLocations();
            PopulateList();
        }

        public void RuntimeUpdate()
        {
            if (_allPersons != null && Program.locations.GetAllPersonLocations() != null)
            {
                _allPersons = Program.locations.GetAllPersonLocations();
                PopulateList();
            }
        }

        private void PopulateList()
        {
            databaseList.Clear();

            if (_allPersons == null || _allPersons.Count == 0)
            {
                databaseList.AppendText("Database is empty" + Environment.NewLine);
            }
            else
            {
                foreach (PersonLocation pLoc in _allPersons)
                {
                    databaseList.AppendText(pLoc.GetPersonID() + " is " + pLoc.GetPersonLocation() + Environment.NewLine);
                }
            }
            
        }
    }
}
