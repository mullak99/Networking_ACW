using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.LCHLib.Commands
{
    public class CommandGetLocation : Command
    {
        private string _user;

        public CommandGetLocation(string user)
        {
            _user = user;
        }

        public string ComposeCommand()
        {
            return String.Format("{0}", _user);
        }

        public List<string> GetArguments()
        {
            return new List<string>() { _user };
        }

        public string GetPersonID()
        {
            return _user;
        }
    }
}
