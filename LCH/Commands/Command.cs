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
        string GetPersonID();
        string GetLocation();
        void SetProtocol(LCH.Protocol protocol);
        LCH.Protocol GetProtocol();
        bool ResolveResponse(string data);
        List<string> GetArguments();
        string RespondToClient(bool success);
    }
}
