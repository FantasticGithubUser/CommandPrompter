using Autofac.Extras.DynamicProxy;
using CommandPrompterServer.Helpers;

namespace CommandPrompterServer.Services
{
    [Intercept(typeof(ServiceInterceptor))]
    public interface IBaseService
    {
        void DoSomething();
    }
}
