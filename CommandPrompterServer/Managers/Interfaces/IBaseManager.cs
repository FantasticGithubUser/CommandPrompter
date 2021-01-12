using CommandPrompterServer.Helpers;
using CommandPrompterServer.Models.Dao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CommandPrompterServer.Managers
{
    /// <summary>
    /// The purpose of setting manager is to implement some convenient function on entities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseManager<T> : IMetaManager<T> where T : BaseDao<T>, new()
    {
        /// <summary>
        /// Get entity by id ( all entries will be searched )
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetEntityById(string id);

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
        T UpdateEntity(T entity);

        /// <summary>
        /// Delete an entity already exists in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T DeleteEntity(string id);

        /// <summary>
        /// Return all entries in database
        /// </summary>
        /// <returns></returns>
        List<T> GetAllEntities();

        /// <summary>
        /// Customize the filters.
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        List<T> GetEntities(List<QueryField> fields);
    }
}
