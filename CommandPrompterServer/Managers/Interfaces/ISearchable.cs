using CommandPrompterServer.Models.Dto;
using System.Collections.Generic;

namespace CommandPrompterServer.Managers
{
    public interface ISearchable
    {
        List<RelatedNameResponseDto> Search(string name);
    }
}
