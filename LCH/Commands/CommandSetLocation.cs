using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.LCHLib.Commands
{
    public class CommandSetLocation : Command
    {
        protected string _user, _location;
        protected LCH.Protocol _protocol;

        public CommandSetLocation(string user, string location, LCH.Protocol protocol = LCH.Protocol.WHOIS)
        {
            _user = user;
            _location = location;
        }

        public string ComposeCommand()
        {
            switch (_protocol)
            {
                case LCH.Protocol.HTTP09:
                    {
                        return String.Format("SET /{0}\r\n\r\n{1}\r\n", _user, _location);
                    }
                case LCH.Protocol.HTTP10:
                    {
                        return String.Format("POST /{0} HTTP/1.0\r\nContent-Length: {1}\r\nmullak99\r\n{2}", _user, _location.Length, _location);
                    }
                case LCH.Protocol.HTTP11:
                    {
                        string content = String.Format("name={0}&location={1}", _user, _location);
                        return String.Format("POST / HTTP/1.1\r\nHost: LocationClient-m99\r\nContent-Length: {0}\r\nmullak99\r\n{1}", content.Length, content);
                    }
                default:
                case LCH.Protocol.WHOIS:
                    {
                        return String.Format("{0} {1}", _user, _location);
                    }
            }
        }

        public List<string> GetArguments()
        {
            return new List<string>() { _user, _location };
        }

        public string GetPersonID()
        {
            return _user;
        }

        public string GetLocation()
        {
            return _location;
        }
    }
}
