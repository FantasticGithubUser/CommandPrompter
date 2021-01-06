using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommandPrompterServer.Models.Dao
{
    /// <summary>
    /// The command entity
    /// </summary>
    [Index("Name")]
    public class Command : SimpleDao<Command>
    {
        /// <summary>
        /// The plateform the command runs on
        /// </summary>
        [MaxLength(36)]
        [Column("PlateformId")]
        public string PlateformId { get; set; }

        [ForeignKey("PlateformId")]
        public virtual Plateform Plateform { get; set; }
        /// <summary>
        /// The command description
        /// </summary>
        [MaxLength(2047)]
        [Column("Description")]
        public string Description { get; set; }

        /// <summary>
        /// The template command， max character are limited to 1024, the max length for nvarchar can soar to 2GB if not limited.
        /// </summary>
        [MaxLength(1023)]
        [Column("Template")]
        public string Template { get; set; }

        /// <summary>
        /// The command name of the command 
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The CommandParameters
        /// </summary>
        public virtual List<CommandParameter> CommandParameters { get; set; }
    }
}
