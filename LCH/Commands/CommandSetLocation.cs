using System;
using System.Collections.Generic;

namespace mullak99.ACW.NetworkACW.LCHLib.Commands
{
    public class CommandSetLocation : Command
    {
        protected string _user, _location;
        protected LCH.Protocol _protocol;

        /// <summary>
        /// Command used to set the location of a person
        /// </summary>
        /// <param name="user">Person Name</param>
        /// <param name="location">Location of person</param>
        /// <param name="protocol">Protocol to use</param>
        public CommandSetLocation(string user, string location, LCH.Protocol protocol = LCH.Protocol.WHOIS)
        {
            _user = user.Replace(":", "");
            _location = location.Replace(":", "");
            _protocol = protocol;
        }

        /// <summary>
        /// Composes the command that the client sends to the server (in the desired protocol)
        /// </summary>
        /// <returns>Composed command string</returns>
        public string ComposeCommand()
        {
            switch (_protocol)
            {
                case LCH.Protocol.HTTP09:
                    {
                        return String.Format("PUT /{0}\r\n\r\n{1}\r\n", GetPersonID().TrimEnd(' '), GetLocation().TrimEnd(' '));
                    }
                case LCH.Protocol.HTTP10:
                    {
                        return String.Format("POST /{0} HTTP/1.0\r\nContent-Length: {1}\r\n{2}\r\n{3}", GetPersonID().TrimEnd(' '), GetLocation().TrimEnd(' ').Length, LCH.LCH_HeaderContent, GetLocation().TrimEnd(' '));
                    }
                case LCH.Protocol.HTTP11:
                    {
                        string content = String.Format("name={0}&location={1}", GetPersonID().TrimEnd(' '), GetLocation().TrimEnd(' '));
                        return String.Format("POST / HTTP/1.1\r\nHost: LocationClient-m99\r\nContent-Length: {0}\r\n{1}\r\n{2}", content.Length, LCH.LCH_HeaderContent, content);
                    }
                case LCH.Protocol.WHOIS:
                default:
                    {
                        return String.Format("{0} {1}\r\n", GetPersonID(), GetLocation());
                    }
            }
        }

        /// <summary>
        /// Gets all arguments
        /// </summary>
        /// <returns>Arguments of the Command</returns>
        public List<string> GetArguments()
        {
            return new List<string>() { GetPersonID(), GetLocation() };
        }

        /// <summary>
        /// Gets the persons name
        /// </summary>
        /// <returns>Person name</returns>
        public string GetPersonID()
        {
            return _user.Replace(":", "");
        }

        /// <summary>
        /// Gets the persons location
        /// </summary>
        /// <returns>Person location</returns>
        public string GetLocation()
        {
            return _location.Replace(":", "");
        }

        /// <summary>
        /// Gets the protocol used to compose the command
        /// </summary>
        /// <returns>Protocol used to compose the command</returns>
        public LCH.Protocol GetProtocol()
        {
            return _protocol;
        }

        /// <summary>
        /// Converts the command to a user-friendly string
        /// </summary>
        /// <returns>The persons name and location</returns>
        public override string ToString()
        {
            if (!String.IsNullOrEmpty(GetPersonID()) && !String.IsNullOrEmpty(GetLocation()))
            {
                return String.Format("{0} is {1}", GetPersonID().TrimEnd(' '), GetLocation().TrimEnd(' '));
            }
            else return null;
        }

        /// <summary>
        /// Resolves the response the server sent to the client
        /// </summary>
        /// <param name="data">Servers response</param>
        /// <returns>If the sent command was successful</returns>
        public bool ResolveResponse(string data)
        {
            switch (_protocol)
            {
                case LCH.Protocol.HTTP09:
                    {
                        string[] dataLines = data.Replace("\r", "").Split('\n');
                        if (dataLines[0] == "HTTP/0.9 200 OK")
                            return true;

                        return false;
                    }
                case LCH.Protocol.HTTP10:
                    {
                        string[] dataLines = data.Replace("\r", "").Split('\n');
                        if (dataLines[0] == "HTTP/1.0 200 OK")
                            return true;

                        return false;
                    }
                case LCH.Protocol.HTTP11:
                    {
                        string[] dataLines = data.Replace("\r", "").Split('\n');
                        if (dataLines[0] == "HTTP/1.1 200 OK")
                            return true;

                        return false;
                    }
                case LCH.Protocol.WHOIS:
                default:
                    {
                        if (!String.IsNullOrEmpty(data) && !data.StartsWith("ERROR"))
                            return true;

                        return false;
                    }
            }
        }

        /// <summary>
        /// Composes the response the server will send to the client
        /// </summary>
        /// <param name="success">Whether to send an 'OK' response, or a 'Not Found' response</param>
        /// <returns>String to send the client</returns>
        public string RespondToClient(bool success = true)
        {
            if (success)
            {
                switch (_protocol)
                {
                    case LCH.Protocol.HTTP09:
                        {
                            return String.Format("HTTP/0.9 200 OK\r\nContent-Type: text/plain\r\n\r\n");
                        }
                    case LCH.Protocol.HTTP10:
                        {
                            return String.Format("HTTP/1.0 200 OK\r\nContent-Type: text/plain\r\n\r\n");
                        }
                    case LCH.Protocol.HTTP11:
                        {
                            return String.Format("HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n{0}\r\n", LCH.LCH_HeaderContent);
                        }
                    case LCH.Protocol.WHOIS:
                    default:
                        {
                            return "OK";
                        }
                }
            }
            else
            {
                switch (_protocol)
                {
                    case LCH.Protocol.HTTP09:
                        {
                            return String.Format("HTTP/0.9 404 Not Found\r\nContent-Type: text/plain\r\n\r\n");
                        }
                    case LCH.Protocol.HTTP10:
                        {
                            return String.Format("HTTP/1.0 404 Not Found\r\nContent-Type: text/plain\r\n\r\n");
                        }
                    case LCH.Protocol.HTTP11:
                        {
                            return String.Format("HTTP/1.1 404 Not Found\r\nContent-Type: text/plain\r\n{0}\r\n", LCH.LCH_HeaderContent);
                        }
                    case LCH.Protocol.WHOIS:
                    default:
                        {
                            return String.Format("ERROR: Could not add '{0}' to location '{1}' in the database! Please contact the server operator for more information!", GetPersonID(), GetLocation());
                        }
                }
            }
        }
    }
}
