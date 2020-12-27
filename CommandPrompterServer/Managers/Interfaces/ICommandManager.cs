using CommandPrompterServer.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Managers
{
    public interface ICommandManager : ISimpleManager<Command>
    {
        List<CommandParameter> GetAllNewestParametersInOrder(string id);


    }
}
