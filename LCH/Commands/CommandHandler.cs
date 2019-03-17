using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace mullak99.ACW.NetworkACW.LCHLib.Commands
{
    internal class CommandHandler
    {
        /// <summary>
        /// Converts the command string to a Command type
        /// </summary>
        /// <param name="commandString">Command string (either "<person>" or "<person> <location>")</param>
        /// <param name="protocol">Protocol to use when sending the command</param>
        /// <returns>The appropriate Command</returns>
        internal static Command CommandFinder(string commandString, LCH.Protocol protocol = LCH.Protocol.WHOIS)
        {
            string[] commandParts = Regex.Matches(commandString, @"[\""].+?[\""]|[^ ]+").Cast<Match>().Select(m => m.Value).ToArray();

            if (commandParts.Length == 1)
            {
                return new CommandGetLocation(commandParts[0], protocol);
            }
            else if (commandParts.Length >= 2)
            {
                string combinedParts = "";

                for (int i = 1; i < commandParts.Length; i++)
                {
                    combinedParts += commandParts[i];
                    combinedParts += " ";
                }
                combinedParts.TrimEnd(' ');

                return new CommandSetLocation(commandParts[0], combinedParts, protocol);
            }
            else
            {
                throw new NotImplementedException(String.Format("Invalid command supplied!|{0}", commandString));
            }
        }

        /// <summary>
        /// Converts the command recieved by the server to a Command type
        /// </summary>
        /// <param name="commandString">Command string (In any protocol format)</param>
        /// <param name="protocol">Detected Protocol format</param>
        /// <returns>The appropriate Command</returns>
        internal static Command CommandFinderServer(string commandString, ref LCH.Protocol protocol)
        {
            string[] commandSplit = commandString.Replace("\n", "").Split('\r');


            if (commandSplit[0].Split(' ')[0] == "GET" && commandString.Contains('/')) // GET request
            {
                if (commandSplit[0].Contains("HTTP/1.1")) // HTTP/1.1
                {
                    protocol = LCH.Protocol.HTTP11;
                    return new CommandGetLocation(commandSplit[0].Split(' ')[1].Replace("/?name=", ""), protocol);
                }
                else if (commandSplit[0].Contains("HTTP/1.0")) // HTTP/1.0
                {
                    protocol = LCH.Protocol.HTTP10;
                    return new CommandGetLocation(commandSplit[0].Split(' ')[1].Replace("/?", ""), protocol);
                }
                else // HTTP/0.9
                {
                    protocol = LCH.Protocol.HTTP09;
                    return new CommandGetLocation(commandSplit[0].Split('/')[1], protocol);
                }
            }
            else if (commandSplit[0].Split(' ')[0] == "PUT" || commandSplit[0].Split(' ')[0] == "POST" && commandString.Contains('/')) // PUT/POST request
            {
                if (commandSplit[0].Contains("HTTP/1.1")) // HTTP/1.1
                {
                    string[] request = commandSplit[commandSplit.Length - 1].Replace("name=", "").Replace("location=", "").Split('&');

                    protocol = LCH.Protocol.HTTP11;
                    return new CommandSetLocation(request[0], request[1], protocol);
                }
                else if (commandSplit[0].Contains("HTTP/1.0")) // HTTP/1.0
                {
                    protocol = LCH.Protocol.HTTP10;
                    return new CommandSetLocation(commandSplit[0].Split('/')[1].Replace("HTTP", "").TrimEnd(' '), commandSplit[commandSplit.Length - 1], protocol);
                }
                else // HTTP/0.9
                {
                    protocol = LCH.Protocol.HTTP09;
                    return new CommandSetLocation(commandSplit[0].Split('/')[1], commandSplit[commandSplit.Length - 1], protocol);
                }
            }
            else // WHOIS request
            {
                protocol = LCH.Protocol.WHOIS;
                return CommandFinder(commandString);
            }
        }
    }
}
