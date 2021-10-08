using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asgla.Explosion.Database {

    [Table("asgla_types_rarity")]
    public partial class TypeRarity {

        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

    }

}
