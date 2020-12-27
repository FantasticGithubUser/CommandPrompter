using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommandPrompterServer.Models.Dao
{
    public class Plateform : SimpleDao<Plateform>
    {
        /// <summary>
        /// The plateform name, i.e Entity framework etc.
        /// </summary>
        [MaxLength(255)]
        [Required]
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The plateform version, unlike the version of simpleDao, some commands are only available on specific version of same plateform.
        /// </summary>
        [MaxLength(255)]
        [Required]
        [Column("PlateformVersion")]
        public string PlateformVersion { get; set; }

        /// <summary>
        /// Just leave here.
        /// </summary>
        public virtual List<Plateform> ChildrenPlateforms { get; set; }
    }
}
