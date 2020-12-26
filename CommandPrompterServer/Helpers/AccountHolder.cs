using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CommandPrompterServer.Helpers
{
    /// <summary>
    /// Ensure that the Process are operated by the logged in user without interuppted by other logged in users.
    /// </summary>
    public class AccountHolder
    {
        /// <summary>
        /// This mechanism can ensure that each thread has it's own duplication of this object, which will not be interfered.
        /// We not make this variable readonly and private is for the reason i need to further more inject the user login token into this variable.
        /// </summary>
        public static ThreadLocal<string> userId;
        private AccountHolder()
        {

        }
        
        static AccountHolder()
        {
            userId = new ThreadLocal<string>( () =>"");
        }

        /// <summary>
        /// Just offered a convenient approach to access the user id.
        /// </summary>
        public static string UserId => userId.Value; 
    }
}
