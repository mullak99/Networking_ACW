using System.Collections.Generic;

namespace mullak99.ACW.NetworkACW.LCHLib.Commands
{
    public interface Command
    {
        /// <summary>
        /// Composes the command that the client sends to the server (in the desired protocol)
        /// </summary>
        /// <returns>Composed command string</returns>
        string ComposeCommand();

        /// <summary>
        /// Gets the persons name
        /// </summary>
        /// <returns>Person name</returns>
        string GetPersonID();

        /// <summary>
        /// Gets the persons location
        /// </summary>
        /// <returns>Person location</returns>
        string GetLocation();

        /// <summary>
        /// Gets the protocol used to compose the command
        /// </summary>
        /// <returns>Protocol used to compose the command</returns>
        LCH.Protocol GetProtocol();

        /// <summary>
        /// Gets all arguments
        /// </summary>
        /// <returns>Arguments of the Command</returns>
        List<string> GetArguments();

        /// <summary>
        /// Resolves the response the server sent to the client
        /// </summary>
        /// <param name="data">Servers response</param>
        /// <returns>If the sent command was successful</returns>
        bool ResolveResponse(string data);

        /// <summary>
        /// Composes the response the server will send to the client
        /// </summary>
        /// <param name="success">Whether to send an 'OK' response, or a 'Not Found' response</param>
        /// <returns>String to send the client</returns>
        string RespondToClient(bool success);

    }
}
