using System;
using System.Collections.Generic;
using System.Linq;
using CommandPrompterServer.Helpers;
using CommandPrompterServer.Models.Dao;

namespace CommandPrompterServer.Managers
{
    public class BaseManagerImpl<T> : IBaseManager<T> where T : BaseDao<T>, new()
    {
        protected CommandPrompterDbContext context => DbContextHolder.Context;
        public virtual T AddNewEntity(T entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            context.Set<T>().Add(entity);
            return entity;
        }

        public virtual T DeleteEntity(string id)
        {
            var ret = from item in context.Set<T>() where item.Id == id select item;
            if(ret != null)
            {
                var entity = ret.FirstOrDefault();
                context.Set<T>().Remove(entity);
                return entity;
            }
            return null;
        }
        
        public virtual T GetEntityById(string id)
        {
            var ret = from item in context.Set<T>() where item.Id == id select item;
            if(ret != null)
                return ret.FirstOrDefault();
            return null;
            
        }

        public virtual T UpdateEntity(T entity)
        {
            var ret = from item in context.Set<T>() where item.Id == entity.Id select item;
            if (ret != null)
            {
                foreach(var prop in ret.FirstOrDefault().GetType().GetProperties())
                {
                    if (!prop.GetType().IsSubclassOf(typeof(MetaDao)))
                    {
                        prop.SetValue(ret.FirstOrDefault(), prop.GetValue(entity));
                    }
                }
                context.Set<T>().Update(ret.FirstOrDefault());
                return ret.FirstOrDefault();
            }
            return null;
        }
        public virtual List<T> GetAllEntities()
        {
            var ret = from item in context.Set<T>() select item;
            return ret == null ? null : ret.ToList<T>();
        }

    }
}
