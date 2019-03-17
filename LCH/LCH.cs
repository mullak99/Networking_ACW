using mullak99.ACW.NetworkACW.LCHLib.Commands;

namespace mullak99.ACW.NetworkACW.LCHLib
{
    public class LCH
    {
        public const string LCH_HeaderContent = "mullak99\r\n556176\r\n201710338\r\n"; // Used as a Content-Header in supported HTTP protocol messages to identify the client or server

        public LCH()
        { }

        /// <summary>
        /// Converts the command string to a Command type
        /// </summary>
        /// <param name="commandString">Command string (either "<person>" or "<person> <location>")</param>
        /// <param name="protocol">Protocol to use when sending the command</param>
        /// <returns>The appropriate Command</returns>
        public static Command ConvertStringToCommand(string commandString, LCH.Protocol protocol = LCH.Protocol.WHOIS)
        {
            return CommandHandler.CommandFinder(commandString, protocol);
        }

        /// <summary>
        /// Converts the command recieved by the server to a Command type
        /// </summary>
        /// <param name="rawClientRequest">Command string (In any protocol format)</param>
        /// <param name="protocol">Detected Protocol format</param>
        /// <returns>The appropriate Command</returns>
        public static Command ConvertClientRequestToCommand(string rawClientRequest, ref LCH.Protocol protocol)
        {
            return CommandHandler.CommandFinderServer(rawClientRequest, ref protocol);
        }

        /// <summary>
        /// Supported protocols for sending commands
        /// </summary>
        public enum Protocol
        {
            WHOIS,
            HTTP09,
            HTTP10,
            HTTP11
        };
    }
}
