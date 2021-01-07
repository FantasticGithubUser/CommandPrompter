using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPrompter.Models.Dtos.Responses
{
    public class RelatedNameResponseDto
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public int Version { get; set; }
        public string Description { get; set; }
    }
}
