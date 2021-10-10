using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Asgla.Explosion.DB
{
    [Table("items")]
    [Index(nameof(TypeItemId), Name = "fk_items_types_items")]
    [Index(nameof(TypeRarityId), Name = "fk_items_types_rarities")]
    public partial class Item
    {
        public Item()
        {
            CharactersInventories = new HashSet<CharactersInventory>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("type_item_id", TypeName = "int(11)")]
        public int TypeItemId { get; set; }
        [Column("stats_id", TypeName = "int(11)")]
        public int? StatsId { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Column("description", TypeName = "text")]
        public string Description { get; set; }
        [Required]
        [Column("bundle")]
        [StringLength(100)]
        public string Bundle { get; set; }
        [Required]
        [Column("asset")]
        [StringLength(100)]
        public string Asset { get; set; }
        [Column("type_rarity_id", TypeName = "int(11)")]
        public int? TypeRarityId { get; set; }

        [ForeignKey(nameof(TypeItemId))]
        [InverseProperty(nameof(TypesItem.Items))]
        public virtual TypesItem TypeItem { get; set; }
        [ForeignKey(nameof(TypeRarityId))]
        [InverseProperty(nameof(TypesRarity.Items))]
        public virtual TypesRarity TypeRarity { get; set; }
        [InverseProperty(nameof(CharactersInventory.Item))]
        public virtual ICollection<CharactersInventory> CharactersInventories { get; set; }
    }
}
