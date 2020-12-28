using CommandPrompterServer.Managers;
using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public class ChainedCommandServiceImpl : SimpleServiceImpl<ChainedCommand>, IChainedCommandService
    {
        private IChainedCommandManager _chainedCommandManager { get; set; }
        public List<ChainedCommandParameter> GetAllNewestChainedCommandParameterInOrder(string id)
        {
            return _chainedCommandManager.GetAllNewestChainedParametersInOrder(id);
        }
    }
}
