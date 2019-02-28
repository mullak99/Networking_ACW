using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.LCHLib.Commands
{
    public class CommandGetLocation : Command
    {
        protected string _user, _location;
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
                        return String.Format("GET /{0}\r\n", _user.TrimEnd(' '));
                    }
                case LCH.Protocol.HTTP10:
                    {
                        return String.Format("GET /?{0} HTTP/1.0\r\n{1}\r\n", _user.TrimEnd(' '), LCH.LCH_HeaderContent);
                    }
                case LCH.Protocol.HTTP11:
                    {
                        return String.Format("GET /?name={0} HTTP/1.1\r\nHost: LocationClient-m99\r\n{1}\r\n", _user.TrimEnd(' '), LCH.LCH_HeaderContent);
                    }
                default:
                case LCH.Protocol.WHOIS:
                    {
                        return String.Format("{0}\r\n", _user.TrimEnd(' '));
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
            if (!String.IsNullOrEmpty(_user) && String.IsNullOrEmpty(_location))
            {
                return _user;
            }
            else if (!String.IsNullOrEmpty(_user) && !String.IsNullOrEmpty(_location))
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
                        {
                            _location = String.Format("{0}", dataLines[dataLines.Length - 2]);
                            return true;
                        }
                        else return false;
                    }
                case LCH.Protocol.HTTP10:
                    {
                        string[] dataLines = data.Replace("\r", "").Split('\n');
                        if (dataLines[0] == "HTTP/1.0 200 OK")
                        {
                            _location = String.Format("{0}", dataLines[dataLines.Length - 2]);
                            return true;
                        }
                        else return false;
                    }
                case LCH.Protocol.HTTP11:
                    {
                        string[] dataLines = data.Replace("\r", "").Split('\n');
                        if (dataLines[0] == "HTTP/1.1 200 OK")
                        {
                            _location = String.Format("{0}", dataLines[dataLines.Length - 2]);
                            return true;
                        }
                        else return false;
                    }
                default:
                case LCH.Protocol.WHOIS:
                    {
                        if (!String.IsNullOrEmpty(data) && !data.StartsWith("ERROR"))
                        {
                            _location = String.Format("{0}", data);
                            return true;
                        }
                        else
                        {
                            _location = "";
                            _location = String.Format("{0} does not exist on the server!", GetPersonID());
                            return false;
                        }
                    }
            }
        }
    }
}
