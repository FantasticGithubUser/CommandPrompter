using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommandPrompterServer.Models.Dao
{
    public class ChainedCommand : SimpleDao<ChainedCommand>
    {
        [MaxLength(36)]
        [Column("CommandChainId")]
        [Required]
        public string CommandChainId { get; set; }

        [ForeignKey("CommandChainId")]
        public CommandChain CommandChain { get; set; }

        [MaxLength(36)]
        [Column("CommandId")]
        [Required]
        public string CommandId { get; set; }

        [ForeignKey("CommandId")]
        public Command Command { get; set; }

        [Required]
        [Column("CommandOrder")]
        public int CommandOrder { get; set; }
        public List<ChainedCommandParameter> ChainedCommandParameters { get; set; }


    }
}
