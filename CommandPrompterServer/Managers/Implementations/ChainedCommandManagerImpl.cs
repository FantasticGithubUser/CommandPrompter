using CommandPrompterServer.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandPrompterServer.Managers
{
    public class ChainedCommandManagerImpl : SimpleManagerImpl<ChainedCommand>, IChainedCommandManager
    {
        public List<ChainedCommandParameter> GetAllNewestChainedParametersInOrder(string id)
        {
            var ret = from item in context.ChainedCommands where item.Id == id select item.ChainedCommandParameters;
            if (ret != null && ret.Count() != 0)
            {
                var chainedParameters = ret.FirstOrDefault().ToList<ChainedCommandParameter>();
                var newestChainedParameters = from item in chainedParameters where (from i in chainedParameters select i.LastVersionId).Contains(item.Id) == false orderby item.ParameterOrder ascending select item;
                if (newestChainedParameters != null && newestChainedParameters.Count() != 0)
                    return newestChainedParameters.ToList<ChainedCommandParameter>();
            }
            return null;
        }
    }
}
