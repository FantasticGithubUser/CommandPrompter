using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPrompter.Models.Dtos.Responses
{
    public class PlateformResponseDto : BaseDto<PlateformResponseDto>
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public string PlateformVersion { get; set; }
        public string CreatorId { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string PlateformId { get; set; }

    }
}
