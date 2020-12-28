using CommandPrompterServer.Managers;
using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public class CommandChainServiceImpl : SimpleServiceImpl<CommandChain>, ICommandChainService
    {
        private ICommandChainManager _commandChainManager { get; set; }
        public List<ChainedCommand> GetAllNewestChainedCommandInOrder(string id)
        {
            return _commandChainManager.GetAllNewestChainedCommandInOrder(id);
        }
    }
}
