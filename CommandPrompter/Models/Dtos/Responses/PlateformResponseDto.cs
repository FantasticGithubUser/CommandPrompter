using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPrompter.Models.Dtos.Responses
{
    public class PlateformResponseDto : BaseDto<PlateformResponseDto>
    {
        public string Name { get; set; }
        public string PlateformVersion { get; set; }

    }
}
