using Autofac.Extras.DynamicProxy;
using CommandPrompterServer.Helpers;

namespace CommandPrompterServer.Services
{
    /// <summary>
    /// The base service, enabled the global interceptor of all services.
    /// </summary>
    [Intercept(typeof(ServiceInterceptor))]
    public interface IBaseService
    {

    }
}