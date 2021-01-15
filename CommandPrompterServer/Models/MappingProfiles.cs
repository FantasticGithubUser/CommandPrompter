using AutoMapper;
using CommandPrompterServer.Models.Dao;
using CommandPrompterServer.Models.Dto;

namespace CommandPrompterServer.Models
{
    /// <summary>
    /// Enable the automapper to map between controller and service automatically
    /// </summary>
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// Nessary configuration of automapper
        /// </summary>
        public MappingProfiles()
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<UserRequestDto, User>();
            CreateMap<Plateform, PlateformResponseDto>();
            CreateMap<PlateformRequestDto, Plateform>();
            CreateMap<Command, CommandResponseDto>();
        }
    }
}
