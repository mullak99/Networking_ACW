﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.LCHLib.Commands
{
    internal class CommandHandler
    {
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
    }
}
