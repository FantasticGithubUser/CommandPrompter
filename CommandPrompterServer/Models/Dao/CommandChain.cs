using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommandPrompterServer.Models.Dao
{
    [Index("Name")]
    public class CommandChain : SimpleDao<CommandChain>
    {
        /// <summary>
        /// Each Command Chain must belongs to specific plateform, the plateform should be generated from 
        /// </summary>
        [MaxLength(36)]
        [Column("PlateformId")]
        [Required]
        public string PlateformId { get; set; }

        [ForeignKey("PlateformId")]
        public virtual Plateform Plateform { get; set; }

        [MaxLength(255)]
        [Column("Name")]
        [Required]
        public string Name { get; set; }

        [MaxLength(2047)]
        [Column("Description")]
        public string Description { get; set; }

        public virtual List<ChainedCommand> ChainedCommands { get; set; }


    }
}
