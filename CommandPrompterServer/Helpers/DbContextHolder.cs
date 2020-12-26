using CommandPrompterServer.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CommandPrompterServer.Helpers
{
    /// <summary>
    /// To ensure that all context session in one thread are the same
    /// </summary>
    public class DbContextHolder
    {
        /// <summary>
        /// Thread local context for each thread.
        /// </summary>
        private readonly static ThreadLocal<CommandPrompterDbContext> context;

        private DbContextHolder()
        {

        }

        static DbContextHolder()
        {
            context = new ThreadLocal<CommandPrompterDbContext>(() => new CommandPrompterDbContext());
        }
        /// <summary>
        /// Easy used version of context.
        /// </summary>
        public static CommandPrompterDbContext Context => context.Value;
    }
}
