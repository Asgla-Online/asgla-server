using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asgla.Explosion.Database {

    [Table("asgla_types_items")]
    public partial class TypeItem {

        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Category")]
        public int Category { get; set; }

        [Column("Equipment")]
        public string Equipment { get; set; }

        [Column("Icon")]
        public string Icon { get; set; }

    }

}
