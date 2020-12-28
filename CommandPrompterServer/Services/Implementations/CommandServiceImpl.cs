using CommandPrompterServer.Managers;
using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public class CommandServiceImpl : SimpleServiceImpl<Command>, ICommandService
    {
        private ICommandManager _commandManager { get; set; }
        private ICommandParameterManager _commandParameterManager { get; set; }
        public List<CommandParameter> GetAllNewestParametersInOrder(string id)
        {
            return _commandManager.GetAllNewestParametersInOrder(id);
        }

        public Command UpdateCommandWithNewestParametersOfLastVersion(Command command)
        {
            var oldCommand = _commandManager.GetEntityById(command.Id);
            if(oldCommand != null)
            {
                var parameters = _commandManager.GetAllNewestParametersInOrder(command.Id);
                if (parameters != null)
                {
                    var newCommand = _commandManager.UpdateEntity(command);
                    foreach (var para in parameters)
                    {
                        var newPara = para.GetClone();
                        para.CommandId = newCommand.Id;
                        _commandParameterManager.AddNewEntity(newPara);
                    }
                    return newCommand;
                }
            }
            return null;
        }
    }
}
