using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Models.Dao
{
    /// <summary>
    /// The user entity
    /// </summary>
    public class User : BaseDao<User>
    {
        /// <summary>
        /// The user name
        /// </summary>
        [MaxLength(255)]
        [Required]
        [Column("Username")]
        public string Username { get; set; }
        /// <summary>
        /// The password
        /// </summary>
        [MaxLength(255)]
        [Required]
        [Column("Password")]
        public string Password { get; set; }

        /// <summary>
        /// The email to send message to.
        /// </summary>
        [MaxLength(255)]
        [Column("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Logs how many contributions this user has made, each cerate and update counts 1
        /// </summary>
        [Column("Contributes")]
        [Required]
        public double Contributes { get; set; }

        /// <summary>
        /// Whether the user has been deactivated
        /// </summary>
        [Column("Deactivated")]
        [Required]
        public bool Deactivated { get; set; }

        /// <summary>
        /// The deactivated time.
        /// </summary>
        [Column("DeactivatedTime")]
        public DateTime? DeactivatedTime { get; set; }
    }
}
