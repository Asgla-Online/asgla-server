using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Asgla.Explosion.DB
{
    [Table("types_rarities")]
    public partial class TypesRarity
    {
        public TypesRarity()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Column("description", TypeName = "text")]
        public string Description { get; set; }
        [Required]
        [Column("color")]
        [StringLength(6)]
        public string Color { get; set; }

        [InverseProperty(nameof(Item.TypeRarity))]
        public virtual ICollection<Item> Items { get; set; }
    }
}
