using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public interface ICommandService : ISimpleService<Command>
    {
        List<CommandParameter> GetAllNewestParametersInOrder(string id);
    }
}
