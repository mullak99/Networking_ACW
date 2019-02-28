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
            _protocol = protocol;
        }

        public string ComposeCommand()
        {
            switch (_protocol)
            {
                case LCH.Protocol.HTTP09:
                    {
                        return String.Format("PUT /{0}\r\n\r\n{1}\r\n", _user.TrimEnd(' '), _location.TrimEnd(' '));
                    }
                case LCH.Protocol.HTTP10:
                    {
                        return String.Format("POST /{0} HTTP/1.0\r\nContent-Length: {1}\r\n{2}\r\n{3}", _user.TrimEnd(' '), _location.TrimEnd(' ').Length, LCH.LCH_HeaderContent, _location.TrimEnd(' '));
                    }
                case LCH.Protocol.HTTP11:
                    {
                        string content = String.Format("name={0}&location={1}", _user.TrimEnd(' '), _location.TrimEnd(' '));
                        return String.Format("POST / HTTP/1.1\r\nHost: LocationClient-m99\r\nContent-Length: {0}\r\n{1}\r\n{2}", content.Length, LCH.LCH_HeaderContent, content);
                    }
                default:
                case LCH.Protocol.WHOIS:
                    {
                        return String.Format("{0} {1}\r\n", _user, _location);
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

        public LCH.Protocol GetProtocol()
        {
            return _protocol;
        }

        public override string ToString()
        {
            if (!String.IsNullOrEmpty(_user) && !String.IsNullOrEmpty(_location))
            {
                return String.Format("{0} is {1}", _user, _location);
            }
            else return null;
        }

        public bool ResolveResponse(string data)
        {
            switch (_protocol)
            {
                case LCH.Protocol.HTTP09:
                    {
                        string[] dataLines = data.Replace("\r", "").Split('\n');
                        if (dataLines[0] == "HTTP/0.9 200 OK")
                            return true;
                        else
                            return false;
                    }
                case LCH.Protocol.HTTP10:
                    {
                        string[] dataLines = data.Replace("\r", "").Split('\n');
                        if (dataLines[0] == "HTTP/1.0 200 OK")
                            return true;
                        else
                            return false;
                    }
                case LCH.Protocol.HTTP11:
                    {
                        string[] dataLines = data.Replace("\r", "").Split('\n');
                        if (dataLines[0] == "HTTP/1.1 200 OK")
                            return true;
                        else
                            return false;
                    }
                default:
                case LCH.Protocol.WHOIS:
                    {
                        if (!String.IsNullOrEmpty(data) && !data.StartsWith("ERROR"))
                            return true;
                        else
                            return false;
                    }
            }
        }
    }
}
