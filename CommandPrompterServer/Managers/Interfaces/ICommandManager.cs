using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Managers
{
    public interface ICommandManager : ISimpleManager<Command>, ISearchable
    {
        List<CommandParameter> GetAllNewestParametersInOrder(string id);

    }
}
