using Autofac.Extras.DynamicProxy;
using CommandPrompterServer.Helpers;

namespace CommandPrompterServer.Services.Interfaces
{
    [Intercept(typeof(ServiceInterceptor))]
    public interface IDatabaseService
    {
        void EnsureClearDatabase();
        void EnsureCreateDatabase();
    }
}
