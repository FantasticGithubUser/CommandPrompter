using CommandPrompterServer.Helpers;
using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    /// <summary>
    /// The base service with basic data operation function.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<T> : IMetaService where T : BaseDao<T>, new()
    {
        T GetEntityById(string id);

        T AddNewEntity(T entity);

        T UpdateEntity(T entity);

        T DeleteEntity(string id);

        List<T> GetAllEntities();

        List<T> GetEntities(List<QueryField> fields);

    }
}