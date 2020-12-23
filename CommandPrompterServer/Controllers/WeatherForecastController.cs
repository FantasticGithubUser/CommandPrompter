using CommandPrompterServer.Helpers;
using CommandPrompterServer.Services;
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
            _service.DoSomething();
            return new string[] { accessToken,"Successed!" };
        }
    }
}
