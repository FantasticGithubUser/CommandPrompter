using CommandPrompterServer.Helpers;
using CommandPrompterServer.Models.Dao;
using CommandPrompterServer.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CommandPrompterServer.Controllers
{
    public class CommandController : BaseController
    {
        /// <summary>
        /// Add a new command without command parameters.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("AddCommand")]
        [Authorize]
        public Command AddCommand([FromBody] Command command)
        {
            return _commandService.AddNewEntity(command);
        }

        /// <summary>
        /// Update the old command by creating a new copy of that.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateCommand")]
        [Authorize]
        public Command UpdateCommand([FromBody] Command command)
        {
            return _commandService.UpdateEntity(command);
        }

        [HttpGet]
        [Route("GetCommandById/{id}")]
        [Authorize]
        public CommandResponseDto GetCommandById([FromRoute] string id)
        {
            return _mapper.Map<CommandResponseDto>(_commandService.GetEntityById(id));
        }

        [HttpPost]
        [Route("GetCommandsByFilter")]
        [Authorize]
        public List<CommandResponseDto> GetCommandsByFilter([FromBody] List<QueryField> fields)
        {
            var list = _commandService.GetEntities(fields);
            var ret = new List<CommandResponseDto>();
            foreach(var item in list)
            {
                ret.Add(_mapper.Map<CommandResponseDto>(item));
            }
            return ret;
        }

        [HttpGet]
        [Route("GetAllCommands")]
        [Authorize]
        public List<CommandResponseDto> GetAllCommands()
        {
            var list = _commandService.GetAllEntities();
            var ret = new List<CommandResponseDto>();
            foreach (var item in list)
            {
                ret.Add(_mapper.Map<CommandResponseDto>(item));
            }
            return ret;
        }


        [HttpPost]
        [Route("GetEntities")]
        [Authorize]
        public List<CommandResponseDto> GetEntities([FromBody] List<QueryField> fields)
        {
            var commands = _commandService.GetEntities(fields);
            if (commands != null)
            {
                var response = new List<CommandResponseDto>();
                foreach (var item in commands)
                {
                    var command = _mapper.Map<CommandResponseDto>(item);
                    response.Add(command);
                }
                return response;
            }
            return null;
        }
    }
}
