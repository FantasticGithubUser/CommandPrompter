using AutoMapper;
using CommandPrompterServer.Models.Dao;
using CommandPrompterServer.Models.Dto;
using CommandPrompterServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommandPrompterServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandController : Controller
    {
        private ICommandService _commandService { get; set; }
        private IMapper _mapper { get; set; }

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
    }
}
