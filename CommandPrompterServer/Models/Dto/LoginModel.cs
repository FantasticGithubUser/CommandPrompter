using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Models.Dto
{
    public class LoginModel
    {
        /// <summary>
        /// Login username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Login password
        /// </summary>
        public string Password { get; set; }
    }
}
