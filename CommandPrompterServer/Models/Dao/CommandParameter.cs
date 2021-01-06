using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommandPrompterServer.Models.Dao
{
    /// <summary>
    /// 
    /// </summary>
    [Index("Name")]
    public class CommandParameter : SimpleDao<CommandParameter>
    {
        /// <summary>
        /// The command id the parameter belongs to
        /// </summary>
        [Required]
        [MaxLength(36)]
        public string CommandId { get; set; }

        /// <summary>
        /// The command the parameter belongs to
        /// </summary>
        [ForeignKey("CommandId")]
        public virtual Command Command { get; set; }

        /// <summary>
        /// The order this parameter in the command, starts with 0
        /// </summary>
        [Column("ParameterOrder")]
        [Required]
        public int ParameterOrder { get; set; }

        /// <summary>
        /// The parameter's name
        /// </summary>
        [Column("Name")]
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// All the allowed value this parameter allowed
        /// </summary>
        [Column("AllowedValueExample")]
        [MaxLength(1023)]
        public string AllowedValueExample { get; set; }

        /// <summary>
        /// Description of details
        /// </summary>
        [Column("Description")]
        [MaxLength(2047)]
        public string Description { get; set; }
    }
}
