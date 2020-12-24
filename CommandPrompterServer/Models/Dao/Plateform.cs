using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommandPrompterServer.Models.Dao
{
    public class Plateform : SimpleDao<Plateform>
    {
        [MaxLength(255)]
        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [MaxLength(255)]
        [Required]
        [Column("PlateformVersion")]
        public string PlateformVersion { get; set; }

        [MaxLength(36)]
        [Column("ParentformId")]
        [ForeignKey("Id")]
        public string ParentPlateformId { get; set; }

        [ForeignKey("ParentPlateformId")]
        public Plateform ParentPlateform { get; set; }

        public List<Plateform> ChildrenPlateforms { get; set; }
    }
}
