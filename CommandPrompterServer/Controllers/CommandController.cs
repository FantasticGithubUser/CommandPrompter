using CommandPrompterServer.Models.Dao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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


    }
}
