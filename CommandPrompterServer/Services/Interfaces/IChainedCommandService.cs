using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public interface IChainedCommandService : ISimpleService<ChainedCommand>
    {
        List<ChainedCommandParameter> GetAllNewestChainedCommandParameterInOrder(string id);
    }
}
