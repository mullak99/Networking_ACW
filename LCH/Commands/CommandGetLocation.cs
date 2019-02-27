using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.LCHLib.Commands
{
    public class CommandGetLocation : Command
    {
        protected string _user;
        protected LCH.Protocol _protocol;

        public CommandGetLocation(string user, LCH.Protocol protocol = LCH.Protocol.WHOIS)
        {
            _user = user;
            _protocol = protocol;
        }

        public string ComposeCommand()
        {
            switch (_protocol)
            {
                case LCH.Protocol.HTTP09:
                    {
                        return String.Format("GET /{0}", _user);
                    }
                case LCH.Protocol.HTTP10:
                    {
                        return String.Format("GET /?{0} HTTP/1.0\r\nmullak99\r\n", _user);
                    }
                case LCH.Protocol.HTTP11:
                    {
                        return String.Format("GET /?name={0} HTTP/1.1\r\nHost: LocationClient-m99\r\nmullak99\r\n", _user);
                    }
                default:
                case LCH.Protocol.WHOIS:
                    {
                        return String.Format("{0}", _user);
                    }
            }
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
