using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Asgla.Explosion.DB
{
    [Table("characters_inventory")]
    [Index(nameof(CharacterId), Name = "fk_characters_inventory")]
    [Index(nameof(ItemId), Name = "fk_characters_inventory_items")]
    public partial class CharactersInventory
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("character_id", TypeName = "int(11)")]
        public int CharacterId { get; set; }
        [Column("item_id", TypeName = "int(11)")]
        public int ItemId { get; set; }
        [Column("is_deleted", TypeName = "tinyint(4)")]
        public sbyte IsDeleted { get; set; }
        [Column("purchase_date", TypeName = "timestamp")]
        public DateTime PurchaseDate { get; set; }

        [ForeignKey(nameof(CharacterId))]
        [InverseProperty("CharactersInventories")]
        public virtual Character Character { get; set; }
        [ForeignKey(nameof(ItemId))]
        [InverseProperty("CharactersInventories")]
        public virtual Item Item { get; set; }
    }
}
