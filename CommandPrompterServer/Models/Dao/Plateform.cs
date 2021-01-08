using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommandPrompterServer.Models.Dao
{
    [Index("Name")]
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
        /// The father plateform
        /// </summary>
        [MaxLength(36)]
        [Column("PlateformId")]
        public string PlateformId { get; set; }

        /// <summary>
        /// The navigation property of the father plateform id property
        /// </summary>
        [ForeignKey("PlateformId")]
        public virtual Plateform FatherPlateform { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [MaxLength(2047)]
        [Column("Description")]
        public string Description { get; set; }

        /// <summary>
        /// The Image
        /// </summary>
        [Column("Image")]
        public byte[] Image { get; set; }
        ///// <summary>
        ///// Just leave here.
        ///// </summary>
        //public virtual List<Plateform> ChildrenPlateforms { get; set; }
    }
}
