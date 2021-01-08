using CommandPrompterServer.Models.Dao;
using CommandPrompterServer.Models.Dto;
using System.Collections.Generic;
using System.Linq;

namespace CommandPrompterServer.Managers
{
    public class PlateformManagerImpl : SimpleManagerImpl<Plateform>, IPlateformManager
    {
        public List<RelatedNameResponseDto> Search(string name)
        {
            var ret = from plateform in context.Set<Plateform>() where plateform.Name.Contains(name) select plateform;
            if (ret != null && ret.Count() != 0)
            {
                var list = new List<RelatedNameResponseDto>();
                foreach (var item in ret)
                {
                    list.Add(new RelatedNameResponseDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Type = "Plateform",
                        Version = item.Version,
                        Description = item.Description
                    });
                }
                return list;
            }
            return null;
        }
    }
}
