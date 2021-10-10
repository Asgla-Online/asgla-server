using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Asgla.Explosion.DB {
    [Table("users")]
    public partial class User {
        public User() {
            Characters = new HashSet<Character>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [Required]
        [Column("username")]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [Column("email")]
        [StringLength(64)]
        public string Email { get; set; }

        [Required]
        [Column("password")]
        [StringLength(64)]
        public string Password { get; set; }

        [Column("access_level_id", TypeName = "int(11)")]
        public int AccessLevelId { get; set; }

        [Required]
        [Column("country_code")]
        [StringLength(2)]
        public string CountryCode { get; set; }

        [Required]
        [Column("ip_address")]
        [StringLength(100)]
        public string IpAddress { get; set; }

        [InverseProperty(nameof(Character.User))]
        public virtual ICollection<Character> Characters { get; set; }
    }
}
