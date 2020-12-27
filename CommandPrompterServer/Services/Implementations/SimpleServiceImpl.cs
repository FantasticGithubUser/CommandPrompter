using CommandPrompterServer.Managers;
using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;
namespace CommandPrompterServer.Services
{
    public class SimpleServiceImpl<T> : BaseServiceImpl<T>, ISimpleService<T> where T : SimpleDao<T>, new()
    {
        private ISimpleManager<T> _simpleManager { get; set; }


        public virtual List<T> GetAllDistinctEntities()
        {
            return _simpleManager.GetAllDistinctEntities();
        }

        public virtual T GetLastVersion(string id)
        {
            return _simpleManager.GetLastVersion(id);
        }

        public virtual T GetNewestEntityById(string id)
        {
            return _simpleManager.GetNewestEntityById(id);
        }

        public virtual T GetNextVersion(string id)
        {
            return _simpleManager.GetNextVersion(id);
        }

        public List<T> GetSeriesById(string id)
        {
            return _simpleManager.GetSeriesById(id);
        }

        public List<T> GetSeriesBySeriesId(string seriesId)
        {
            return _simpleManager.GetSeriesBySeriesId(seriesId);
        }

        public T RemoveEntity(string id)
        {
            return _simpleManager.RemoveEntity(id);
        }
    }
}
