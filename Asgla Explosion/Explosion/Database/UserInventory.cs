using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asgla.Explosion.Database {

    [Table("asgla_users_inventory")]
    public partial class UserInventory {

        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("UserID")]
        public int UserId { get; set; }

        [Column("ItemID")]
        public int ItemId { get; set; }

        [Column("IsEquipped")]
        public bool IsEquipped { get; set; }

        [Column("IsOnBank")]
        public bool IsOnBank { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }

        [Column("DatePurchased")]
        public DateTime DatePurchased { get; set; }

        public virtual Item Item { get; set; }

        public virtual User User { get; set; }

    }

}
