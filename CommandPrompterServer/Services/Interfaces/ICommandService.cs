using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public interface ICommandService : ISimpleService<Command>
    {
        List<CommandParameter> GetAllNewestParametersInOrder(string id);

        /// <summary>
        /// Take the newest parameters of last version, change the series id and insert them into the newly updated version of command.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Command UpdateCommandWithNewestParametersOfLastVersion(Command command);
    }
}
