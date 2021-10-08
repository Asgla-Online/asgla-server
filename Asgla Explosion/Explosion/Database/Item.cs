using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asgla.Explosion.Database {

    [Table("asgla_items")]
    public partial class Item {

        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("ItemTypeID")]
        public int ItemTypeId { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Bundle")]
        public string Bundle { get; set; }

        [Column("Asset")]
        public string Asset { get; set; }

        [Column("Level")]
        public int Level { get; set; }

        [Column("Range")]
        public int Range { get; set; }

        [Column("RarityID")]
        public int RarityId { get; set; }

        [Column("Stack")]
        public int Stack { get; set; }

        [Column("Cost")]
        public int Cost { get; set; }

        public virtual TypeItem ItemType { get; set; }

        public virtual TypeRarity Rarity { get; set; }

    }
}
