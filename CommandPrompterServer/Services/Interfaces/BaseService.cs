using Autofac.Extras.DynamicProxy;
using CommandPrompterServer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Services
{
    [Intercept(typeof(ServiceInterceptor))]
    public interface IBaseService
    {
        void DoSomething();
    }
}
