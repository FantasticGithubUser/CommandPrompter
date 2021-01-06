using CommandPrompterServer.Managers;
using CommandPrompterServer.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Services.Implementations
{
    public class CommonServiceImpl : ICommonService
    {
        private IUserManager _userManager { get; set; }
        private ICommandManager _commandManager { get; set; }
        private IPlateformManager _plateformManager { get; set; }
        private ICommandParameterManager _commandParameterManager { get; set; }
        private ICommandChainManager _commandChainManager { get; set; }
        public List<RelatedNameResponseDto> SearchName(string name)
        {
            var list = new List<RelatedNameResponseDto>();

            var plateforms = _plateformManager.Search(name);
            if (plateforms != null)
                list.AddRange(plateforms);

            var chaines = _commandChainManager.Search(name);
            if (chaines != null)
                list.AddRange(chaines);

            var commands = _commandManager.Search(name);
            if (commands != null)
                list.AddRange(commands);

            var commandParameter = _commandParameterManager.Search(name);
            if (commandParameter != null)
                list.AddRange(commandParameter);

            var users = _userManager.Search(name);
            if (users != null)
                list.AddRange(users);

            return list;
        }
    }
}
