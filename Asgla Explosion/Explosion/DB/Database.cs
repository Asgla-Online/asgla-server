using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Asgla.Explosion.DB {
    public partial class Database : DbContext {

        public Database() {
        }

        public Database(DbContextOptions<Database> options)
            : base(options) {
        }

        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<CharactersInventory> CharactersInventories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<TypesItem> TypesItems { get; set; }
        public virtual DbSet<TypesRarity> TypesRarities { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=321;database=asgla", ServerVersion.Parse("10.6.4-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            modelBuilder.Entity<Character>(entity => {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_characters_users");
            });

            modelBuilder.Entity<CharactersInventory>(entity => {
                entity.Property(e => e.PurchaseDate).HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharactersInventories)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_characters_inventory");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.CharactersInventories)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_characters_inventory_items");
            });

            modelBuilder.Entity<Item>(entity => {
                entity.HasOne(d => d.TypeItem)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.TypeItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_items_types_items");

                entity.HasOne(d => d.TypeRarity)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.TypeRarityId)
                    .HasConstraintName("fk_items_types_rarities");
            });

            modelBuilder.Entity<TypesRarity>(entity => {
                entity.Property(e => e.Color).IsFixedLength(true);
            });

            modelBuilder.Entity<User>(entity => {
                entity.Property(e => e.CountryCode).IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
