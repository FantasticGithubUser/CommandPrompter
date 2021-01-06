using CommandPrompterServer.Models.Dto;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public interface ICommonService : IMetaService
    {
        List<RelatedNameResponseDto> SearchName(string name);
    }
}
