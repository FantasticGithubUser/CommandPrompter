using CommandPrompterServer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Services
{
    public class BaseServiceImpl : IBaseService
    {
        private ILogger logger { get; set; }
        public void DoSomething()
        {
            logger.Log("Doing Something");
        }
    }
}
