using CommandPrompterServer.Models.Dao;
using CommandPrompterServer.Models.Dto;
using System.Collections.Generic;
using System.Linq;

namespace CommandPrompterServer.Managers
{
    public class CommandParameterImpl : SimpleManagerImpl<CommandParameter>, ICommandParameterManager
    {
        public List<RelatedNameResponseDto> Search(string name)
        {
            var ret = from parameter in context.Set<CommandParameter>() where parameter.Name.Contains(name) select parameter;
            if (ret != null && ret.Count() != 0)
            {
                var list = new List<RelatedNameResponseDto>();
                foreach (var item in ret)
                {
                    list.Add(new RelatedNameResponseDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Type = "CommandParameter",
                        Version = item.Version
                    });
                }
                return list;
            }
            return null;
        }
    }
}
