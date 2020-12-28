using CommandPrompterServer.Models.Dao;
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
        public Plateform AddNewPlateform([FromBody] Plateform plateform)
        {
            return _plateformService.AddNewEntity(plateform);
        }

        [HttpPost]
        [Route("UpdatePlateform")]
        [Authorize]
        public Plateform UpdatePlateform([FromBody] Plateform plateform)
        {
            return _plateformService.UpdateEntity(plateform);
        }

        [HttpGet]
        [Route("GetPlateform/{id}")]
        [Authorize]
        public Plateform GetPlateformById([FromQuery] string id)
        {
            return _plateformService.GetEntityById(id);
        }

        [HttpGet]
        [Route("GetAllPlateforms")]
        [Authorize]
        public List<Plateform> GetAllPlateforms()
        {
            return _plateformService.GetAllEntities();
        }
        
        [HttpGet]
        [Route("GetAllDistinctPlateforms")]
        [Authorize]
        public List<Plateform> GetAllDistinctPlateforms()
        {
            return _plateformService.GetAllDistinctEntities();
        }
    }
}
