using AutoMapper;
using CommandPrompterServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommandPrompterServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : Controller
    {
        protected ICommandService _commandService { get; set; }
        protected ICommandParameterService _commandParameterService { get; set; }
        protected ICommandChainService _commandChainService { get; set; }
        protected IChainedCommandService _chainedCommandService { get; set; }
        protected IChainedCommandParameterService _chainedCommandParameterService { get; set; }
        protected IUserService _userService { get; set; }
        protected IPlateformService _plateformService { get; set; }
        protected IMapper _mapper { get; set; }
    }
}
