using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Asgla.Explosion.DB
{
    [Table("characters")]
    [Index(nameof(UserId), Name = "fk_characters_users")]
    public partial class Character
    {
        public Character()
        {
            CharactersInventories = new HashSet<CharactersInventory>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("user_id", TypeName = "int(11)")]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Characters")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(CharactersInventory.Character))]
        public virtual ICollection<CharactersInventory> CharactersInventories { get; set; }
    }
}
