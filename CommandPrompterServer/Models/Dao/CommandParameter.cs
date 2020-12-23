using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Models.Dao
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandParameter : SimpleDao<CommandParameter>
    {
        /// <summary>
        /// The command id the parameter belongs to
        /// </summary>
        public string CommandId { get; set; }

        /// <summary>
        /// The command the parameter belongs to
        /// </summary>
        [ForeignKey("CommandId")]
        public Command Command { get; set; }

        /// <summary>
        /// The order this parameter in the command
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// The parameter's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// All the allowed value this parameter allowed
        /// </summary>
        public string AllowedValue { get; set; }

        /// <summary>
        /// Description of details
        /// </summary>
        public string Description { get; set; }
    }
}
