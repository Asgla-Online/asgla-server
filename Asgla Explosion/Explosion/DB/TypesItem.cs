using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Asgla.Explosion.DB
{
    [Table("types_items")]
    public partial class TypesItem
    {
        public TypesItem()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }

        [InverseProperty(nameof(Item.TypeItem))]
        public virtual ICollection<Item> Items { get; set; }
    }
}
