using Autofac.Extras.DynamicProxy;
using CommandPrompterServer.Helpers;
using CommandPrompterServer.Models.Dao;

namespace CommandPrompterServer.Managers
{
    /// <summary>
    /// The basemanager enabled the global intercept of all managers.
    /// The purpose of setting manager is to implement some convenient function on entities.
    /// </summary>
    [Intercept(typeof(ManagerInterceptor))]
    public interface IBaseManager<T> where T : BaseDao<T>, new()
    {
        /// <summary>
        /// Get entity by id ( all entries will be searched )
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetEntityById(string id);

        /// <summary>
        /// Get entity by id ( deleted entries will be filtered out )
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetEneityByIdFilterOutDeleted(string id);

        /// <summary>
        /// Add a new entity into database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T AddNewEntity(T entity);

        /// <summary>
        /// Update an entity already exists in database
        /// </summary>
        /// <param name="eneity"></param>
        /// <returns></returns>
        T UpdateEntity(T eneity);

        /// <summary>
        /// Delete an entity already exists in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T DeleteEntity(string id);

    }
}
