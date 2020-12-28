using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Managers
{
    public interface IChainedCommandManager : ISimpleManager<ChainedCommand>
    {
        List<ChainedCommandParameter> GetAllNewestChainedParametersInOrder(string id);
    }
}
