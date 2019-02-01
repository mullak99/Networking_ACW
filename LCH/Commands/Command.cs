using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.LCHLib.Commands
{
    public interface Command
    {
        string ComposeCommand();
        List<string> GetArguments();
    }
}
