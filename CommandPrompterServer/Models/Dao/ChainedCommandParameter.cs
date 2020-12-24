using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommandPrompterServer.Models.Dao
{
    public class ChainedCommandParameter : SimpleDao<ChainedCommandParameter>
    {
        [MaxLength(36)]
        [Column("ChainedCommandId")]
        [Required]
        public string ChainedCommandId { get; set; }

        [ForeignKey("ChainedCommandId")]
        public ChainedCommand ChainedCommand { get; set; }

        [MaxLength(36)]
        [Column("CommandParameterId")]
        [Required]
        public string CommandParameterId { get; set; }

        [ForeignKey("CommandParameterId")]
        public CommandParameter CommandParameter { get; set; }

        [Required]
        [Column("ParameterOrder")]
        public int ParameterOrder { get; set; }

        [Column("ParameterValue")]
        [MaxLength(1023)]
        public string ParameterValue { get; set; }
    }
}
