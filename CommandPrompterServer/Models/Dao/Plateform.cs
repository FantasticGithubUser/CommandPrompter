using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommandPrompterServer.Models.Dao
{
    public class Plateform : SimpleDao<Plateform>
    {
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(255)]
        [Required]
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(255)]
        [Required]
        [Column("PlateformVersion")]
        public string PlateformVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Plateform> ChildrenPlateforms { get; set; }
    }
}
