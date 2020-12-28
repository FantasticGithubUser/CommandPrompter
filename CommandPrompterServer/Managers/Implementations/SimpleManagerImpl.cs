using CommandPrompterServer.Helpers;
using CommandPrompterServer.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Managers
{
    public class SimpleManagerImpl<T> : BaseManagerImpl<T>, ISimpleManager<T> where T : SimpleDao<T>, new()
    {
        public virtual T GetLastVersion(string id)
        {
            var ret = from entity in context.Set<T>() where entity.Id == id && entity.Deleted == false select entity;
            if (ret != null && ret.Count() != 0)
            {
                return ret.FirstOrDefault()
                    .LastSimpleDao;
            }
            return null;
        }

        public virtual T GetNextVersion(string id)
        {
            var ret = from entity in context.Set<T>() where entity.LastVersionId == id && entity.Deleted == false select entity;
            if(ret != null && ret.Count() != 0)
            {
                return ret.FirstOrDefault();
            }
            return null;
        }

        public virtual T RemoveEntity(string id)
        {
            var ret = from entity in context.Set<T>() where entity.Id == id && entity.Deleted == false select entity;
            if(ret != null && ret.Count() != 0)
            {
                ret.FirstOrDefault().Deleted = true;
                ret.FirstOrDefault().DeletedBy = AccountHolder.User.Id;
                ret.FirstOrDefault().DeletionTime = DateTime.Now;
                context.Update(ret);
                return ret.FirstOrDefault();
            }
            return null;
        }

        public override T AddNewEntity(T entity)
        {
            entity.SeriesId = Guid.NewGuid().ToString();
            entity.Id = Guid.NewGuid().ToString();
            entity.CreationTime = DateTime.Now;
            entity.CreatorId = AccountHolder.User.Id;
            entity.Version = 0;//The initial version, add one by one subsequently.
            entity.LastVersionId = "";
            entity.Deleted = false;
            entity.DeletedBy = "";
            entity.DeletionTime = null;
            context.Set<T>().Add(entity);
            return entity;
        }

        public override T UpdateEntity(T entity)
        {
            var ret = from item in context.Set<T>() where item.Id == entity.Id select item;
            if (ret != null)
            {
                T newEntity = entity.GetClone();
                newEntity.Version++;
                newEntity.CreatorId = AccountHolder.User.Id;
                newEntity.CreationTime = DateTime.Now;
                newEntity.Deleted = false;
                newEntity.DeletedBy = "";
                newEntity.DeletionTime = null;
                newEntity.Id = Guid.NewGuid().ToString();
                newEntity.LastVersionId = entity.Id;
                context.Set<T>().Add(newEntity);
                return newEntity;
            }
            return null;
        }

        public virtual List<T> GetAllDistinctEntities()
        {
            var ret = from item in context.Set<T>() where (from i in context.Set<T>() select i.LastVersionId).Contains(item.Id) == false select item;
            if(ret != null && ret.Count() != 0)
            {
                return ret.ToList<T>();
            }
            return null;
        }

        /// <summary>
        /// Get the id of the entity, return the neweset version of this entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetNewestEntityById(string id)
        {
            var newestList = GetAllDistinctEntities();
            T ret = null;
            foreach(var item in newestList)
            {
                ret = item;
                while(ret != null)
                {
                    if(ret.Id == id)
                    {
                        return item;
                    }
                    else
                    {
                        ret = ret.LastSimpleDao;
                    }
                }
            }
            return null;
        }

        public List<T> GetSeriesById(string id)
        {
            var seriesId = from item in context.Set<T>() where item.Id == id select item.SeriesId;
            if(seriesId != null && seriesId.Count() != 0)
            {
                var series = from item in context.Set<T>() where item.SeriesId == seriesId.FirstOrDefault() select item;
                if(series != null && series.Count() != 0)
                {
                    return series.ToList<T>();
                }
            }
            return null;
        }

        public List<T> GetSeriesBySeriesId(string seriesId)
        {
            var series = from item in context.Set<T>() where item.SeriesId == seriesId select item;
            if (series != null && series.Count() != 0)
            {
                return series.ToList<T>();
            }
            return null;
        }
    }
}
