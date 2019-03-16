﻿using mullak99.ACW.NetworkACW.LCHLib.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.LCHLib
{
    public class LCH
    {
        public const string LCH_HeaderContent = "mullak99\r\n556176\r\n201710338\r\n";

        public LCH()
        { }

        public static Command ConvertStringToCommand(string commandString, LCH.Protocol protocol = LCH.Protocol.WHOIS)
        {
            return CommandHandler.CommandFinder(commandString, protocol);
        }

        public static Command ConvertClientRequestToCommand(string rawClientRequest, ref LCH.Protocol protocol)
        {
            return CommandHandler.CommandFinderServer(rawClientRequest, ref protocol);
        }

        public enum Protocol
        {
            WHOIS,
            HTTP09,
            HTTP10,
            HTTP11
        };
    }
}
