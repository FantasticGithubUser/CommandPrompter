using Autofac.Extras.DynamicProxy;
using CommandPrompterServer.Helpers;
using CommandPrompterServer.Models.Dao;

namespace CommandPrompterServer.Managers
{
    /// <summary>
    /// The meta manager enabled the global intercept of all managers.
    /// </summary>

    [Intercept(typeof(ManagerInterceptor))]
    public interface IMetaManager<T> where T : BaseDao<T>, new()
    {
    }
}
