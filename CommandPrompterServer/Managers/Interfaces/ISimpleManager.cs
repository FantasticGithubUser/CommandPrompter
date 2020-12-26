using CommandPrompterServer.Models.Dao;

namespace CommandPrompterServer.Managers
{
    public interface ISimpleManager<T> : IBaseManager<T> where T: SimpleDao<T>, new() 
    {

    }
}
