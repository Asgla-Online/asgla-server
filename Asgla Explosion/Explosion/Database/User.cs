using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asgla.Explosion.Database {

    [Table("asgla_users")]
    public partial class User {

        public User() {
            UserInventory = new HashSet<UserInventory>();
        }

        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("Username")]
        public string Username { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Gender")]
        public string Gender { get; set; }

        [Column("Level")]
        public int Level { get; set; }

        [Column("Gold")]
        public int Gold { get; set; }

        [Column("Experience")]
        public int Experience { get; set; }

        [Column("ColorAccessory")]
        public string ColorAccessory { get; set; }

        [Column("ColorBase")]
        public string ColorBase { get; set; }

        [Column("ColorTrim")]
        public string ColorTrim { get; set; }

        [Column("ColorSkin")]
        public string ColorSkin { get; set; }

        [Column("ColorEye")]
        public string ColorEye { get; set; }

        [Column("ColorHair")]
        public string ColorHair { get; set; }

        [Column("HairID")]
        public int HairId { get; set; }

        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Column("DateCreated")]
        public DateTime DateCreated { get; set; }

        [Column("LastArea")]
        public string LastArea { get; set; }

        [Column("remember_token")]
        public string RememberToken { get; set; }

        [Column("Token")]
        public string Token { get; set; }

        public virtual ICollection<UserInventory> UserInventory { get; set; }

    }

}
