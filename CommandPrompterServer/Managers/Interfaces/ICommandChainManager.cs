using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Managers
{
    public interface ICommandChainManager : ISimpleManager<CommandChain>, ISearchable
    {
        List<ChainedCommand> GetAllNewestChainedCommandInOrder(string id);
    }
}
