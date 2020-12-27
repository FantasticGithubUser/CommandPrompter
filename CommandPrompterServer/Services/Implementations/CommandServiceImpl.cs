using CommandPrompterServer.Managers;
using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public class CommandServiceImpl : SimpleServiceImpl<Command>, ICommandService
    {
        private ICommandManager _commandManager { get; set; }
        public List<CommandParameter> GetAllNewestParametersInOrder(string id)
        {
            return _commandManager.GetAllNewestParametersInOrder(id);
        }
    }
}
