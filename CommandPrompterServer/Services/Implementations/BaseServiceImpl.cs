using CommandPrompterServer.Helpers;
using CommandPrompterServer.Managers;
using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public class BaseServiceImpl<T> : IBaseService<T> where T : BaseDao<T>, new()
    {
        //Todo: this _baseManager do not get injected while it's the called by the subclass.

        protected IBaseManager<T> _baseManager { get; set; }

        //Fix: Edit on 6:12 28 Des 2020, repalce the original property by field.
        //private IBaseManager<T> _baseManager = new BaseManagerImpl<T>();

        public virtual T AddNewEntity(T entity)
        {
            return _baseManager.AddNewEntity(entity);
        }

        public virtual T DeleteEntity(string id)
        {
            return _baseManager.DeleteEntity(id);
        }

        public virtual List<T> GetAllEntities()
        {
            return _baseManager.GetAllEntities();
        }

        public List<T> GetEntities(List<QueryField> fields)
        {
            return _baseManager.GetEntities(fields);
        }

        public virtual T GetEntityById(string id)
        {
            return _baseManager.GetEntityById(id);
        }

        public virtual T UpdateEntity(T entity)
        {
            return _baseManager.UpdateEntity(entity);
        }
    }
}
