using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Models.Dao
{
    /// <summary>
    /// The user entity
    /// </summary>
    public class User : BaseDao<User>
    {
        /// <summary>
        /// The user name
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// The password
        /// </summary>
        public string Password { get; set; }
    }
}
