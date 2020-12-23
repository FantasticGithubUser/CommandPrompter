using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Models.Dao
{
    /// <summary>
    /// The command entity
    /// </summary>
    public class Command : SimpleDao<Command>
    {
        /// <summary>
        /// The plateform the command runs on
        /// </summary>
        public string Plateform { get; set; }

        /// <summary>
        /// The command description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The template command.
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// The command name of the command 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The CommandParameters
        /// </summary>
        public ICollection<CommandParameter> CommandParameteres { get; set; }
    }
}
