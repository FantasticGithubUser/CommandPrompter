using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Models.Dao
{
    /// <summary>
    /// The simple dao.
    /// </summary>
    public abstract class SimpleDao<T> : BaseDao<T> where T : class, new()
    {
        /// <summary>
        /// The creator user id
        /// </summary>
        [MaxLength(36)]
        public string CreatorId { get; set; }
        /// <summary>
        /// Version selt incremented
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// The flag define whether the entry is logically deleted.
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Reference to the last Simple dao.
        /// </summary>
        [ForeignKey("LastVersionId")]
        public T LastSimpleDao { get; set; }

#nullable enable
        /// <summary>
        /// The creation time
        /// </summary>
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// Reference to the last version before modified
        /// </summary>
        [MaxLength(36)]
        public string? LastVersionId { get; set; }
        /// <summary>
        /// The deletion time
        /// </summary>
        public DateTime? DeletionTime { get; set; }
        /// <summary>
        /// The user that entry deleted by
        /// </summary>
        [MaxLength(36)]
        public string? DeletedBy { get; set; }
#nullable disable
    }
}
