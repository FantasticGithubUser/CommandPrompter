using CommandPrompterServer.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CommandPrompterServer.Controllers
{
    public class CommonController : BaseController
    {

        /// <summary>
        /// Get all related name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRelatedNames/{name}/{count}")]
        [AllowAnonymous]
        public List<RelatedNameResponseDto> GetRelatedNames([FromRoute] string name, [FromRoute] int count)
        {
            var ret = new List<RelatedNameResponseDto>();
            var counter = 0;
            var temp = _commonService.SearchName(name);
            if (temp != null)
            {
                foreach (var item in temp)
                {
                    if (counter == count)
                        return ret;
                    ret.Add(item);
                    counter++;
                }
                return ret;
            }
            return null;
        }
    }
}
