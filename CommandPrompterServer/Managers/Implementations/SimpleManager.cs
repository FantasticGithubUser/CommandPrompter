using CommandPrompterServer.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Managers.Implementations
{
    public class SimpleManager<T> : BaseManager<T>, ISimpleManager<T> where T : SimpleDao<T>, new()
    {
        public T RemoveEntity(string id)
        {
            throw new NotImplementedException();
        }
    }
}
