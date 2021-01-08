using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Models.Dto
{
    public class UserRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }
    }
}
