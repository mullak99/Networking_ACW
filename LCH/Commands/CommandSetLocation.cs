using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.LCHLib.Commands
{
    public class CommandSetLocation : Command
    {
        private string _user, _location;

        public CommandSetLocation(string user, string location)
        {
            _user = user;
            _location = location;
        }

        public string ComposeCommand()
        {
            return String.Format("{0} {1}", _user, _location);
        }

        public List<string> GetArguments()
        {
            return new List<string>() { _user, _location };
        }
    }
}
