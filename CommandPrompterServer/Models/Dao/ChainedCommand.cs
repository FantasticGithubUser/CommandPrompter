using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommandPrompterServer.Models.Dao
{
    public class ChainedCommand : SimpleDao<ChainedCommand>
    {
        /// <summary>
        /// The CommandChain this chainedCommand belongs to
        /// </summary>
        [MaxLength(36)]
        [Column("CommandChainId")]
        [Required]
        public string CommandChainId { get; set; }

        /// <summary>
        /// The navigation property of the belonged CommandChain
        /// </summary>
        [ForeignKey("CommandChainId")]
        public virtual CommandChain CommandChain { get; set; }

        /// <summary>
        /// The command this chainedCommand relates to
        /// </summary>
        [MaxLength(36)]
        [Column("CommandId")]
        [Required]
        public string CommandId { get; set; }

        /// <summary>
        /// The navigation property of related command.
        /// </summary>
        [ForeignKey("CommandId")]
        public virtual Command Command { get; set; }

        /// <summary>
        /// The command order in the commandChain
        /// </summary>
        [Required]
        [Column("CommandOrder")]
        public int CommandOrder { get; set; }

        /// <summary>
        /// The pareameters links to the command.
        /// </summary>
        public virtual List<ChainedCommandParameter> ChainedCommandParameters { get; set; }


    }
}
