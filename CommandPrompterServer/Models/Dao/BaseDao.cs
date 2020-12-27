using CommandPrompterServer.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CommandPrompterServer.Models.Dao
{
    /// <summary>
    /// The base dao.
    /// </summary>
    public abstract class BaseDao<T> : MetaDao where T : class, new()
    {
        /// <summary>
        /// The primary key, use guid
        /// </summary>
        [MaxLength(36)]
        [Required]
        [Column("Id")]
        public string Id { get; set; }

        /// <summary>
        /// Get a deep clone of this T object.
        /// </summary>
        /// <returns></returns>
        public T GetClone()
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            var props = this.GetType().GetProperties();
            foreach(var prop in props)
            {
                if (!prop.GetType().IsSubclassOf(typeof(MetaDao)))
                {
                    prop.SetValue(obj, prop.GetValue(this));
                }
            }
            return obj;
        }
    }
}
