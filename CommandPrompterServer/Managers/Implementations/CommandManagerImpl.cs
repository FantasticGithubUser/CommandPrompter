using CommandPrompterServer.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Managers
{
    public class CommandManagerImpl : SimpleManagerImpl<Command>, ICommandManager
    {
        /// <summary>
        /// Get the newest commandParameters of specified command of given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CommandParameter> GetAllNewestParametersInOrder(string id)
        {
            var ret = from item in context.Commands where item.Id == id select context.CommandParameters;
            if(ret != null && ret.Count() != 0)
            {
                var parameters = ret.FirstOrDefault().ToList<CommandParameter>();
                var newestParameters = from item in parameters where (from i in parameters select i.LastVersionId).Contains(item.Id) == false orderby item.ParameterOrder ascending select item;
                if (newestParameters != null && newestParameters.Count() != 0)
                    return newestParameters.ToList<CommandParameter>();
            }
            return null;
        }

    }
}
