using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Managers
{
    public interface ISimpleManager<T> : IBaseManager<T> where T: SimpleDao<T>, new() 
    {
        void AddHot(string id);
        T GetNewestEntityById(string id);
        T GetLastVersion(string id);
        T GetNextVersion(string id);
        T RemoveEntity(string id);
        List<T> GetAllDistinctEntities();
        List<T> GetSeriesById(string id);
        List<T> GetSeriesBySeriesId(string seriesId);
    }
}
