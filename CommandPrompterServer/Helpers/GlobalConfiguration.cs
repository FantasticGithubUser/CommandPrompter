using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Helpers
{
    /// <summary>
    /// Import configuration from appsettings.json for further use.
    /// </summary>
    public static class GlobalConfiguration
    {
        /// <summary>
        /// The dbcontext connection string;
        /// </summary>
        public static string ConnectionString { get; private set; }

        /// <summary>
        /// Where the log files store.
        /// </summary>
        public static string LogPosition { get; set; }

        /// <summary>
        /// Import further used configuration from appsettings.json
        /// </summary>
        /// <param name="configuration"></param>
        public static void ImportConfiguration(IConfiguration configuration)
        {
            ConnectionString = configuration["ConnectionString"];
            LogPosition = configuration["LogPosition"];
        }
    }
}
