using CommandPrompterServer.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandPrompterServer.Managers
{
    public class CommandChainManagerImpl : SimpleManagerImpl<CommandChain>, ICommandChainManager
    {
        public List<ChainedCommand> GetAllNewestChainedCommandInOrder(string id)
        {
            var ret = from item in context.CommandChains where item.Id == id select item.ChainedCommands;
            if(ret != null && ret.Count() != 0)
            {
                var chainedCommands = ret.FirstOrDefault().ToList<ChainedCommand>();
                var newestChainedCommands = from item in chainedCommands where (from i in chainedCommands select i.LastVersionId).Contains(item.Id) == false orderby item.CommandOrder ascending select item;
                if (newestChainedCommands != null && newestChainedCommands.Count() != 0)
                    return newestChainedCommands.ToList<ChainedCommand>();
            }
            return null;
        }
    }
}
