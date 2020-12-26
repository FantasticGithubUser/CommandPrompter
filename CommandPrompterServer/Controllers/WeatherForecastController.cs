using CommandPrompterServer.Helpers;
using CommandPrompterServer.Models.Dao;
using CommandPrompterServer.Services;
using CommandPrompterServer.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Controllers
{
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        public IBaseService _service { get; set; }

        public IUserService _userService { get; set; }
        /// <summary>
        /// Get weather infomations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize]
        [AllowAnonymous]
        public async Task<IEnumerable<string>> Get()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            //_service.DoSomething();
            
            return new string[] { accessToken,"Successed!" };
        }

        [HttpPut]
        [AllowAnonymous]
        public User Put([FromBody] User user)
        {
            return _userService.AddNewUser(user);
        }

    }
}
