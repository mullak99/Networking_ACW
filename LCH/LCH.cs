using mullak99.ACW.NetworkACW.LCHLib.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.LCHLib
{
    public class LCH
    {
        public LCH()
        {

        }

        public static Command ConvertStringToCommand(string commandString)
        {
            return CommandHandler.CommandFinder(commandString);
        }
    }
}
