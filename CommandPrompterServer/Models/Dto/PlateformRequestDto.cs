using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Models.Dto
{
    public class PlateformRequestDto
    {
        public string Name { get; set; }
        public string PlateformVersion { get; set; }
        public string PlateformId { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
