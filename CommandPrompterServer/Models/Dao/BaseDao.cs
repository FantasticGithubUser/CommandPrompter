using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Models.Dao
{
    /// <summary>
    /// The base dao.
    /// </summary>
    public abstract class BaseDao<T> where T : class, new()
    {
        /// <summary>
        /// The primary key, use guid
        /// </summary>
        [MaxLength(36)]
        public string Id { get; set; }
    }
}
