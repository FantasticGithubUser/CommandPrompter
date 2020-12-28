using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public interface ICommandChainService : ISimpleService<CommandChain>
    {
        List<ChainedCommand> GetAllNewestChainedCommandInOrder(string id);
    }
}
