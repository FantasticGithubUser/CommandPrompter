using Autofac.Extras.DynamicProxy;
using CommandPrompterServer.Helpers;

namespace CommandPrompterServer.Services.Interfaces
{
    public interface IDatabaseService : IBaseService
    {
        void EnsureClearDatabase();
        void EnsureCreateDatabase();
    }
}
