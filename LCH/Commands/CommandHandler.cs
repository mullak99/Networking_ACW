using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.LCHLib.Commands
{
    internal class CommandHandler
    {
        internal static Command CommandFinder(string commandString)
        {
            string[] commandParts = Regex.Matches(commandString, @"[\""].+?[\""]|[^ ]+").Cast<Match>().Select(m => m.Value).ToArray();

            if (commandParts.Length == 1)
            {
                return new CommandGetLocation(commandParts[0]);
            }
            else if (commandParts.Length == 2)
            {
                return new CommandSetLocation(commandParts[0], commandParts[1]);
            }
            else
            {
                throw new Exception("Invalid command supplied!");
            }
        }
    }
}
