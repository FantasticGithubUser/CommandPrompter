using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Models.Dto
{
    public class UserResponseDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public double Contributes { get; set; }

        public DateTime? RegisterTime { get; set; }
    }
}
