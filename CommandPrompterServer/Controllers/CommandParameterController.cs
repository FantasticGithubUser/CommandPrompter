using CommandPrompterServer.Models.Dao;
using CommandPrompterServer.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CommandPrompterServer.Controllers
{
    
    public class CommandParameterController : BaseController
    {
       [HttpGet]
       [Authorize]
       [Route("GetCommandParameterById")]
        public CommandParameter GetCommandParameterById(string id)
        {
            return _commandParameterService.GetEntityById(id);
        }

        [HttpGet]
        [Authorize]
        [Route("GetCommandParameterSeriesById")]
        public List<CommandParameter> GetCommandParameterSeriesById(string id)
        {
            return _commandParameterService.GetSeriesById(id);
        }


    }
}
