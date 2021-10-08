using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Asgla.Explosion.Database {
    public partial class MariaDB : DbContext {

        public MariaDB() {
        }

        public MariaDB(DbContextOptions<MariaDB> options)
            : base(options) {
        }

        public virtual DbSet<Item> DBItem { get; set; }
        public virtual DbSet<TypeItem> DBTypeItem { get; set; }
        public virtual DbSet<TypeRarity> DBTypeRarity { get; set; }
        public virtual DbSet<User> DBUser { get; set; }
        public virtual DbSet<UserInventory> DBUserInventory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder() {
                    ,
                    ,
                    ,
                    ,
                    ,
                    Pooling = true,
                    MinimumPoolSize = 20
                };

                optionsBuilder.UseMySql(builder.ToString(), x => x.ServerVersion("10.4.13-mariadb"));
            }
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<AsglaItems>(entity => {
                entity.HasNoKey();

                entity.ToTable("asgla_items");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.HasIndex(e => e.ItemTypeId)
                    .HasName("ItemItemTypeID");

                entity.HasIndex(e => e.RarityId)
                    .HasName("ItemRarityID");

                entity.Property(e => e.Asset)
                    .IsRequired()
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Bundle)
                    .IsRequired()
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ClassId)
                    .HasColumnName("ClassID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cost).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EnhId)
                    .HasColumnName("EnhID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ItemTypeId)
                    .HasColumnName("ItemTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Level)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Range)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'100'");

                entity.Property(e => e.RarityId)
                    .HasColumnName("RarityID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Stack)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.ItemType)
                    .WithMany()
                    .HasForeignKey(d => d.ItemTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ItemItemTypeID");

                entity.HasOne(d => d.Rarity)
                    .WithMany()
                    .HasForeignKey(d => d.RarityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ItemRarityID");
            });

            modelBuilder.Entity<AsglaTypesItems>(entity => {
                entity.ToTable("asgla_types_items");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Category).HasColumnType("int(11)");

                entity.Property(e => e.Equipment)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<AsglaTypesRarity>(entity => {
                entity.ToTable("asgla_types_rarity");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("Name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<AsglaUsers>(entity => {
                entity.ToTable("asgla_users");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ColorAccessory)
                    .IsRequired()
                    .HasColumnType("char(6)")
                    .HasDefaultValueSql("'000000'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ColorBase)
                    .IsRequired()
                    .HasColumnType("char(6)")
                    .HasDefaultValueSql("'000000'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ColorEye)
                    .IsRequired()
                    .HasColumnType("char(6)")
                    .HasDefaultValueSql("'1649e'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ColorHair)
                    .IsRequired()
                    .HasColumnType("char(6)")
                    .HasDefaultValueSql("'5e4f37'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ColorSkin)
                    .IsRequired()
                    .HasColumnType("char(6)")
                    .HasDefaultValueSql("'eacd8a'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ColorTrim)
                    .IsRequired()
                    .HasColumnType("char(6)")
                    .HasDefaultValueSql("'000000'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'2015-01-01 00:00:00'");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'2015-01-01 00:00:00'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Experience).HasColumnType("int(11)");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("enum('M','F')")
                    .HasDefaultValueSql("'M'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gold).HasColumnType("int(11)");

                entity.Property(e => e.HairId)
                    .HasColumnName("HairID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LastArea)
                    .IsRequired()
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("'britannia-1|Enter|Spawn'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Level)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RememberToken)
                    .IsRequired()
                    .HasColumnName("remember_token")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<AsglaUsersInventory>(entity => {
                entity.ToTable("asgla_users_inventory");

                entity.HasIndex(e => e.ItemId)
                    .HasName("UserInventoryItemID");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserInventoryUserID");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DatePurchased)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.EnhId)
                    .HasColumnName("EnhID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ItemID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.AsglaUsersInventory)
                    //.HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserInventoryItemID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AsglaUsersInventory)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserInventoryUserID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*/
    }
}
