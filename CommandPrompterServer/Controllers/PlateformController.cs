using CommandPrompterServer.Helpers;
using CommandPrompterServer.Models.Dao;
using CommandPrompterServer.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CommandPrompterServer.Controllers
{
    public class PlateformController : BaseController
    {
        [HttpPut]
        [Route("AddPlateform")]
        [Authorize]
        public PlateformResponseDto AddNewPlateform([FromBody] PlateformRequestDto request)
        {
            var plateform = _mapper.Map<Plateform>(request);
            return _mapper.Map<PlateformResponseDto>(_plateformService.AddNewEntity(plateform));
        }

        [HttpPost]
        [Route("UpdatePlateform")]
        [Authorize]
        public PlateformResponseDto UpdatePlateform([FromBody] PlateformRequestDto request)
        {
            var plateform = _mapper.Map<Plateform>(request);
            return _mapper.Map<PlateformResponseDto>(_plateformService.UpdateEntity(plateform));
        }

        [HttpGet]
        [Route("GetPlateform/{id}")]
        [Authorize]
        public PlateformResponseDto GetPlateformById([FromQuery] string id)
        {
            return _mapper.Map<PlateformResponseDto>(_plateformService.GetEntityById(id));
        }

        [HttpGet]
        [Route("GetAllPlateforms")]
        [Authorize]
        public List<PlateformResponseDto> GetAllPlateforms()
        {

            var list = _plateformService.GetAllEntities();
            var ret = new List<PlateformResponseDto>();
            foreach(var item in list)
            {
                ret.Add(_mapper.Map<PlateformResponseDto>(item));
            }
            return ret;
        }

        [HttpGet]
        [Route("GetAllDistinctPlateforms")]
        [Authorize]
        public List<PlateformResponseDto> GetAllDistinctPlateforms()
        {
            var plateforms = _plateformService.GetAllDistinctEntities();
            if (plateforms != null)
            {
                var response = new List<PlateformResponseDto>();
                foreach (var item in plateforms)
                {
                    var plateform = _mapper.Map<PlateformResponseDto>(item);
                    response.Add(plateform);
                }
                return response;
            }
            return null;
        }

        [HttpPost]
        [Route("GetEntities")]
        [AllowAnonymous]
        public List<PlateformResponseDto> GetEntities([FromBody] List<QueryField> fields)
        {
            var plateforms = _plateformService.GetEntities(fields);
            if (plateforms != null)
            {
                var response = new List<PlateformResponseDto>();
                foreach (var item in plateforms)
                {
                    var plateform = _mapper.Map<PlateformResponseDto>(item);
                    response.Add(plateform);
                }
                return response;
            }
            return null;
        }
    }
}
